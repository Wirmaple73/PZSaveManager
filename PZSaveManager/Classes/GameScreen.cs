namespace PZSaveManager.Classes
{
	public static class GameScreen
	{
		private const string Game32ProcessName = "javaw";
		private const string Game64ProcessName = "ProjectZomboid64";

		public static Bitmap? Capture()
		{
			// At least one game process must be active
			if (!WindowHelper.IsInForeground(Game32ProcessName) && !WindowHelper.IsInForeground(Game64ProcessName))
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
