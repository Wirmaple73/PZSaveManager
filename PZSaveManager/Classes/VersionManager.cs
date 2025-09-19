namespace PZSaveManager.Classes
{
	public static class VersionManager
	{
		public static readonly Version CurrentVersion = new(Application.ProductVersion);
		public static readonly string VersionText = CurrentVersion.ToString(3);

		private static readonly Version XmlMetadataVersion = new(1, 0);
		public static readonly string XmlMetadataVersionText = XmlMetadataVersion.ToString(2);

		public const string RepoUrl = "https://github.com/Wirmaple73/PZSaveManager";
		private const string VersionFileUrl = RepoUrl + "/CurrentVersion.txt";

		public static async Task<Version> GetLatestVersion()
		{
			using var hc = new HttpClient();
			using var response = await hc.GetAsync(VersionFileUrl);

			response.EnsureSuccessStatusCode();
			return new(await response.Content.ReadAsStringAsync());
		}
	}
}
