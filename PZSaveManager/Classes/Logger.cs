using System.Diagnostics;

namespace PZSaveManager.Classes
{
	public static class Logger
	{
		public static string FilePath => Path.Combine(LogDirectory, $"PZSaveManager {DateTime.Now:yyyy-MM-dd}.log");

		private static readonly string LogDirectory = Path.Combine(Environment.CurrentDirectory, "Logs");

		private static readonly StreamWriter? LogWriter = null;
		private static readonly object LogLock = new();

		static Logger()
		{
			try
			{
				if (!Directory.Exists(LogDirectory))
					Directory.CreateDirectory(LogDirectory);

				bool prependNewLine = File.Exists(FilePath);

				LogWriter = new(FilePath, true) { AutoFlush = true };
				Log($"Application started.", LogSeverity.Info, prependNewLine);
			}
			catch (Exception ex)
			{
				Log("Could not open the log file", ex);
			}
		}

		public static void Log(string message, LogSeverity severity, bool prependNewLine = false)
		{
			lock (LogLock)
			{
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
			}
		}

		public static void Log(string description, Stopwatch sw)
		{
			sw.Stop();
			Log($"{description} in {sw.Elapsed.TotalSeconds:f1} seconds.", LogSeverity.Info);
		}

		public static void Log(string description, Exception ex)
			=> Log($"{description}: ({ex.GetType().Name}) {ex.Message}\n{ex.StackTrace}\n", LogSeverity.Error);

		// You don't need an entire singleton just to dispose a single stream. A static method does the trick.
		public static void Dispose() => LogWriter?.Dispose();
	}
}
