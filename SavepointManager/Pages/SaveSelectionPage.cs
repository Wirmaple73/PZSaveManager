using SavepointManager.Classes;
using SavepointManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavepointManager.Forms
{
	public partial class SaveSelectionPage : UserControl
	{
		public List<World> Worlds { get; private set; } = new List<World>();
		public Button NextButton => nextButton;

		private readonly System.Windows.Forms.Timer refreshSaveListTimer = new() { Interval = 2000 };

		public SaveSelectionPage()
		{
			InitializeComponent();
			UpdateSaveList();

			refreshSaveListTimer.Tick += (object? sender, EventArgs e) => UpdateSaveList();
			refreshSaveListTimer.Start();

			errorLabel.Visible = false;
			errorLabelIcon.Image = SystemIcons.Error.ToBitmap();
		}

		private void UpdateSaveList()
		{
			try
			{
				Worlds = World.FetchAll();
			}
			catch (DirectoryNotFoundException ex)
			{
				errorLabel.Text = $"{ex.Message}\nIf this is not the case, please run the game and create a world first.";
				ClearWorldList();
				return;
			}

			if (Worlds.Count == 0)
			{
				errorLabel.Text = "Project Zomboid is installed, but no world has been created yet.\nPlease run the game and create a world first.";
				ClearWorldList();
				return;
			}

			errorLabel.Text = "";

			if (worldList.Items.Count == 0)
			{
				FillWorldList();
				return;
			}

			if (worldList.Items.Count == Worlds.Count && !DoesListNeedRefill())
			{
				for (int i = 0; i < worldList.Items.Count; i++)
					worldList.Items[i].SubItems[2].Text = Worlds[i].IsActive ? "Yes" : "No";
			}
			else
			{
				ClearWorldList();
				FillWorldList();
			}

			void ClearWorldList()
			{
				worldList.Items.Clear();
				worldPreview.Image = null;
			}

			void FillWorldList()
			{
				foreach (var world in Worlds)
					worldList.Items.Add(new ListViewItem(new[] { world.Title, world.Gamemode, world.IsActive ? "Yes" : "No" }));

				worldList.Items[0].Selected = true;
			}

			bool DoesListNeedRefill()
			{
				for (int i = 0; i < worldList.Items.Count; i++)
				{
					if (worldList.Items[i].SubItems[0].Text != Worlds[i].Title)
						return true;
				}

				return false;
			}
		}

		private void saveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (worldList.SelectedIndices.Count == 0)
			{
				worldPreview.Image = null;
				return;
			}

			var selectedWorld = Worlds.Find(world => world.Title == worldList.SelectedItems[0].Text);

			if (selectedWorld is not null && File.Exists(selectedWorld.ThumbPath))
				worldPreview.ImageLocation = selectedWorld.ThumbPath;
			else
				worldPreview.Image = Resources.InvalidWorld;
		}

		private void errorLabel_TextChanged(object sender, EventArgs e)
			=> errorLabel.Visible = errorLabelIcon.Visible = errorLabel.Text.Length > 0;

		private void worldList_DoubleClick(object sender, EventArgs e) => nextButton.PerformClick();
	}
}
