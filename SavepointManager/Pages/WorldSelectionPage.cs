using SavepointManager.Classes;
using SavepointManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavepointManager.Forms
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
			// TODO: Sort the ListView
			totalDiskUsage.Text = $"{Save.DiskInfo.TotalOccupiedSaveSize / 1e+9:f1} GB ({Save.DiskInfo.AvailableDiskSpace / 1e+9:f1} GB free on disk)";

			World.CreateMissingWorlds();
			IEnumerable<World> worlds;

			worldList.Items.Clear();
			saveList_SelectedIndexChanged(this, EventArgs.Empty);

			try
			{
				worlds = World.GetAllWorlds();
			}
			catch (DirectoryNotFoundException ex)
			{
				Logger.Log("No worlds have been found", ex);

				errorLabel.Text = $"{ex.Message} If this is not the case, please run the game and create a world first.";
				return;
			}

			if (!worlds.Any())
			{
				Logger.Log("No worlds have been found.", LogSeverity.Info);

				errorLabel.Text = "Project Zomboid is installed, but no world has been created yet. Please run the game and create a world first.";
				return;
			}

			errorLabel.Text = "";
			worldList.BeginUpdate();

			foreach (World world in worlds)
				worldList.Items.Add(new ListViewItem(new[] { world.Name, world.Gamemode, world.IsActive ? "Yes" : "No", world.LastPlayed.ToString() }) { Tag = world });

			if (worldList.Items.Count > 0)
				worldList.Items[0].Selected = true;

			worldList.Focus();
			worldList.EndUpdate();

			saveList_SelectedIndexChanged(this, EventArgs.Empty);
		}

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
		private void refreshListButton_Click(object sender, EventArgs e) => UpdateUI();

		private void deleteWorldButton_Click(object sender, EventArgs e)
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
