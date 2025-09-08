namespace PZSaveManager.Classes.Exceptions
{

	public class ArchivePathNullException : Exception
	{
		public ArchivePathNullException() : base() { }
		public ArchivePathNullException(string? message) : base(message) { }
		public ArchivePathNullException(string? message, Exception? innerException) : base(message, innerException) { }
	}

	public class WorldActiveException : Exception
	{
		public WorldActiveException() : base() { }
		public WorldActiveException(string? message) : base(message) { }
		public WorldActiveException(string? message, Exception? innerException) : base(message, innerException) { }
	}

	public class InvalidSaveArchiveException : Exception
	{
		public InvalidSaveArchiveException() : base() { }
		public InvalidSaveArchiveException(string? message) : base(message) { }
		public InvalidSaveArchiveException(string? message, Exception? innerException) : base(message, innerException) { }
	}

	public class SaveBackupException : Exception
	{
		public SaveBackupException() : base() { }
		public SaveBackupException(string? message) : base(message) { }
		public SaveBackupException(string? message, Exception? innerException) : base(message, innerException) { }
	}

	public class SaveExtractionException : Exception
	{
		public SaveExtractionException() : base() { }
		public SaveExtractionException(string? message) : base(message) { }
		public SaveExtractionException(string? message, Exception? innerException) : base(message, innerException) { }
	}
}
