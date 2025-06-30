using SharpCompress.Archives.Tar;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SavepointManager.Classes
{
	public class World
	{
		private static readonly string BaseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Zomboid");
		public static readonly string WorldDirectory = Path.Combine(BaseDirectory, "Saves");

		private const string LockedFileName = "players.db";
		private const string ThumbName = "thumb.png";

		public string Title { get; }
		public string FolderPath { get; }
		public string ThumbPath => Path.Combine(FolderPath, ThumbName);
		public string Gamemode { get; }

		public bool IsActive
		{
			get
			{
				string lockedFilePath = Path.Combine(FolderPath, LockedFileName);

				if (!File.Exists(lockedFilePath))
					return false;

				try
				{
					// If the file 'players.db' is locked by the game, then the world is active
					using (File.Open(lockedFilePath, FileMode.Open, FileAccess.Read, FileShare.None))
					{
						return false;
					}
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

				foreach (string tarPath in Directory.GetFiles(Save.SavePath))
				{
					if (!TarArchive.IsTarFile(tarPath))
						continue;

					using var archive = TarArchive.Open(tarPath);
					string? firstEntryPath = archive.Entries.FirstOrDefault()?.Key;  // e.g. WorldName/folder/file.bin

					if (firstEntryPath is null || !firstEntryPath.Contains('/'))
						continue;

					string worldName = firstEntryPath.Split('/')[0];

					// Only fetch saves belonging to the selected world
					if (Title != worldName)
						continue;

					// Fetch the metadata
					var metadata = archive.Entries.FirstOrDefault(e => e.Key == $"{worldName}/{Save.MetadataFileName}");

					string? title = null;
					DateTime? date = null;

					if (metadata is not null)
					{
						try
						{
							using var sr = new StreamReader(metadata.OpenEntryStream());
							var xml = XElement.Load(sr);

							title = xml.Element("Title")?.Value;

							if (DateTime.TryParse(xml.Element("Timestamp")?.Value, out var parsedDate))
								date = parsedDate;
						}
						catch
						{
							// Not a big deal. The save is probably still fine.
						}
					}

					// Fetch the save preview
					var thumbFile = archive.Entries.FirstOrDefault(e => e.Key == $"{worldName}/{ThumbName}");
					var thumb = new MemoryStream();

					if (thumbFile is not null)
					{
						using var s = thumbFile.OpenEntryStream();
						s.CopyTo(thumb);

						thumb.Position = 0;
					}

					saves.Add(new(tarPath, title ?? "No title", date is not null ? date.Value : File.GetLastWriteTime(tarPath), thumb));
				}

				return saves;
            }
		}

		public World(string title, string folderPath, string gamemode)
		{
			Title	   = title;
			FolderPath = folderPath;
			Gamemode   = gamemode;
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
					worlds.Add(new(Path.GetFileName(world), world, Path.GetFileName(gamemodeFolder)));
			}

			return worlds;
		}
	}
}
