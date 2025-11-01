using System.Collections.Concurrent;
using System.Diagnostics;
using System.Xml.Linq;
using PZSaveManager.Properties;
using SharpCompress.Archives;
using SharpCompress.Archives.Tar;
using SharpCompress.Archives.Zip;
using IOPath = System.IO.Path;

namespace PZSaveManager.Classes
{
	public class World
	{
        public static readonly string DefaultDuserPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

		public static string BaseDirectory => Directory.Exists(Settings.Default.DuserPath) ? IOPath.Combine(Settings.Default.DuserPath, "Zomboid") : IOPath.Combine(DefaultDuserPath, "Zomboid");
		public static string WorldDirectory => IOPath.Combine(BaseDirectory, "Saves");


        private const string LockedFileName = "players.db";
		private const string BackupSuffix = "__old";

		private const string SaveNoDescription = "No description";

        private static readonly object isActiveLock = new();

        public const string ThumbName = "thumb.png";
		public const int ThumbWidth = 256;

		public string Name { get; }
		public string Path { get; }
		public string Gamemode { get; }

		public string GamemodePath { get; }
		public string BackupPath { get; }

		public DateTime LastActive => Directory.GetLastWriteTime(Path);

		public bool IsActive
		{
			get
			{
				lock (isActiveLock)
				{
					string lockedFilePath = IOPath.Combine(Path, LockedFileName);

					if (!File.Exists(lockedFilePath))
						return false;

					try
					{
						// If the file 'players.db' is locked by the game, then the world is active

						using (File.Open(lockedFilePath, FileMode.Open, FileAccess.Read, FileShare.None)) { }
						return false;
					}
					catch (IOException)
					{
						return true;
					}
					catch
					{
						return false;
					}
				}
			}
		}

		public World(string name, string path, string gamemode)
		{
			Name = name;
			Path = path;
			Gamemode = gamemode;
			GamemodePath = IOPath.Combine(WorldDirectory, Gamemode);
			BackupPath = IOPath.Combine(GamemodePath, Name + BackupSuffix);
		}

		public IEnumerable<Save> GetSaves()
			=> GetAllSaves().Where(s => s.AssociatedWorld is not null && Name == s.AssociatedWorld.Name && Gamemode == s.AssociatedWorld.Gamemode);

		private static IEnumerable<Save> GetOrphanedSaves() => GetAllSaves().Where(s => s.AssociatedWorld is null);

