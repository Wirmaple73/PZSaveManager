using SharpCompress.Archives;
using SharpCompress.Archives.Tar;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavepointManager.Properties;
using SharpCompress.Archives.Zip;
using System.Xml.Linq;

namespace SavepointManager.Classes
{
	public class Save
	{
		public const string MetadataFileName = "SaveMetadata.xml";

		public static readonly string DefaultSavePath = Path.Combine(World.WorldDirectory, "Backups");
		public static string SavePath { get; set; } = Settings.Default.SavePath.Length > 0 ? Settings.Default.SavePath : DefaultSavePath;
		public static int ProgressReportThreshold { get; } = 50;  // Report progress every 50 files

		public string WorldPath { get; }
		public string Title { get; }
		public DateTime Date { get; }
		public MemoryStream Thumb { get; }

		public string WorldName => Path.GetFileName(WorldPath);

		public Save(string worldPath, string title, DateTime date, MemoryStream thumb)
		{
			WorldPath = worldPath;
			Title = title;
			Date = date;
			Thumb = thumb;
		}

		public async Task ExportAsync(CancellationToken token)
		{
			if (!Directory.Exists(SavePath))
				Directory.CreateDirectory(SavePath);

			string outputPath = Path.Combine(SavePath, $"{WorldName} {DateTime.Now:yyyy-MM-dd HH-mm-ss fffff}.tar");

			var doc = new XDocument(
				new XElement("SaveMetadata",
					new XElement("Title", Title),
					new XElement("Timestamp", Date.ToString("G"))
				)
			);

			await Task.Run(() =>
			{
				var files = Directory.GetFiles(WorldPath, "*", SearchOption.AllDirectories);
				int totalFiles = files.Length, processedFiles = 0;

				using var archive = TarArchive.Create();

				// Add all save files to the archive
				foreach (var filePath in files)
				{
					if (token.IsCancellationRequested)
						throw new TaskCanceledException();

					string relativePath = Path.GetRelativePath(WorldPath, filePath);  // e.g. "map.bin" or "players/player.dat"
					string entryPath = Path.Combine(WorldName, relativePath).Replace('\\', '/');  // Normalize for tar

					archive.AddEntry(entryPath, filePath);
					processedFiles++;

					if (processedFiles % ProgressReportThreshold == 0)
						ArchiveProgressChanged?.Invoke(this, new(relativePath, processedFiles, totalFiles));
				}

				// Add the save metadata
				using var xmlStream = new MemoryStream();
				doc.Save(xmlStream);

				archive.AddEntry(Path.Combine(WorldName, MetadataFileName), xmlStream, true, xmlStream.Length, DateTime.Now);
				
				archive.SaveTo(outputPath, new(CompressionType.None));
			}, token);
		}

		public event EventHandler<ArchiveProgressEventArgs>? ArchiveProgressChanged;
	}
}
