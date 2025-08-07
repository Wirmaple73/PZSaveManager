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
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Buffers;

namespace SavepointManager.Classes
{
	public class Save
	{
		public const string ArchiveFileName = "Save";
		public const string MetadataFileName = "Metadata.xml";
		public const string ThumbFileName = "Thumb.png";

		public const string ManualSaveDescription = "Manual save";
		public const string ExternalSaveDescription = "External save";
		public const string AutosaveDescription = "Auto-save";
		public const string UnnamedSaveDescription = "Unnamed save";

		public static readonly string DefaultBackupPath = Path.Combine(World.BaseDirectory, "Backups");

		public static string BackupPath => Settings.Default.SavePath.Length > 0 ? Settings.Default.SavePath : DefaultBackupPath;
		public static int ProgressReportThreshold { get; } = 50;  // Report progress every 50 files

		public static long AvailableSaveDiskSpace = new DriveInfo(BackupPath).AvailableFreeSpace;
		public static long TotalSaveDiskSpace = new DirectoryInfo(BackupPath).GetFiles("*", SearchOption.AllDirectories)

		public World AssociatedWorld { get; }
		public string? ArchivePath { get; }
		public string Description { get; }
		public DateTime Date { get; }
		public MemoryStream Thumb { get; }

		public static bool IsSaveInProgress { get; private set; } = false;
		public static bool IsSaveCancelable { get; private set; } = true;

		private static readonly object saveLock = new();

		public Save(World associatedWorld, string description, string? archivePath, DateTime date, MemoryStream thumb)
		{
			AssociatedWorld = associatedWorld;
			Description = description;
			ArchivePath = archivePath;
			Date = date;
			Thumb = thumb;
		}

		public Save(World associatedWorld, string description) : this(associatedWorld, description, null, DateTime.Now, new()) { }

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

				try
				{
					Logger.Log($"Beginning to restore {ArchivePath}...", LogSeverity.Info);
					var startTime = DateTime.Now;

					using var stream = File.OpenRead(ArchivePath);
					using var archive = ArchiveFactory.Open(stream);

					var entryArray = archive.Entries.ToArray();  // Evil exception dynamite warehouse
					int totalFiles = entryArray.Length;

					var streams = new ConcurrentBag<(string OutputPath, MemoryStream Stream)>();
					UpdateArchiveStatus(ArchiveStatus.Extracting, "Extracting entries to memory...");

					for (int i = 0; i < totalFiles; i++)
					{
						var ms = new MemoryStream();

						entryArray[i].WriteTo(ms);
						ms.Position = 0;

						streams.Add((Path.Combine(AssociatedWorld.GamemodePath, entryArray[i].Key!), ms));

						if (i % ProgressReportThreshold == 0)
						{
							if (AssociatedWorld.IsActive)
								throw new WorldActiveException("The current world must not be active before proceeding.");

							ArchiveProgressChanged?.Invoke(this, new(i, totalFiles));
						}
					}

					UpdateArchiveStatus(ArchiveStatus.SavingToDisk, "Saving entries to disk...");
					int filesProcessed = 0;

					Parallel.ForEach(streams, entry =>
					{
						Directory.CreateDirectory(Directory.GetParent(entry.OutputPath)!.FullName);

						using (entry.Stream)
						{
							using var fs = File.OpenWrite(entry.OutputPath);
							entry.Stream.CopyTo(fs);
						}

						int filesProcessedNew = Interlocked.Increment(ref filesProcessed);

						if (filesProcessedNew % ProgressReportThreshold == 0)
						{
							if (AssociatedWorld.IsActive)
								throw new WorldActiveException("The current world must not be active before proceeding.");

							ArchiveProgressChanged?.Invoke(this, new(filesProcessedNew, totalFiles));
						}
					});

					Logger.Log($"Restoration took {(DateTime.Now - startTime).TotalSeconds:f1}s.", LogSeverity.Info);
				}
				catch (Exception ex)
				{
					// SaveExtractionException implies that the save might be corrupted
					throw new SaveExtractionException("Could not extract the specified save to the world directory.", ex);
				}

				// Replace the old thumb
				if (Thumb is null || Thumb.Length == 0)
					return;

