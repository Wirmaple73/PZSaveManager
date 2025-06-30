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
	public class Save : IThumb
	{
		public const string MetadataFileName = "SaveMetadata.xml";

		public static readonly string DefaultSavePath = Path.Combine(World.WorldDirectory, "Backups");
		public static string SavePath { get; set; } = Settings.Default.SavePath.Length > 0 ? Settings.Default.SavePath : DefaultSavePath;
		public static int ProgressReportThreshold { get; } = 50;  // Report progress every 50 files

		public World AssociatedWorld { get; }
		public string? ArchivePath { get; }
		public string Description { get; }
		public DateTime Date { get; }
		public MemoryStream Thumb { get; }

		public Save(World associatedWorld, string? archivePath, string description, DateTime date, MemoryStream thumb)
		{
			AssociatedWorld = associatedWorld;
			ArchivePath = archivePath;
			Description = description;
			Date = date;
			Thumb = thumb;
		}

		public async Task ExportAsync(CancellationToken token)
		{
			if (!Directory.Exists(SavePath))
				Directory.CreateDirectory(SavePath);

			string outputPath = Path.Combine(SavePath, $"{AssociatedWorld.Name} {DateTime.Now:yyyy-MM-dd HH-mm-ss fffff}.tar");

			var doc = new XDocument(
				new XElement(XmlElementName.SaveMetadata,
					new XElement(XmlElementName.Description, Description),
					new XElement(XmlElementName.Date, Date.ToString("G"))
				)
			);

			await Task.Run(() =>
			{
				var files = Directory.GetFiles(AssociatedWorld.Path, "*", SearchOption.AllDirectories);
				int totalFiles = files.Length, processedFiles = 0;

				using var archive = TarArchive.Create();

				// Add all save files to the archive
				foreach (var filePath in files)
				{
					if (token.IsCancellationRequested)
						throw new TaskCanceledException();

					string relativePath = Path.GetRelativePath(AssociatedWorld.Path, filePath);  // e.g. "folder/file.dat"
					string entryPath = Path.Combine(AssociatedWorld.Name, relativePath).Replace('\\', '/');  // e.g. WorldName/folder/file.dat

					var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					archive.AddEntry(entryPath, fs, true, fs.Length, File.GetLastWriteTime(filePath));

					processedFiles++;

					if (processedFiles % ProgressReportThreshold == 0)
						ArchiveProgressChanged?.Invoke(this, new(relativePath, processedFiles, totalFiles));
				}

				// Add the save metadata
				using var xmlStream = new MemoryStream();
				doc.Save(xmlStream);

				archive.AddEntry(Path.Combine(AssociatedWorld.Name, MetadataFileName), xmlStream, true, xmlStream.Length, DateTime.Now);

				// Whenever the game has actively loaded a save, it doesn't update the thumb before the save is closed.
				// We can try to take a screenshot ourselves for kudos.
				if (AssociatedWorld.IsActive)
				{
					var thumb = GameScreen.Capture();

					if (thumb is not null)
					{
						string thumbPath = Path.Combine(AssociatedWorld.Name, World.ThumbName).Replace('\\', '/');
						var originalThumb = archive.Entries.FirstOrDefault(e => e.Key == thumbPath);

						if (originalThumb is not null)
						{
							var ms = new MemoryStream();

							thumb = thumb.CropCenterAndResize(World.ThumbWidth);
							thumb.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

							archive.RemoveEntry(originalThumb);
							archive.AddEntry(thumbPath, ms, true, ms.Length, DateTime.Now);
						}
					}
				}

				archive.SaveTo(outputPath, new(CompressionType.None));
			}, token);
		}

		public event EventHandler<ArchiveProgressEventArgs>? ArchiveProgressChanged;
	}
}
