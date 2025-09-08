namespace PZSaveManager.Classes
{
	public static class VersionManager
	{
		public static readonly Version CurrentVersion = new(Application.ProductVersion);

		public const string RepoUrl = "https://github.com/Wirmaple73/PZSaveManager";
		private const string VersionFilename = RepoUrl + "/CurrentVersion.txt";

		public static async Task<Version> GetLatestVersion()
		{
			using var hc = new HttpClient();
			using var response = await hc.GetAsync(VersionFilename);

			response.EnsureSuccessStatusCode();
			return new(await response.Content.ReadAsStringAsync());
		}
	}
}
