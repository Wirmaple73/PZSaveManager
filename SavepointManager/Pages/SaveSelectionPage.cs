using SavepointManager.Classes;
using SavepointManager.Forms;
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

namespace SavepointManager.Pages
{
	public partial class SaveSelectionPage : UserControl
	{
		private World? selectedWorld;
		private List<Save> saves = new();

		public World? SelectedWorld
		{
			get => selectedWorld;
			set
			{
				selectedWorld = value;

				if (value is not null)
				{
					RefillSaveList();
					worldName.Text = value.Name;
				}
				else
				{
					saveList.Items.Clear();
				}
			}
		}

		private Save? SelectedSave => saves.FirstOrDefault(s =>
			s.Description == saveList.SelectedItems[0].Text && s.Date == DateTime.Parse(saveList.SelectedItems[0].SubItems[1].Text)
		);

		private string SaveInfo => $"  Save date: {SelectedSave!.Date}\n  Description: {SelectedSave.Description}";

		public Button BackButton => backButton;

		public SaveSelectionPage()
		{
			InitializeComponent();
		}

		private void RefillSaveList()
		{
			saves = SelectedWorld!.Saves;
			saves.Reverse();  // Reverse to sort saves by newest date

			if (saveList.Items.Count == saves.Count)
				return;

			saveList.Items.Clear();
			savePreview.Image = null;

			foreach (var save in saves)
				saveList.Items.Add(new ListViewItem(new[] { save.Description, save.Date.ToString("G") }));

			if (saveList.Items.Count > 0)
				saveList.Items[0].Selected = true;

			saveList.Focus();
		}

		private void saveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (saveList.SelectedIndices.Count == 0 || SelectedSave is null)
			{
				savePreview.Image = null;
				return;
			}

			savePreview.Image = SelectedSave.Thumb is not null && SelectedSave.Thumb.Length > 0 ?
				Image.FromStream(SelectedSave.Thumb) : Resources.InvalidWorld;
		}

		private void newSavepoint_Click(object sender, EventArgs e)
		{
			var newSaveForm = new NewSaveForm();

			if (newSaveForm.ShowDialog() != DialogResult.OK)
				return;

			var progressForm = new ArchiveProgressForm();
			string saveTitle = newSaveForm.SaveTitle is not null && newSaveForm.SaveTitle.Length > 0 ? newSaveForm.SaveTitle : "Manual save";

			progressForm.Save = new Save(SelectedWorld!, null, saveTitle, DateTime.Now, new MemoryStream());
			progressForm.ShowDialog();

			if (progressForm.DialogResult == DialogResult.OK)
				RefillSaveList();
		}

		private void restoreSaveButton_Click(object sender, EventArgs e)
		{
			if (saveList.SelectedIndices.Count == 0 || SelectedSave is null)
				return;

			if (SelectedSave.AssociatedWorld.IsActive)
			{
				MessageBoxManager.ShowError("The world is currently actively loaded by the game. Please quit to the main menu in-game and try again.");
				return;
			}

			if (MessageBoxManager.ShowPrompt($"Are you sure you want to restore the world {SelectedWorld!.Name} back to the following save? All current unsaved progress will be lost!\n\n{SaveInfo}", "Save Restoration Confirmation") != DialogResult.Yes)
				return;


		}

		private void deleteSaveButton_Click(object sender, EventArgs e)
		{
			if (saveList.SelectedIndices.Count == 0 || SelectedSave is null)
				return;

			if (MessageBoxManager.ShowPrompt($"Are you sure you want to delete the following save?\nThis action cannot be undone!\n\n{SaveInfo}", "Save Deletion Confirmation") != DialogResult.Yes)
				return;

			try
			{
				File.Delete(SelectedSave.ArchivePath!);
				RefillSaveList();
			}
			catch
			{
				MessageBoxManager.ShowError("The specified save could not be deleted. It may still be deleted manually.");
			}
		}
	}
}
