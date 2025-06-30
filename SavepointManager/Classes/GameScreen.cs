using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SavepointManager.Classes
{
	public static class GameScreen
	{
		private const string GameProcessName32 = "javaw";
		private const string GameProcessName64 = "ProjectZomboid64";

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		public static Bitmap? Capture()
		{
			var processes32 = Process.GetProcessesByName(GameProcessName32);
			var processes64 = Process.GetProcessesByName(GameProcessName64);
			IntPtr handle;

			if (processes64.Length > 0)
				handle = processes64[0].MainWindowHandle;
			else if (processes32.Length > 0)
				handle = processes32[0].MainWindowHandle;
			else
				return null;

			// Check either if the handle is invalid or game isn't focused
			if (handle == IntPtr.Zero || handle != GetForegroundWindow())
				return null;

			var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

			using (var g = Graphics.FromImage(bmp))
			{
				g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
			}

			return bmp;
		}
	}
}
