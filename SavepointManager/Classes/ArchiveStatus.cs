namespace SavepointManager.Classes
{
	public enum ArchiveStatus
	{
		Extracting, SavingToDisk,					// Restoring
		AddingFromDisk, AddingToArchive, Exporting	// Exporting
	}
}
