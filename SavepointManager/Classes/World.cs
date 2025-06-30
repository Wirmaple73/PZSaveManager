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
	public class World : IThumb
	{
		private static readonly string BaseDirectory = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Zomboid");
		public static readonly string WorldDirectory = System.IO.Path.Combine(BaseDirectory, "Saves");

		private const string LockedFileName = "players.db";
		public const string ThumbName = "thumb.png";

		public const int ThumbWidth = 256;
		public const int ThumbHeight = 256;

		public string Name { get; }
		public string Path { get; }
		public MemoryStream Thumb { get; }
		public string Gamemode { get; }

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

					// Only fetch saves within the same world
					if (Name != firstEntryPath.Split('/')[0])
						continue;

					// Fetch the metadata
					var metadata = archive.Entries.FirstOrDefault(e => e.Key == $"{Name}/{Save.MetadataFileName}");

					string? description = null;
					DateTime? date = null;

					if (metadata is not null)
					{
						try
						{
							using var sr = new StreamReader(metadata.OpenEntryStream());
							var xml = XElement.Load(sr);

							description = xml.Element(XmlElementName.Description)?.Value;

							if (DateTime.TryParse(xml.Element(XmlElementName.Date)?.Value, out var parsedDate))
								date = parsedDate;
						}
						catch
						{
							// Not a big deal. The save is probably still fine.
						}
					}

					// Fetch the save preview
					var thumbFile = archive.Entries.FirstOrDefault(e => e.Key == $"{Name}/{ThumbName}");
					var thumb = new MemoryStream();

					if (thumbFile is not null)
					{
						using var s = thumbFile.OpenEntryStream();
						s.CopyTo(thumb);

						thumb.Position = 0;
					}

					saves.Add(new Save(this, tarPath, description ?? "No description", date is not null ? date.Value : File.GetLastWriteTime(tarPath), thumb));
				}

				return saves;
            }
		}

		public World(string name, string path, string gamemode, MemoryStream thumb)
		{
			Name = name;
			Path = path;
			Gamemode = gamemode;
			Thumb = thumb;
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

				foreach (var world in worldFolders) {
					string thumbFilePath = System.IO.Path.Combine(world, ThumbName);
					var thumb = new MemoryStream();

					if (File.Exists(thumbFilePath)) {
						using var fs = new FileStream(thumbFilePath, FileMode.Open);

						fs.CopyTo(thumb);
						thumb.Position = 0;
					}
					
					worlds.Add(new(System.IO.Path.GetFileName(world), world, System.IO.Path.GetFileName(gamemodeFolder), thumb));
				}
			}

			return worlds;
		}
	}
}