				try
				{
					using var ts = File.OpenWrite(Path.Combine(AssociatedWorld.Path, World.ThumbName));

					Thumb.Position = 0;
					Thumb.CopyTo(ts);

					ts.Position = 0;
				}
				catch (Exception ex)
				{
					Logger.Log("The old thumb couldn't be replaced", ex);
				}
			});
		}

		public async Task ExportAsync(bool useCompression, CancellationToken token)
		{
			lock (saveLock)
			{
				// TODO: Don't export if save directory is empty

				if (IsSaveInProgress)
					throw new InvalidOperationException("Another save is already in progress. Please wait until it is completed.");

				SetSaveState(true, true);
			}

			string saveName = $"{AssociatedWorld.Name} {DateTime.Now:yyyy-MM-dd HH-mm-ss fffff}";  // ISO 8601 gang stay winning
			string saveDir = Path.Combine(BackupPath, saveName);

			try
			{
				await Task.Run(() =>
				{
					Directory.CreateDirectory(BackupPath);

					Logger.Log($"Beginning to export {AssociatedWorld.Name}... (compression {(useCompression ? "enabled" : "disabled")})", LogSeverity.Info);
					var startTime = DateTime.Now;

					Directory.CreateDirectory(saveDir);

					string outputArchivePath = Path.Combine(saveDir, ArchiveFileName + (useCompression ? ".zip" : ".tar"));
					string outputXmlPath = Path.Combine(saveDir, MetadataFileName);
					string outputThumbPath = Path.Combine(saveDir, ThumbFileName);

					var files = Directory.GetFiles(AssociatedWorld.Path, "*", SearchOption.AllDirectories);
					int totalFiles = files.Length, processedFiles = 0;

					using IWritableArchive archive = useCompression ? ZipArchive.Create() : TarArchive.Create();

					var bag = new ConcurrentBag<(string EntryPath, MemoryStream Stream, DateTime EntryDate)>();

					UpdateArchiveStatus(ArchiveStatus.AddingFromDisk, "Adding files from disk...");
					var thumb = GetSaveThumb();

					Parallel.For(0, totalFiles, new() { CancellationToken = token }, i =>
					{
						var ms = new MemoryStream();

						// Copy every file to the memory to avoid archive corruption. The game actively messes with them.
						using (var fs = new FileStream(files[i], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
							fs.CopyTo(ms);

						ms.Position = 0;

						string relativePath = Path.GetRelativePath(AssociatedWorld.Path, files[i]);  // e.g. "folder/file.dat"
						string entryPath = Path.Combine(AssociatedWorld.Name, relativePath).Replace('\\', '/');  // e.g. WorldName/folder/file.dat

						bag.Add((entryPath, ms, File.GetLastWriteTime(files[i])));
						int processedFilesNew = Interlocked.Increment(ref processedFiles);

						if (processedFilesNew % ProgressReportThreshold == 0)
							ArchiveProgressChanged?.Invoke(this, new(processedFilesNew, totalFiles));
					});

					UpdateArchiveStatus(ArchiveStatus.AddingToArchive, "Adding files to archive...");
					processedFiles = 0;

					while (bag.TryTake(out var entry))
					{
						archive.AddEntry(entry.EntryPath, entry.Stream, true, entry.Stream.Length, entry.EntryDate);

						if (++processedFiles % ProgressReportThreshold == 0)
						{
							if (token.IsCancellationRequested)
								throw new OperationCanceledException();

							ArchiveProgressChanged?.Invoke(this, new(processedFiles, totalFiles));
						}
					}

					// Export the archive
					SetSaveState(true, false);
					UpdateArchiveStatus(ArchiveStatus.Exporting, "Save is now uncancellable. Exporting the archive...");

					archive.SaveTo(outputArchivePath, new(useCompression ? CompressionType.Deflate : CompressionType.None));

					// Save the metadata and thumb
					var doc = new XDocument(
						new XElement(XmlElementName.Metadata,
							new XElement(XmlElementName.WorldName, AssociatedWorld.Name),
							new XElement(XmlElementName.Description, Description),
							new XElement(XmlElementName.Date, Date.ToString("G"))
						)
					);

					doc.Save(outputXmlPath);
					thumb?.Save(outputThumbPath, System.Drawing.Imaging.ImageFormat.Png);
					thumb?.Dispose();

					Logger.Log($"Successfully exported the world {AssociatedWorld.Name} in {(DateTime.Now - startTime).TotalSeconds:f1} seconds.", LogSeverity.Info);

					Bitmap? GetSaveThumb()
					{
						// Whenever the game has actively loaded a world, it doesn't update the thumb till the world is closed.
						// We can take a screenshot ourselves to help the player better recognize the save.
						if (AssociatedWorld.IsActive)
						{
							using var thumb = GameScreen.Capture();
							return thumb is not null ? thumb.CropCenter(World.ThumbWidth, World.ThumbWidth) : GetOriginalThumb();
						}

						return GetOriginalThumb();

						Bitmap? GetOriginalThumb()
						{
							string originalPath = Path.Combine(AssociatedWorld.Path, World.ThumbName);
							return File.Exists(originalPath) ? new Bitmap(originalPath) : null;
						}
					}
				}, token);
			}
			catch
			{
				try
				{
					Directory.Delete(saveDir, true);
				}
				catch (Exception ex)
				{
					Logger.Log("The save directory could not be deleted", ex);
				}

				SetSaveState(false, true);
				throw;
			}
			finally
			{
				SetSaveState(false, true);
			}

			void SetSaveState(bool isInProgress, bool isCancelable)
			{
				IsSaveInProgress = isInProgress;
				IsSaveCancelable = isCancelable;
			}
		}

		public async Task RenameAsync(string newDescription)
		{
			await Task.Run(() =>
			{
				string metadataPath = Path.Combine(Directory.GetParent(ArchivePath!)!.FullName, MetadataFileName);

				if (File.Exists(metadataPath))
				{
					var doc = XElement.Load(metadataPath);

					doc.SetElementValue(XmlElementName.Description, newDescription);
					doc.Save(metadataPath);
				}
				else
				{
					// Save the metadata and thumb
					var doc = new XDocument(
						new XElement(XmlElementName.Metadata,
							new XElement(XmlElementName.WorldName, AssociatedWorld.Name),
							new XElement(XmlElementName.Description, newDescription),
							new XElement(XmlElementName.Date, Date)
						)
					);

					doc.Save(metadataPath);
				}
			});
		}

		public async Task DeleteAsync() => await Task.Run(() => Directory.Delete(Directory.GetParent(ArchivePath!)!.FullName, true));

		private void UpdateArchiveStatus(ArchiveStatus status, string logMessage)
		{
			Logger.Log(logMessage, LogSeverity.Info);
			ArchiveStatusChanged?.Invoke(this, new(status));
		}

		public event EventHandler<ArchiveProgressEventArgs>? ArchiveProgressChanged;
		public event EventHandler<ArchiveStatusChangedEventArgs>? ArchiveStatusChanged;
	}
}
