using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibGit2Sharp;

namespace SavepointManager.Classes
{
	public class Savepoint
	{
		public string WorldPath { get; }
		public string Title { get; }
		public DateTime Date { get; }

		public Savepoint(string worldPath, string title, DateTime date)
		{
			WorldPath = worldPath;
			Title = title;
			Date = date;
		}

		public void Save()
		{
			throw new NotImplementedException();
			//ZipFile.CreateFromDirectory(WorldPath, Path.Combine(WorldPath, @"C:\Users\Wirmaple73\Desktop\Archive.zip"), CompressionLevel.NoCompression, false);
		}
	}
}
