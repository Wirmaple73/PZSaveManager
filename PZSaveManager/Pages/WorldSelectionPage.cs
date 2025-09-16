using PZSaveManager.Classes;
using PZSaveManager.Properties;
using System.ComponentModel;

namespace PZSaveManager.Forms
{
	public partial class WorldSelectionPage : UserControl, IPage
	{
		public World? SelectedWorld => worldList.SelectedIndices.Count > 0 ? worldList.SelectedItems[0].Tag as World : null;
		public Button NextButton => nextButton;

		public WorldSelectionPage()
		{
			InitializeComponent();
			errorLabelIcon.Image = SystemIcons.Asterisk.ToBitmap();
		}

		public void PageLoaded() => UpdateUI();

		public void UpdateUI()
		{
			World.CreateMissingWorlds();
			var worlds = World.GetAllWorlds();

			worldList.Items.Clear();
			saveList_SelectedIndexChanged(this, EventArgs.Empty);

			try
			{
				if (!worlds.Any())
				{
					Logger.Log("No worlds have been found.", LogSeverity.Info);

					errorLabel.Text = "Project Zomboid is installed, but no world has been created yet. Please run the game and create a world first.";
					return;
				}
			}
			catch (DirectoryNotFoundException ex)
			{
				Logger.Log("No worlds have been found", ex);

				errorLabel.Text = $"{ex.Message} If this is not the case, please run the game and create a world first.";
				totalDiskUsageLabel.Visible = actualTotalDiskUsage.Visible = false;
				return;
			}

			errorLabel.Text = "";
			worldList.BeginUpdate();

			foreach (World world in worlds)
				worldList.Items.Add(new ListViewItem(new[] { world.Name, world.Gamemode, world.IsActive ? "Yes" : "No", world.LastActive.ToString() }) { Tag = world });

			if (worldList.Items.Count > 0)
				worldList.Items[0].Selected = true;

			worldList.Focus();
			worldList.EndUpdate();

			saveList_SelectedIndexChanged(this, EventArgs.Empty);

			if (Directory.Exists(Save.BackupPath))
			{
				actualTotalDiskUsage.Text = $"{Save.DiskInfo.TotalOccupiedSaveSize / 1e+9:f1} GB ({Save.DiskInfo.AvailableDiskSpace / 1e+9:f1} GB free on disk)";
				totalDiskUsageLabel.Visible = actualTotalDiskUsage.Visible = true;
			}
			else
			{
				totalDiskUsageLabel.Visible = actualTotalDiskUsage.Visible = false;
			}
		}

		//public void GlobalKeyDown(Keys keys)
		//{
		//	EventHandler? handler = keys switch
		//	{
		//		Keys.F5 => refreshListButton_Click,
		//		Keys.Delete => deleteWorldButton_Click,
		//		_ => null
		//	};

		//	handler?.Invoke(this, EventArgs.Empty);
		//}

		private void saveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			worldPreview.Image = Resources.NoPreview;

			if (SelectedWorld is null)
			{
				nextButton.Enabled = deleteWorldButton.Enabled = false;
				return;
			}

			nextButton.Enabled = deleteWorldButton.Enabled = true;

			if (SelectedWorld is not null)
			{
				string thumbPath = Path.Combine(SelectedWorld.Path!, World.ThumbName);

				if (File.Exists(thumbPath))
					worldPreview.ImageLocation = thumbPath;
			}
		}

		private void errorLabel_TextChanged(object sender, EventArgs e)
			=> errorLabel.Visible = errorLabelIcon.Visible = errorLabel.Text.Length > 0;

		private void worldList_DoubleClick(object sender, EventArgs e) => nextButton.PerformClick();
		private void refreshListButton_Click(object? sender, EventArgs e) => UpdateUI();

		private void deleteWorldButton_Click(object? sender, EventArgs e)
		{
			if (SelectedWorld is null)
				return;

			using var form = new WorldDeletionConfirmationForm() { Subject = SelectedWorld };

			if (form.ShowDialog() == DialogResult.OK)
				UpdateUI();
		}

		private void listContextMenu_Opening(object sender, CancelEventArgs e)
			=> deleteToolStripMenuItem.Enabled = SelectedWorld is not null;
	}
}
