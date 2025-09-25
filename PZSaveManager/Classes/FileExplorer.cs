using SharpCompress.Common;
using System.Diagnostics;

namespace PZSaveManager.Classes
{
	public static class FileExplorer
	{
        public static bool Browse(string path) => InternalBrowse(path, false);
        public static bool Browse(string path, bool highlight) => InternalBrowse(path, highlight);

		private static bool InternalBrowse(string path, bool highlight)
		{
            try
            {
                if (highlight)
                    Process.Start("explorer.exe", $"/select,\"{path}\"");
                else
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
