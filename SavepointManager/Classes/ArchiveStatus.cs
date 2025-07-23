using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public enum ArchiveStatus
	{
		Extracting, SavingToDisk,					// Restoring
		AddingFromDisk, AddingToArchive, Exporting	// Exporting
	}
}