		private static List<Save> GetAllSaves()
		{
			var saves = new ConcurrentBag<Save>();

			if (!Directory.Exists(Save.BackupPath))
				return saves.ToList();

			var allWorlds = GetAllWorlds();

			Parallel.ForEach(Directory.EnumerateDirectories(Save.BackupPath), folderPath =>
            {
                string? archivePath = GetArchivePath();

				if (archivePath is null)
					return;  // Continue

                // Fetch the metadata
                string metadataPath = IOPath.Combine(folderPath, Save.MetadataFileName);
                string? worldName = null, worldGamemode = null, description = null;
                DateTime? date = null;

                if (File.Exists(metadataPath))
                {
                    try
                    {
                        var xml = XElement.Load(metadataPath);

                        worldName = xml.Element(XmlElementName.Metadata.WorldName)?.Value;
                        worldGamemode = xml.Element(XmlElementName.Metadata.WorldGamemode)?.Value;
                        description = xml.Element(XmlElementName.Metadata.Description)?.Value;

                        if (DateTime.TryParse(xml.Element(XmlElementName.Metadata.Date)?.Value, out var parsedDate))
                            date = parsedDate;
                    }
                    catch (Exception ex)
                    {
                        // Not a big deal. The save is probably still fine.
                        Logger.Log($"Could not process the metadata at {metadataPath}", ex);
                    }
                }

                if (worldName is null || worldGamemode is null)
                {
                    var worldData = Save.GetWorldDataFromArchive(archivePath);

                    if (worldData is null)
                    {
                        Logger.Log($"The save archive at {archivePath} appears to be corrupt. Skipping.", LogSeverity.Warning);
						return;
                    }

                    worldName = worldData.Value.Name;
                    worldGamemode = worldData.Value.Gamemode;
                }

                // Fetch the save preview
                string thumbPath = IOPath.Combine(folderPath, Save.ThumbFileName);
                var thumb = new MemoryStream();

                try
                {
                    if (File.Exists(thumbPath))
                    {
                        using var thumbFile = File.OpenRead(thumbPath);
                        thumbFile.CopyTo(thumb);
                    }
                    else
                    {
                        using var archive = ArchiveFactory.Open(archivePath);
                        using var ts = archive.Entries.FirstOrDefault(e => e.Key == $"{worldGamemode}/{worldName}/{ThumbName}")?.OpenEntryStream();
                        ts?.CopyTo(thumb);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Could not load the thumb for world {worldName} ({worldGamemode})", ex);
                }

                thumb.Position = 0;
                date ??= File.GetLastWriteTime(archivePath);

                saves.Add(new Save(GetAssociatedWorld(), description ?? SaveNoDescription, archivePath, date.Value, thumb));


                string? GetArchivePath()
                {
                    string zipPath = IOPath.Combine(folderPath, Save.ArchiveFileName + ".zip");
                    string tarPath = IOPath.Combine(folderPath, Save.ArchiveFileName + ".tar");

                    if (File.Exists(zipPath) && ZipArchive.IsZipFile(zipPath))
                        return zipPath;

                    if (File.Exists(tarPath) && TarArchive.IsTarFile(tarPath))
                        return tarPath;

                    return null;
                }

                World? GetAssociatedWorld()
                {
                    if (string.IsNullOrWhiteSpace(worldName))
                        return null;

                    try
                    {
                        return !string.IsNullOrWhiteSpace(worldGamemode) ?
                            allWorlds.FirstOrDefault(w => w.Name == worldName && w.Gamemode == worldGamemode) :
                            allWorlds.FirstOrDefault(w => w.Name == worldName);
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($"Could not find any world called {worldName} ({worldGamemode})", ex);
                        return null;
                    }
                }
            });

			return saves.ToList();
		}

		public static IEnumerable<World> GetAllWorlds()
		{
			if (!Directory.Exists(BaseDirectory))
				throw new DirectoryNotFoundException("Could not locate the save folder. Project Zomboid is likely not installed.");

			if (!Directory.Exists(WorldDirectory))
				throw new DirectoryNotFoundException("Project Zomboid is installed, but the save folder could not be located.");

			foreach (string gamemodePath in Directory.EnumerateDirectories(WorldDirectory))
			{
				foreach (string worldPath in Directory.EnumerateDirectories(gamemodePath))
				{
					string tarPath = IOPath.Combine(worldPath, $"{Save.ArchiveFileName}.tar");
					string zipPath = IOPath.Combine(worldPath, $"{Save.ArchiveFileName}.zip");

					// Filter out backups
					if (!File.Exists(tarPath) && !File.Exists(zipPath))
						yield return new(IOPath.GetFileName(worldPath), worldPath, IOPath.GetFileName(gamemodePath));
				}
			}
		}

		public static async Task SaveActiveWorldAsync(string description, CancellationTokenSource token)
		{
            var activeWorld = GetAllWorlds().FirstOrDefault(w => w.IsActive);

            if (activeWorld is null)
            {
                Logger.Log("No world is currently active. Saving has been canceled.", LogSeverity.Info);
                return;
            }

            var save = new Save(activeWorld, description);
            SoundPlayer.Shared.PlaySaveEffect(SoundEffect.Saving);

            try
            {
                await save.ExportAsync(token.Token);
                SoundPlayer.Shared.PlaySaveEffect(SoundEffect.SaveComplete);
            }
            catch (OperationCanceledException)
            {
                SoundPlayer.Shared.PlaySaveEffect(SoundEffect.SaveCanceled);
            }
            catch (Exception ex)
            {
                Logger.Log($"Could not save the world {activeWorld.Name}", ex);
                SoundPlayer.Shared.PlaySaveEffect(SoundEffect.SaveFailure);
            }
        }

		public static void CreateMissingWorlds()
		{
			// Create non-existent worlds that have any saves associated with them
			foreach (Save save in GetOrphanedSaves())
			{
				if (string.IsNullOrWhiteSpace(save.ArchivePath))
					continue;

				string? parentDir = IOPath.GetDirectoryName(save.ArchivePath);

				if (string.IsNullOrWhiteSpace(parentDir))
					continue;

				string metadataPath = IOPath.Combine(parentDir, Save.MetadataFileName);
				string? worldName = null, worldGamemode = null;

				if (File.Exists(metadataPath))
				{
					try
					{
						var xml = XElement.Load(metadataPath);

						worldName = xml.Element(XmlElementName.Metadata.WorldName)?.Value;
						worldGamemode = xml.Element(XmlElementName.Metadata.WorldGamemode)?.Value;
					}
					catch (Exception ex)
					{
						Logger.Log($"Could not read metadata at {metadataPath}", ex);
					}
				}

				if (worldName is null || worldGamemode is null)
				{
					var worldData = Save.GetWorldDataFromArchive(save.ArchivePath);

					if (worldData is null)
					{
						Logger.Log($"The archive at {save.ArchivePath} appears to be corrupt. Skipping.", LogSeverity.Warning);
						continue;
					}

					worldName = worldData.Value.Name;
					worldGamemode = worldData.Value.Gamemode;
				}

				try
				{
					Directory.CreateDirectory(IOPath.Combine(WorldDirectory, worldGamemode, worldName));
					Logger.Log($"Created the world {worldName} ({worldGamemode}) for orphaned save at {parentDir}.", LogSeverity.Info);
				}
				catch (Exception ex)
				{
					Logger.Log($"Could not create the world {worldName} ({worldGamemode}) for orphaned save at {parentDir}", ex);
				}
			}
		}

		public async Task DeleteAsync()
		{
			Logger.Log($"Beginning to delete the world {Name}...", LogSeverity.Info);
			var stopwatch = Stopwatch.StartNew();

			await Task.WhenAll(GetSaves().Select(save => save.DeleteAsync()));

			Logger.Log($"Deleting the world folder...", LogSeverity.Info);

			if (Directory.Exists(Path))
				await new DirectoryInfo(Path).DeleteParallelAsync();

			Logger.Log($"Successfully deleted the world {Name} and all of its saves", stopwatch);
		}
	}
}
