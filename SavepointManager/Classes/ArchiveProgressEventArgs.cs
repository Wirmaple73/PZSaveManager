using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public class ArchiveProgressEventArgs : EventArgs
	{
		public string CurrentFileName { get; }
		public int CurrentIndex { get; }
		public int TotalFiles { get; }

		public ArchiveProgressEventArgs(string currentFileName, int currentIndex, int totalFiles)
		{
			CurrentFileName = currentFileName;
			CurrentIndex = currentIndex;
			TotalFiles = totalFiles;
		}
	}
}
