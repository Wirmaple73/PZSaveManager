using SavepointManager.Forms;
using SavepointManager.Properties;
using SharpCompress.Archives;
using SharpCompress.Archives.Tar;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using IOPath = System.IO.Path;

namespace SavepointManager.Classes
{
	public class World
	{
		public static readonly string BaseDirectory = IOPath.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Zomboid");
		public static readonly string WorldDirectory = IOPath.Combine(BaseDirectory, "Saves");

		private const string LockedFileName = "players.db";
		private const string BackupSuffix = "_old";

		private static readonly string[] FilesToDelete = { "Save.tar", "Save.zip", "Metadata.xml", "Thumb.png" };

		public const string ThumbName = "thumb.png";
		public const int ThumbWidth = 256;

		public string Name { get; }
		public string Path { get; }
		public string Gamemode { get; }

		public string GamemodePath { get; }
		public string BackupPath { get; }

		public bool IsActive
		{
			get
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

		private static IEnumerable<Save> GetAllSaves()
		{
			// TODO: Make this parallel
			if (!Directory.Exists(Save.BackupPath))
				yield break;

			foreach (string folderPath in Directory.EnumerateDirectories(Save.BackupPath))
			{
				string? archivePath = GetArchivePath();

				if (archivePath is null)
					continue;

				// Fetch the metadata
				string metadataPath = IOPath.Combine(folderPath, Save.MetadataFileName);
				string? worldName = null, worldGamemode = null, description = null;
				DateTime? date = null;

				if (File.Exists(metadataPath))
				{
					try
					{
						var xml = XElement.Load(metadataPath);

						worldName	  = xml.Element(XmlElementName.WorldName)?.Value;
						worldGamemode = xml.Element(XmlElementName.WorldGamemode)?.Value;
						description	  = xml.Element(XmlElementName.Description)?.Value;

						if (DateTime.TryParse(xml.Element(XmlElementName.Date)?.Value, out var parsedDate))
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
						continue;
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
					Logger.Log($"Could not load the thumb for the world {worldName} ({worldGamemode})", ex);
				}

				thumb.Position = 0;
				date ??= File.GetLastWriteTime(archivePath);

				yield return new(GetAssociatedWorld(), description ?? "No description", archivePath, date.Value, thumb);

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

					// TODO: Use foreach if needed
					var worlds = GetAllWorlds();

					return !string.IsNullOrWhiteSpace(worldGamemode) ?
						worlds.FirstOrDefault(w => w.Name == worldName && w.Gamemode == worldGamemode) :
						worlds.FirstOrDefault(w => w.Name == worldName);
				}
			}
		}

		public static IEnumerable<World> GetAllWorlds()
		{
			if (!Directory.Exists(BaseDirectory))
				throw new DirectoryNotFoundException("Could not locate the save folder. Project Zomboid is likely not installed.");

			if (!Directory.Exists(WorldDirectory))
				throw new DirectoryNotFoundException("Project Zomboid is installed, but the save folder could not be located.");

			var gamemodes = Directory.GetDirectories(WorldDirectory);

			foreach (var gamemodeFolder in gamemodes)
			{
				var worldFolders = Directory.GetDirectories(gamemodeFolder);

				foreach (var world in worldFolders)
				{
					string tarPath = IOPath.Combine(world, $"{Save.ArchiveFileName}.tar");
					string zipPath = IOPath.Combine(world, $"{Save.ArchiveFileName}.zip");

					// Filter out backups
					if (!File.Exists(tarPath) && !File.Exists(zipPath))
						yield return new(IOPath.GetFileName(world), world, IOPath.GetFileName(gamemodeFolder));
				}
			}
		}

		public static void SaveActiveWorld(string description, CancellationTokenSource token)
		{
			Task.Run(async () =>
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
					await save.ExportAsync(false, token.Token);
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
			}, token.Token);
		}

		public static void CreateMissingWorlds()
		{
            // Create non-existent worlds that have any saves associated with them
			// TODO: Parallelize
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

						worldName = xml.Element(XmlElementName.WorldName)?.Value;
						worldGamemode = xml.Element(XmlElementName.WorldGamemode)?.Value;
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

		public void Delete()
		{
			// TODO: Parallelize
			foreach (Save save in GetSaves())
			{
				if (string.IsNullOrWhiteSpace(save.ArchivePath))
					continue;

				string? parentFolderPath = IOPath.GetDirectoryName(save.ArchivePath);

				if (string.IsNullOrWhiteSpace(parentFolderPath) || !Directory.Exists(parentFolderPath))
					continue;

				foreach (string filename in FilesToDelete)
				{
					string filePath = IOPath.Combine(parentFolderPath, filename);

					if (File.Exists(filePath))
					{
						try
						{
							File.Delete(filePath);
						}
						catch (Exception ex)
						{
							Logger.Log($"Couldn't delete the file at {filePath}", ex);
						}
					}
				}

				try
				{
					Directory.Delete(parentFolderPath);
				}
				catch (Exception ex)
				{
					Logger.Log($"Couldn't delete the save directory at {parentFolderPath}", ex);
				}
			};

			// Parallelize this if necessary
			if (Directory.Exists(Path))
				Directory.Delete(Path, true);
		}
	}
}
