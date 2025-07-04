using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public static class Window
	{
		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		public static bool IsInForeground()
			=> Process.GetCurrentProcess().MainWindowHandle == GetForegroundWindow();

		public static bool IsInForeground(string processName)
		{
			var processes = Process.GetProcessesByName(processName);
			return processes.Length > 0 && processes[0].MainWindowHandle == GetForegroundWindow();
		}
	}
}
