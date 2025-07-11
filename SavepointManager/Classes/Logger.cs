using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public static class Logger
	{
		private static readonly string LogDirectory = Path.Combine(Environment.CurrentDirectory, "Logs");
		private static string FilePath => Path.Combine(LogDirectory, $"PZSaveManager {DateTime.Now:yyyy-MM-dd}.log");

		private static string FormatMessage(string message, LogSeverity severity)
			=> $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}] {severity}: {message}";  // ISO 8601 gang stay winning

		static Logger()
		{
			Log($"Application started.", LogSeverity.Info, true);
		}

		public static void Log(string message, LogSeverity severity, bool insertNewLineBefore = false)
		{
			string formattedMessage = FormatMessage(message, severity);

			if (insertNewLineBefore && File.Exists(FilePath))
				formattedMessage = Environment.NewLine + formattedMessage;

			try
			{
				if (!Directory.Exists(LogDirectory))
					Directory.CreateDirectory(LogDirectory);

				File.AppendAllText(FilePath, formattedMessage + Environment.NewLine);
				Debug.WriteLine(formattedMessage);
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Logging failed: ({ex.GetType().Name}) {ex.Message}");
				Debug.WriteLine($"Log message: {formattedMessage}");
			}
		}

		public static void Log(string description, Exception ex)
			=> Log($"{description}: ({ex.GetType().Name}) {ex.Message}", LogSeverity.Error);
	}
}
