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

namespace SavepointManager.Classes
{
	public class World : IEquatable<World>
	{
		public static readonly string BaseDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Zomboid");
		public static readonly string WorldDirectory = System.IO.Path.Combine(BaseDirectory, "Saves");

		private const string LockedFileName = "players.db";
		private const string BackupSuffix = "_old";

		public const string ThumbName = "thumb.png";
		public const int ThumbWidth = 256;

		public string Name { get; }
		public string Path { get; }
		public string Gamemode { get; }

		public string GamemodePath => System.IO.Path.Combine(WorldDirectory, Gamemode);
		public string BackupPath => System.IO.Path.Combine(GamemodePath, Name + BackupSuffix);

		public bool IsActive
		{
			get
			{
				string lockedFilePath = System.IO.Path.Combine(Path, LockedFileName);

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

		public List<Save> Saves
		{
			get
			{
				var saves = new List<Save>();

				if (!Directory.Exists(Save.BackupPath))
					return saves;

				foreach (string folderPath in Directory.GetDirectories(Save.BackupPath))
				{
					string? archivePath = GetArchivePath();

					if (archivePath is null)
						continue;

					// Fetch the metadata
					string metadataPath = System.IO.Path.Combine(folderPath, Save.MetadataFileName);

					string? description = null;
					DateTime? date = null;

					if (File.Exists(metadataPath))
					{
						try
						{
							using var fs = File.OpenRead(metadataPath);
							var xml = XElement.Load(fs);

							var worldNameElement = xml.Element(XmlElementName.WorldName);

							if (worldNameElement is not null)
							{
								if (worldNameElement.Value != Name)
									continue;
							}
							else
							{
								if (GetWorldNameFromArchive() != Name)
									continue;
							}

							description = xml.Element(XmlElementName.Description)?.Value;

							if (DateTime.TryParse(xml.Element(XmlElementName.Date)?.Value, out var parsedDate))
								date = parsedDate;
						}
						catch
						{
							// Not a big deal. The save is probably still fine.
						}
					}
					else
					{
						if (GetWorldNameFromArchive() != Name)
							continue;
					}

					// Fetch the save preview
					string thumbPath = System.IO.Path.Combine(folderPath, Save.ThumbFileName);
					var thumb = new MemoryStream();

					if (File.Exists(thumbPath))
					{
						using var thumbFile = File.OpenRead(thumbPath);
						thumbFile.CopyTo(thumb);
					}
					else
					{
						using var archive = ArchiveFactory.Open(archivePath);
						using var ts = archive.Entries.FirstOrDefault(e => e.Key == $"{Name}/{ThumbName}")?.OpenEntryStream();
						ts?.CopyTo(thumb);
					}

					thumb.Position = 0;

					// Strip extra date components like milliseconds, etc.
					date ??= File.GetLastWriteTime(archivePath);
					date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, date.Value.Hour, date.Value.Minute, date.Value.Second);

					saves.Add(new Save(this, description ?? "No description", archivePath, date.Value, thumb));

					string? GetArchivePath()
					{
						string zipPath = System.IO.Path.Combine(folderPath, Save.ArchiveFileName + ".zip");
						string tarPath = System.IO.Path.Combine(folderPath, Save.ArchiveFileName + ".tar");

						if (File.Exists(zipPath) && ZipArchive.IsZipFile(zipPath))
							return zipPath;

						if (File.Exists(tarPath) && TarArchive.IsTarFile(tarPath))
							return tarPath;

						return null;
					}

					string? GetWorldNameFromArchive()
					{
						using var archive = ArchiveFactory.Open(archivePath);
						string? firstEntryPath = archive.Entries.FirstOrDefault()?.Key;  // e.g. WorldName/map_sand.bin

						return firstEntryPath is not null && firstEntryPath.Contains('/') ? firstEntryPath.Split('/')[0] : null;
					}
				}

				return saves;
			}
		}

		public World(string name, string path, string gamemode)
		{
			Name = name;
			Path = path;
			Gamemode = gamemode;
		}

		public static List<World> FetchAll()
		{
			if (!Directory.Exists(BaseDirectory))
				throw new DirectoryNotFoundException("Could not locate the save folder. Project Zomboid is likely not installed.");

			if (!Directory.Exists(WorldDirectory))
				throw new DirectoryNotFoundException("Project Zomboid is installed, but the save folder could not be located.");

			var worlds = new List<World>();
			var gamemodes = Directory.GetDirectories(WorldDirectory);

			foreach (var gamemodeFolder in gamemodes)
			{
				var worldFolders = Directory.GetDirectories(gamemodeFolder);

				foreach (var world in worldFolders)
				{
					string tarPath = System.IO.Path.Combine(world, $"{Save.ArchiveFileName}.tar");
					string zipPath = System.IO.Path.Combine(world, $"{Save.ArchiveFileName}.zip");

					// Filter out backups
					if (!File.Exists(tarPath) && !File.Exists(zipPath))
						worlds.Add(new(System.IO.Path.GetFileName(world), world, System.IO.Path.GetFileName(gamemodeFolder)));
				}
			}

			return worlds;
		}

		public static void SaveActiveWorld(string description, CancellationTokenSource token)
		{
			Task.Run(async () =>
			{
				var activeWorld = FetchAll().FirstOrDefault(w => w.IsActive);

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
				catch (TaskCanceledException)
				{
					Logger.Log($"Saving has been aborted by the user.", LogSeverity.Info);
					SoundPlayer.Shared.PlaySaveEffect(SoundEffect.SaveCanceled);
				}
				catch (Exception ex)
				{
					Logger.Log($"Could not save the world {activeWorld.Name}", ex);
					SoundPlayer.Shared.PlaySaveEffect(SoundEffect.SaveFailure);
				}
			}, token.Token);
		}

		public bool Equals(World? other) => other is not null && Name == other.Name && Gamemode == other.Gamemode;
		public override bool Equals(object? obj) => obj is World w && Equals(w);

		public static bool operator ==(World left, World right) => left.Equals(right);
		public static bool operator !=(World left, World right) => !(left == right);

		public override int GetHashCode()
		{
			throw new NotImplementedException();
		}
	}
}
