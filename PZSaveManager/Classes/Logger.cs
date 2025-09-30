using System.Collections.Concurrent;
using System.Diagnostics;

namespace PZSaveManager.Classes
{
	public static class Logger
	{
		public static string FileName => $"PZSaveManager {DateTime.Now:yyyy-MM-dd}.log";
        public static string FilePath => Path.Combine(LogDirectory, FileName);

		public static readonly string LogDirectory = Path.Combine(Environment.CurrentDirectory, "Logs");

        private static readonly BlockingCollection<string> logQueue = new();
        private static readonly Task? logWorker = null;

        private static string CurrentFileName = FileName;  // Initial file
		private static readonly object writerLock = new();

        private static StreamWriter? LogWriter = null;

        static Logger()
		{
			try
			{
				if (!Directory.Exists(LogDirectory))
					Directory.CreateDirectory(LogDirectory);

				bool prependNewLine = File.Exists(FilePath);

				UpdateWriter();
                logWorker = Task.Factory.StartNew(ProcessLogs, TaskCreationOptions.LongRunning);

                Log($"Application started in {(Environment.Is64BitProcess ? "x64" : "x86")} mode.", LogSeverity.Info, prependNewLine);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Could not open log file at {FilePath}: {ex.Message}\n{ex.StackTrace}");
			}
		}

		public static void Log(string message, LogSeverity severity, bool prependNewLine = false)
		{
            string formattedMessage = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}] {severity}: {message}";

            if (prependNewLine && File.Exists(FilePath))
                formattedMessage = Environment.NewLine + formattedMessage;

            logQueue.Add(formattedMessage);
        }

		public static void Log(string description, Stopwatch sw)
		{
			sw.Stop();
			Log($"{description} in {sw.Elapsed.TotalSeconds:f2} seconds.", LogSeverity.Info);
		}

		public static void Log(string description, Exception ex)
			=> Log($"{description}: ({ex.GetType().Name}) {ex}\n", LogSeverity.Error);

        private static void ProcessLogs()
        {
            foreach (string message in logQueue.GetConsumingEnumerable())
            {
				try
				{
					// Switch to a new log file after hitting midnight
					if (CurrentFileName != FileName)
						UpdateWriter();

					Debug.WriteLine(message);
					LogWriter?.WriteLine(message);

					Logged?.Invoke(null, new(message));
				}
				catch (Exception ex)
				{
                    Debug.WriteLine($"Loggy flatlined while trying to write '{message}':\n{ex}");
                }
            }
        }

        private static void UpdateWriter()
		{
			lock (writerLock)
			{
				CurrentFileName = FileName;
				LogWriter?.Dispose();

				try
				{
					LogWriter = new(new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.Read)) { AutoFlush = true };
				}
				catch (Exception ex)
				{
					Debug.WriteLine($"Could not create a new log writer: {ex}");
				}
			}
        }

        public static void Dispose()
        {
            logQueue.CompleteAdding();
			logWorker?.Wait(1000);
            LogWriter?.Dispose();
        }

        public static event EventHandler<LogEventArgs>? Logged;
	}
}
