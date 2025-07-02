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
			if (!Directory.Exists(path))
				return false;

			try
			{
				Process.Start("explorer.exe", path);
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}
