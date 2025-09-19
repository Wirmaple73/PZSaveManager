using PZSaveManager.Classes;

namespace PZSaveManager.Forms
{
	public partial class AboutForm : Form
	{
		private const int MaxIconSize = 256;

		public AboutForm() => InitializeComponent();

		private void AboutForm_Load(object sender, EventArgs e)
		{
			using (var icon = new Icon(Properties.Resources.Icon, new(MaxIconSize, MaxIconSize)))
				appIcon.Image = icon.ToBitmap();

			versionLabel.Text = $"Version {VersionManager.VersionText} (2025/09/19)";
		}

		private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> FileExplorer.Browse(githubLink.Text);

		private void licenseLink_Click(object sender, EventArgs e)
			=> FileExplorer.Browse("https://github.com/Wirmaple73/PZSaveManager/blob/main/LICENSE");
	}
}
