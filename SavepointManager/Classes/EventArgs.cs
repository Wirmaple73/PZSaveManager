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

	public class ArchiveStatusChangedEventArgs : EventArgs
	{
		public ArchiveStatus Status { get; }

		public ArchiveStatusChangedEventArgs(ArchiveStatus status) => Status = status;
	}
}
