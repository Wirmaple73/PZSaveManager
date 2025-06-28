using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public class World
	{
		private static readonly string BaseDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Zomboid");
		private static readonly string SaveDirectory = Path.Combine(BaseDirectory, "Saves");
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

		public static bool DoesDirectoryExist => Directory.Exists(SaveDirectory);

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

			if (!Directory.Exists(SaveDirectory))
				throw new DirectoryNotFoundException("Project Zomboid is installed, but the save folder could not be located.");

			var worlds = new List<World>();
			var gamemodes = Directory.GetDirectories(SaveDirectory);

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
