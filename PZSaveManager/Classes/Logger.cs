using System.Diagnostics;

namespace PZSaveManager.Classes
{
	public static class Logger
	{
		public static string FileName => $"PZSaveManager {DateTime.Now:yyyy-MM-dd}.log";
        public static string FilePath => Path.Combine(LogDirectory, FileName);

		public static readonly string LogDirectory = Path.Combine(Environment.CurrentDirectory, "Logs");

        private static StreamWriter? LogWriter = null;
        private static readonly object LogLock = new();

		private static string CurrentFileName = FileName;  // Initial file

		static Logger()
		{
			try
			{
				if (!Directory.Exists(LogDirectory))
					Directory.CreateDirectory(LogDirectory);

				bool prependNewLine = File.Exists(FilePath);

				UpdateWriter();
				Log($"Application started in {(Environment.Is64BitProcess ? "x64" : "x86")} mode.", LogSeverity.Info, prependNewLine);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Could not open log file at {FilePath}: {ex.Message}\n{ex.StackTrace}");
			}
		}

		public static void Log(string message, LogSeverity severity, bool prependNewLine = false)
		{
			lock (LogLock)
			{
				// Switch to a new log file after hitting midnight
				if (CurrentFileName != FileName)
				{
                    Log($"The log file has been switched to '{FileName}'.", LogSeverity.Info);
                    UpdateWriter();
				}

				// ISO 8601 gang stay winning
				string formattedMessage = $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}] {severity}: {message}";

				if (prependNewLine && File.Exists(FilePath))
					formattedMessage = Environment.NewLine + formattedMessage;

				try
				{
					LogWriter?.WriteLine(formattedMessage);
					Debug.WriteLine(formattedMessage);
				}
				catch (Exception ex)
				{
					Debug.WriteLine($"Logging failed: ({ex.GetType().Name}) {ex.Message}");
					Debug.WriteLine($"Log message: {formattedMessage}");
				}

				Logged?.Invoke(null, new(formattedMessage));
			}
		}

		public static void Log(string description, Stopwatch sw)
		{
			sw.Stop();
			Log($"{description} in {sw.Elapsed.TotalSeconds:f2} seconds.", LogSeverity.Info);
		}

		public static void Log(string description, Exception ex)
			=> Log($"{description}: ({ex.GetType().Name}) {ex.Message}\n{ex.StackTrace}\n", LogSeverity.Error);

		// You don't need an entire singleton just to dispose a single stream. A static method would do.
		public static void Dispose() => LogWriter?.Dispose();

		private static void UpdateWriter()
		{
			CurrentFileName = FileName;
            LogWriter?.Dispose();

			try
			{
				LogWriter = new(new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.Read)) { AutoFlush = true };
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Could not create a new log writer: {ex.Message}\nStack trace: {ex.StackTrace}");
			}
        }

		public static event EventHandler<LogEventArgs>? Logged;
	}
}
