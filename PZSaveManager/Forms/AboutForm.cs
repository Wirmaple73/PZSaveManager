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

			versionLabel.Text = "Version " + VersionManager.CurrentVersion.ToString();
		}

		private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> FileExplorer.Browse(githubLink.Text);
	}
}
