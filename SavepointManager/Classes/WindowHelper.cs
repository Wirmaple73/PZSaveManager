using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public static class WindowHelper
	{
		public static bool IsInForeground()
			=> Process.GetCurrentProcess().MainWindowHandle == GetForegroundWindow();

		public static bool IsInForeground(string processName)
		{
			var processes = Process.GetProcessesByName(processName);
			return processes.Length > 0 && processes[0].MainWindowHandle == GetForegroundWindow();
		}

		public static void FlashIfMinimized()
		{
			if (!IsInForeground())
			{
				SystemSounds.Beep.Play();

				var fw = new FLASHWINFO
				{
					cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO))),
					hwnd = Process.GetCurrentProcess().MainWindowHandle,
					dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG,
					uCount = uint.MaxValue, // Flash forever
					dwTimeout = 0
				};

				FlashWindowEx(ref fw);
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct FLASHWINFO
		{
			public uint cbSize;
			public IntPtr hwnd;
			public uint dwFlags;
			public uint uCount;
			public uint dwTimeout;
		}

		[DllImport("user32.dll")]
		private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		private const uint FLASHW_ALL = 3;        // Flash both caption and taskbar button
		private const uint FLASHW_TIMERNOFG = 12; // Flash until window comes to foreground
	}
}
