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
		private const string Game32ProcessName = "javaw";
		private const string Game64ProcessName = "ProjectZomboid64";

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		public static Bitmap? Capture()
		{
			var processes32 = Process.GetProcessesByName(Game32ProcessName);
			var processes64 = Process.GetProcessesByName(Game64ProcessName);
			var handle = IntPtr.Zero;

			if (processes64.Length > 0)
				handle = processes64[0].MainWindowHandle;
			else if (processes32.Length > 0)
				handle = processes32[0].MainWindowHandle;

			// Check either if the game isn't focused
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
