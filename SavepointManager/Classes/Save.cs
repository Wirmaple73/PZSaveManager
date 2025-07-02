using SharpCompress.Archives;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavepointManager.Properties;
using SharpCompress.Archives.Zip;
using System.Xml.Linq;
using SavepointManager.Classes.Exceptions;
using SharpCompress.Archives.Tar;
using SharpCompress.Readers;

namespace SavepointManager.Classes
{
	public class Save : IThumb
	{
		public const string MetadataFileName = "SaveMetadata.xml";

		public static readonly string DefaultBackupPath = Path.Combine(World.WorldDirectory, "Backups");
		public static string BackupPath { get; set; } = Settings.Default.SavePath.Length > 0 ? Settings.Default.SavePath : DefaultBackupPath;
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

		public async Task RestoreAsync()
		{
			await Task.Run(() =>
			{
				if (AssociatedWorld.IsActive)
					throw new WorldActiveException("The current world must not be active before proceeding.");

				if (ArchivePath is null)
					throw new ArchivePathNullException("The specified archive path is null.");

				if (!ZipArchive.IsZipFile(ArchivePath) && !TarArchive.IsTarFile(ArchivePath))
					throw new InvalidSaveArchiveException("The specified file is not a real zip or TAR archive.");

				Logger.Log($"Beginning to restore {ArchivePath}...", LogSeverity.Info);
				var startTime = DateTime.Now;

				try
				{
					// TODO: Check if this can be optimized further

					using var stream = File.OpenRead(ArchivePath);
					using var archive = ArchiveFactory.Open(stream);

					int totalFiles = archive.Entries.Count(), filesProcessed = 0;

					using var reader = archive.ExtractAllEntries();

					while (reader.MoveToNextEntry())
					{
						string outputPath = Path.Combine(AssociatedWorld.GamemodePath, reader.Entry.Key!);
						string outputParentPath = Directory.GetParent(outputPath)!.FullName;
						
						if (!Directory.Exists(outputParentPath))
							Directory.CreateDirectory(outputParentPath);

						reader.WriteEntryTo(outputPath);
						filesProcessed++;

						if (filesProcessed % ProgressReportThreshold == 0)
							ArchiveProgressChanged?.Invoke(this, new(filesProcessed, totalFiles));
					}

					Logger.Log($"Extraction took {(DateTime.Now - startTime).TotalSeconds:f1}s.", LogSeverity.Info);
				}
				catch (Exception ex)
				{
					Logger.Log($"Could not extract save archive: ({ex.GetType().Name}) {ex.Message}", LogSeverity.Error);
					throw new SaveExtractionException("Could not extract the specified save to the world directory.", ex);
				}
			});
		}

		public async Task ExportAsync(bool useCompression, CancellationToken token)
		{
			await Task.Run(() =>
			{
				if (!Directory.Exists(BackupPath))
					Directory.CreateDirectory(BackupPath);

				Logger.Log($"Beginning to export {AssociatedWorld.Name}...", LogSeverity.Info);
				var startTime = DateTime.Now;

				string outputPath = Path.Combine(BackupPath, $"{AssociatedWorld.Name} {DateTime.Now:yyyy-MM-dd HH-mm-ss fffff}.{(useCompression ? "zip" : "tar")}");

				var files = Directory.GetFiles(AssociatedWorld.Path, "*", SearchOption.AllDirectories);
				int totalFiles = files.Length, filesProcessed = 0;

				using IWritableArchive archive = useCompression ? ZipArchive.Create() : TarArchive.Create();
				
				// Add all save files to the archive
				foreach (var filePath in files)
				{
					if (token.IsCancellationRequested)
						throw new TaskCanceledException();

					string relativePath = Path.GetRelativePath(AssociatedWorld.Path, filePath);  // e.g. "folder/file.dat"
					string entryPath = Path.Combine(AssociatedWorld.Name, relativePath).Replace('\\', '/');  // e.g. WorldName/folder/file.dat

					var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
					archive.AddEntry(entryPath, fs, true, fs.Length, File.GetLastWriteTime(filePath));

					filesProcessed++;

					if (filesProcessed % ProgressReportThreshold == 0)
						ArchiveProgressChanged?.Invoke(this, new(filesProcessed, totalFiles));
				}

				// Remove the old metadata first if it exists
				string metadataPath = Path.Combine(AssociatedWorld.Name, MetadataFileName).Replace('\\', '/');

				var oldMetadata = archive.Entries.FirstOrDefault(e => e.Key == metadataPath);

				if (oldMetadata is not null)
					archive.RemoveEntry(oldMetadata);

				// Add the new metadata
				var doc = new XDocument(
					new XElement(XmlElementName.SaveMetadata,
						new XElement(XmlElementName.Description, Description),
						new XElement(XmlElementName.Date, Date.ToString("G"))
					)
				);

				using var xmlStream = new MemoryStream();
				doc.Save(xmlStream);

				archive.AddEntry(metadataPath, xmlStream, true, xmlStream.Length, DateTime.Now);

				// Whenever the game has actively loaded a save, it doesn't update the thumb before the save is closed.
				// We can try to take a screenshot ourselves to help the player better recognize the save later.
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

				ExportStarted?.Invoke(this, EventArgs.Empty);
				archive.SaveTo(outputPath, new(useCompression ? CompressionType.Deflate : CompressionType.None));

				Logger.Log($"Exportation took {(DateTime.Now - startTime).TotalSeconds:f1}s.", LogSeverity.Info);
			}, token);
		}

		public event EventHandler<ArchiveProgressEventArgs>? ArchiveProgressChanged;
		public event EventHandler<EventArgs>? ExportStarted;
	}
}
