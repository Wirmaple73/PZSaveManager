using System.Reflection;

namespace PZSaveManager.Classes
{
	public static class VersionManager
	{
		public static readonly DateTime BuildDate = new(2025, 9, 21);

		public static readonly Version CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version!;
		public static readonly string VersionText = CurrentVersion.ToString(3);

		private static readonly Version XmlMetadataVersion = new(1, 0);
		public static readonly string XmlMetadataVersionText = XmlMetadataVersion.ToString(2);

		public const string RepoUrl = "https://github.com/Wirmaple73/PZSaveManager";

		public const string IssueReportUrl = RepoUrl + "/issues/new/choose";
        public const string FeedbackUrl = RepoUrl + "/discussions";

        private const string VersionFileUrl = "https://raw.githubusercontent.com/Wirmaple73/PZSaveManager/master/CurrentVersion.txt";

        public static async Task<Version> GetLatestVersion()
		{
			using var hc = new HttpClient();
			using var response = await hc.GetAsync(VersionFileUrl);

			response.EnsureSuccessStatusCode();
			return new(await response.Content.ReadAsStringAsync());
		}
	}
}
