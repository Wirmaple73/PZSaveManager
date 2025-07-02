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
	public partial class WorldSelectionPage : UserControl
	{
		private readonly System.Windows.Forms.Timer RefreshSaveListTimer = new() { Interval = 2000 };

		private List<World> Worlds { get; set; } = new();

		public bool IsRefreshTimerEnabled
		{
			get => RefreshSaveListTimer.Enabled;
			set => RefreshSaveListTimer.Enabled = value;
		}

		public World? SelectedWorld => Worlds.Find(world => world.Name == worldList.SelectedItems[0].Text);
		public Button NextButton => nextButton;

		public WorldSelectionPage()
		{
			InitializeComponent();
			UpdateSaveList();

			RefreshSaveListTimer.Tick += (object? sender, EventArgs e) => UpdateSaveList();
			RefreshSaveListTimer.Start();

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
					worldList.Items.Add(new ListViewItem(new[] { world.Name, world.Gamemode, world.IsActive ? "Yes" : "No" }));

				worldList.Items[0].Selected = true;
			}

			bool DoesListNeedRefill()
			{
				for (int i = 0; i < worldList.Items.Count; i++)
				{
					if (worldList.Items[i].SubItems[0].Text != Worlds[i].Name)
						return true;
				}

				return false;
			}
		}

		private void saveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (worldList.SelectedIndices.Count == 0)
			{
				nextButton.Enabled = false;
				worldPreview.Image = null;
				return;
			}

			worldPreview.Image = SelectedWorld is not null && SelectedWorld.Thumb is not null && SelectedWorld.Thumb.Length > 0
				? Image.FromStream(SelectedWorld.Thumb) : Resources.InvalidWorld;

			nextButton.Enabled = true;
		}

		private void errorLabel_TextChanged(object sender, EventArgs e)
			=> errorLabel.Visible = errorLabelIcon.Visible = errorLabel.Text.Length > 0;

		private void worldList_DoubleClick(object sender, EventArgs e) => nextButton.PerformClick();
	}
}
