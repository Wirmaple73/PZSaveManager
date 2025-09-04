using SavepointManager.Classes;
using SavepointManager.Forms;
using SavepointManager.Properties;
using SharpCompress.Common;
using System.ComponentModel;
using System.Diagnostics;
using System.Media;

namespace SavepointManager.Pages
{
	public partial class SaveSelectionPage : UserControl, IPage
	{
		public World? SelectedWorld { get; set; }
		public Button BackButton => backButton;

		private Save? SelectedSave => saveList.SelectedIndices.Count > 0 ? saveList.SelectedItems[0].Tag as Save : null;
		private string SaveInfo => $"Save date: {SelectedSave!.Date}\nDescription: {SelectedSave.Description}";

		public SaveSelectionPage()
		{
			InitializeComponent();
			saveLabelIcon.Image = SystemIcons.Asterisk.ToBitmap();
		}

		public void PageLoaded()
		{
			worldName.Text = SelectedWorld?.Name ?? "Unknown world";

			SetSaveButtonsEnabled(false);
			UpdateUI();
		}

		public void UpdateUI()
		{
			var lastSelectedSave = SelectedSave;

			saveList.Items.Clear();
			savePreview.Image = Resources.NoPreview;

			if (SelectedWorld is null)
				return;

			foreach (Save save in SelectedWorld.GetSaves())
				saveList.Items.Add(new ListViewItem(new[] { save.Description, save.Date.ToString() }) { Tag = save });

            if (saveList.Items.Count > 0)
			{
				SelectLastSelectedSave();

				saveLabel.Visible = saveLabelIcon.Visible = false;
				SetSaveButtonsEnabled(true);
			}
			else
			{
				saveLabel.Visible = saveLabelIcon.Visible = true;
				SetSaveButtonsEnabled(false);
			}

			long totalBytes = Save.DiskInfo.GetOccupiedSaveSize(SelectedWorld);
			diskUsage.Text = (totalBytes < 1e+9 ? $"{totalBytes / 1e+6:f1} MB" : $"{totalBytes / 1e+9:f1} GB") + $" ({Save.DiskInfo.AvailableDiskSpace / 1e+9:f1} GB free on disk)";
		
		
			void SelectLastSelectedSave()
			{
				if (lastSelectedSave is null)
					return;

				for (int i = 0; i < saveList.Items.Count; i++)
				{
					if (saveList.Items[i].Tag is Save s && s.ArchivePath == lastSelectedSave.ArchivePath)
					{
						saveList.Items[i].Selected = true;
						saveList.EnsureVisible(i);

						break;
					}
				}
			}
		}

		private void saveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (SelectedSave is null)
			{
				SetSaveButtonsEnabled(false);
				savePreview.Image = Resources.NoPreview;
				return;
			}

			SetSaveButtonsEnabled(true);

			try
			{
				savePreview.Image = SelectedSave.Thumb is not null && SelectedSave.Thumb.Length > 0 ?
					Image.FromStream(SelectedSave.Thumb) : Resources.NoPreview;
			}
			catch (Exception ex)
			{
				savePreview.Image = Resources.NoPreview;
				Logger.Log("Could not open save thumb", ex);
			}
		}

		private void refreshListButton_Click(object? sender, EventArgs e) => UpdateUI();

		private void newSaveButton_Click(object? sender, EventArgs e)
		{
			using var saveNameForm = new SaveNameForm() { Text = "New Save" };

			if (Save.IsSaveInProgress)
			{
				ShowSaveInProgressError();
				return;
			}

			if (saveNameForm.ShowDialog() != DialogResult.OK)
				return;

			string description = saveNameForm.SaveDescription is not null && saveNameForm.SaveDescription.Length > 0 ?
				saveNameForm.SaveDescription : Save.ExternalSaveDescription;

			using var progressForm = new SavingProgressForm() { Save = new(SelectedWorld!, description) };

			if (Save.IsSaveInProgress)
			{
				ShowSaveInProgressError();
				return;
			}

			if (progressForm.ShowDialog() == DialogResult.OK)
			{
				WindowHelper.FlashIfMinimized();
				UpdateUI();
			}
			else
			{
				MessageBoxManager.ShowError($"The save could not be exported.\n\nError message: {progressForm.ErrorMessage}");
			}
		}

