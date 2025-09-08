using System.Runtime.InteropServices;

namespace PZSaveManager.Classes
{
	internal static class NativeMethods
	{
		private const uint FLASHW_ALL = 3;
		private const uint FLASHW_TIMERNOFG = 12;

		[DllImport("user32.dll")] private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
		[DllImport("user32.dll")] public static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")] public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
		[DllImport("user32.dll")] public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
		[DllImport("user32.dll")] public static extern bool EnableMenuItem(IntPtr hMenu, uint itemId, uint uEnable);
		[DllImport("user32.dll")] public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll")] public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		public static void FlashWindow(IntPtr hwnd)
		{
			var info = new FLASHWINFO
			{
				cbSize = (uint)Marshal.SizeOf<FLASHWINFO>(),
				hwnd = hwnd,
				dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG,
				uCount = uint.MaxValue,
				dwTimeout = 0
			};
			_ = FlashWindowEx(ref info);
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
	}
}
