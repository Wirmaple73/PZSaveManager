using System.Diagnostics;

namespace PZSaveManager.Classes
{
	public static class FileExplorer
	{
		public static bool Browse(string path)
		{
			try
			{
				Process.Start("explorer.exe", path);
			}
			catch (Exception ex)
			{
				Logger.Log($"Could not browse {path}", ex);
				return false;
			}

			return true;
		}
	}
}
