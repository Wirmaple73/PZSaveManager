using System.Reflection;
using System.Xml.Linq;

namespace PZSaveManager.Classes
{
	public static class VersionManager
	{
		public static readonly DateTime BuildDate = new(2025, 11, 1);

		public static readonly Version ApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version!;
		public static readonly string ApplicationVersionText = ApplicationVersion.ToString(3);

		private static readonly Version XmlMetadataVersion = new(1, 0);
		public static readonly string XmlMetadataVersionText = XmlMetadataVersion.ToString(2);

		public const string RepoUrl = "https://github.com/Wirmaple73/PZSaveManager";

		public const string IssueReportUrl	 = RepoUrl + "/issues/new/choose";
        public const string FeedbackUrl		 = RepoUrl + "/discussions";
        public const string LatestReleaseUrl = RepoUrl + "/releases/latest";

        private const string VersionFileUrl = "https://raw.githubusercontent.com/Wirmaple73/PZSaveManager/master/LatestVersion.xml";

        public static async Task<(Version LatestVersion, DateTime ReleaseDate, string ReleaseNotes)> GetLatestVersionInfo()
		{
			using var hc = new HttpClient();
			using var response = await hc.GetAsync(VersionFileUrl);

			response.EnsureSuccessStatusCode();

			var root = (await XDocument.LoadAsync(await response.Content.ReadAsStreamAsync(), LoadOptions.PreserveWhitespace, CancellationToken.None)).Root!;
			
            return (
				LatestVersion: new(root.Element(XmlElementName.Version.LatestVersion)!.Value),
				ReleaseDate: DateTime.Parse(root.Element(XmlElementName.Version.ReleaseDate)!.Value),
                ReleaseNotes: root.Element(XmlElementName.Version.ReleaseNotes)!.Value
			);
		}
	}
}
