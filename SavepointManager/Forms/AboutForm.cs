using SavepointManager.Classes;

namespace SavepointManager.Forms
{
	public partial class AboutForm : Form
	{
		public AboutForm() => InitializeComponent();

		private void AboutForm_Load(object sender, EventArgs e)
			=> versionLabel.Text = "Version " + VersionManager.CurrentVersion.ToString();

		private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
			=> FileExplorer.Browse(githubLink.Text);
	}
}
