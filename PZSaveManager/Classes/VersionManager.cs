using System.Reflection;
using System.Xml.Linq;

namespace PZSaveManager.Classes
{
	public static class VersionManager
	{
		public static readonly DateTime BuildDate = new(2025, 9, 23);

		public static readonly Version ApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version!;
		public static readonly string ApplicationVersionText = ApplicationVersion.ToString(3);

		private static readonly Version XmlMetadataVersion = new(1, 0);
		public static readonly string XmlMetadataVersionText = XmlMetadataVersion.ToString(2);

		public const string RepoUrl = "https://github.com/Wirmaple73/PZSaveManager";

		public const string IssueReportUrl	 = RepoUrl + "/issues/new/choose";
        public const string FeedbackUrl		 = RepoUrl + "/discussions";
        public const string LatestReleaseUrl = RepoUrl + "/releases/latest";

        private const string VersionFileUrl = "https://raw.githubusercontent.com/Wirmaple73/PZSaveManager/master/LatestVersion.xml";
        public static async Task<(Version LatestVersion, DateTime ReleaseDate, string? Changelog)> GetLatestVersionInfo()
		{
			using var hc = new HttpClient();
			using var response = await hc.GetAsync(VersionFileUrl);

			response.EnsureSuccessStatusCode();

			var document = await XDocument.LoadAsync(await response.Content.ReadAsStreamAsync(), LoadOptions.PreserveWhitespace, CancellationToken.None);

            return (
				LatestVersion: new(document.Element(XmlElementName.Version.LatestVersion)!.Value),
				ReleaseDate: DateTime.Parse(document.Element(XmlElementName.Version.ReleaseDate)!.Value),
                Changelog: document.Element(XmlElementName.Version.Changelog)!.Value
			);
		}
	}
}
