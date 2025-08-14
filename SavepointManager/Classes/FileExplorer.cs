using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
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
