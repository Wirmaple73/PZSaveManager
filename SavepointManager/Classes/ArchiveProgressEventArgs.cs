using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public class ArchiveProgressEventArgs : EventArgs
	{
		public int FilesProcessed { get; }
		public int TotalFiles { get; }

		public ArchiveProgressEventArgs(int filesProcessed, int totalFiles)
		{
			FilesProcessed = filesProcessed;
			TotalFiles = totalFiles;
		}
	}
}
