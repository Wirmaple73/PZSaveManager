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
		private static readonly string LogPath = Path.Combine(Environment.CurrentDirectory, "PZSaveManager.log");
		private const int MaxLinesToKeep = 1000;

		static Logger()
		{
			// TODO: Only keep last 1000 lines
			Log("Application started.", LogSeverity.Info);
		}

		private static string FormatMessage(string message, LogSeverity severity)
			=> $"[{DateTime.Now:yyyy/MM/dd HH:mm:ss}] {severity}: {message}";

		public static void Log(string message, LogSeverity severity)
		{
			Task.Run(async () =>
			{
				string formattedMessage = FormatMessage(message, severity);

				try
				{
					await File.AppendAllTextAsync(LogPath, formattedMessage + Environment.NewLine);
					Debug.WriteLine(formattedMessage);
				}
				catch (Exception ex)
				{
					Debug.WriteLine($"Logging failed: ({ex.GetType().Name}) {ex.Message}");
					Debug.WriteLine($"Log message: {formattedMessage}");
				}
			});
		}
	}
}