		private void restoreSaveButton_Click(object? sender, EventArgs e)
		{
			if (SelectedWorld is null || SelectedSave is null || SelectedSave.AssociatedWorld is null)
				return;

			if (SelectedWorld.IsActive)
			{
				MessageBoxManager.ShowError("The world is currently actively loaded by the game. Please quit to the main menu in-game and try again.");
				return;
			}

			if (!MessageBoxManager.ShowConfirmation($"Are you sure you want to restore the world {SelectedWorld.Name} back to the following save? ALL CURRENT UNSAVED PROGRESS WILL BE LOST!\n\n{SaveInfo}", "Save Restoration Confirmation"))
				return;

			var progressForm = new RestorationProgressForm { SelectedSave = this.SelectedSave };

			var result = progressForm.ShowDialog();
			WindowHelper.FlashIfMinimized();

			if (result == DialogResult.OK)
			{
				string message = $"The world {SelectedWorld.Name} has been successfully restored to {SelectedSave.Date:G}.";

				if (!progressForm.IsRedundantBackupDeleted!.Value)
					message += "\nThe temporary world backup could not be deleted automatically. It may still be safely deleted manually.";

				MessageBoxManager.ShowInfo(message, "Success");
			}
			else
			{
				string message = $"An error occured while trying to restore the save: {progressForm.ErrorMessage}\n\n";

				if (progressForm.IsOriginalWorldRestored!.Value)
				{
					message += "Your current unsaved progress has been successfully recovered. No further action is needed.";
					MessageBoxManager.ShowError(message);
				}
				else
				{
					message += $"Your current unsaved progress was previously backed up and now is safe, but couldn't be restored automatically. It has been saved at '{SelectedSave.AssociatedWorld.BackupPath}' and is playable in-game. You can safely rename it back to {SelectedSave.AssociatedWorld.Name} if you want to. Would you like to do so now?";

					if (MessageBoxManager.ShowConfirmation(message, "Browse Save Confirmation"))
						FileExplorer.Browse(SelectedSave.AssociatedWorld.GamemodePath);
				}
			}
		}

		private async void renameSaveButton_Click(object? sender, EventArgs e)
		{
			if (SelectedSave is null)
				return;

			using var saveNameForm = new SaveNameForm() { Text = "Rename Save", SaveDescription = SelectedSave.Description };

			if (saveNameForm.ShowDialog() == DialogResult.OK)
			{
				try
				{
					await SelectedSave.RenameAsync(saveNameForm.SaveDescription.Length > 0 ? saveNameForm.SaveDescription : Save.UnnamedSaveDescription);
					UpdateUI();
				}
				catch (Exception ex)
				{
					Logger.Log("Could not rename the selected save", ex);
					MessageBoxManager.ShowError($"The selected save could not be renamed.\nError message: {ex.Message}");
				}
			}
		}

		private async void deleteSaveButton_Click(object? sender, EventArgs e)
		{
			if (SelectedSave is null)
				return;

			if (!MessageBoxManager.ShowConfirmation($"Are you sure you want to delete the following save?\nThis action cannot be undone!\n\n{SaveInfo}", "Save Deletion Confirmation"))
				return;

			try
			{
				await SelectedSave.DeleteAsync();
				UpdateUI();
			}
			catch (Exception ex)
			{
				Logger.Log("The selected save could not be deleted", ex);
				MessageBoxManager.ShowError($"The selected save could not be deleted.\nError message: {ex.Message}");
			}
		}

		private void SetSaveButtonsEnabled(bool value) => restoreSaveButton.Enabled = renameSaveButton.Enabled = deleteSaveButton.Enabled = value;

		private static void ShowSaveInProgressError() => MessageBoxManager.ShowError("Another save process is already in progress. Please wait until it is completed.");

		private void listContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
			=> restoreToolStripMenuItem.Enabled = renameToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = SelectedSave is not null;

		private void saveList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.N)
				e.IsInputKey = true;
		}
	}
}
