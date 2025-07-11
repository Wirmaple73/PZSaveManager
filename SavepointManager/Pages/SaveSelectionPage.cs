using SavepointManager.Classes;
using SavepointManager.Forms;
using SavepointManager.Properties;
using System.Globalization;
using System.Media;

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
				SetSaveButtonsEnabled(false);

				if (value is not null)
				{
					UpdateSaveList();
					worldName.Text = value.Name;
				}
				else
				{
					saveList.Items.Clear();
				}
			}
		}

		public Button BackButton => backButton;

		private Save? SelectedSave => saves.FirstOrDefault(s =>
			s.Description == saveList.SelectedItems[0].Text && s.Date == DateTime.Parse(saveList.SelectedItems[0].SubItems[1].Text)
		);

		private string SaveInfo => $"Save date: {SelectedSave!.Date}\nDescription: {SelectedSave.Description}";

		public SaveSelectionPage()
		{
			InitializeComponent();
			saveLabelIcon.Image = SystemIcons.Asterisk.ToBitmap();
		}

		private void UpdateSaveList(bool refillList = true)
		{
			saves = SelectedWorld!.Saves;
			saves.Reverse();  // Reversed to sort saves by newest date

			if (!refillList)
				return;

			saveList.Items.Clear();
			savePreview.Image = null;

			foreach (var save in saves)
				saveList.Items.Add(new ListViewItem(new[] { save.Description, save.Date.ToString() }));

			if (saveList.Items.Count > 0)
			{
				saveList.Items[0].Selected = true;
				saveLabel.Visible = saveLabelIcon.Visible = false;
			}
			else
			{
				saveLabel.Visible = saveLabelIcon.Visible = true;
			}

			saveList.Focus();
		}

		private void saveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (saveList.SelectedIndices.Count == 0 || SelectedSave is null)
			{
				SetSaveButtonsEnabled(false);
				savePreview.Image = null;
				return;
			}

			SetSaveButtonsEnabled(true);

			savePreview.Image = SelectedSave.Thumb is not null && SelectedSave.Thumb.Length > 0 ?
				Image.FromStream(SelectedSave.Thumb) : Resources.NoPreview;
		}

		private void refreshListButton_Click(object sender, EventArgs e) => UpdateSaveList();

		private void newSaveButton_Click(object sender, EventArgs e)
		{
			var newSaveForm = new NewSaveForm();

			if (Save.IsSaveInProgress)
			{
				ShowSaveInProgressError();
				return;
			}

			if (newSaveForm.ShowDialog() != DialogResult.OK)
				return;

			string description = newSaveForm.SaveDescription is not null && newSaveForm.SaveDescription.Length > 0 ?
				newSaveForm.SaveDescription : Save.ManualSaveDescription;

			var progressForm = new SavingProgressForm()
			{
				Save = new Save(SelectedWorld!, null, description, DateTime.Now, new MemoryStream())
			};

			if (Save.IsSaveInProgress)
			{
				ShowSaveInProgressError();
				return;
			}

			if (progressForm.ShowDialog() == DialogResult.OK)
			{
				if (!Window.IsInForeground())
					SystemSounds.Beep.Play();

				UpdateSaveList();
			}
			else
			{
				MessageBoxManager.ShowError($"The save could not be exported.\n\nError message: {progressForm.ErrorMessage}");
			}
		}

		private void restoreSaveButton_Click(object sender, EventArgs e)
		{
			UpdateSaveList(false);

			if (saveList.SelectedIndices.Count == 0 || SelectedWorld is null || SelectedSave is null)
				return;

			if (SelectedWorld.IsActive)
			{
				MessageBoxManager.ShowError("The world is currently actively loaded by the game. Please quit to the main menu in-game and try again.");
				return;
			}

			if (!MessageBoxManager.ShowConfirmation($"Are you sure you want to restore the world {SelectedWorld.Name} back to the following save? All current unsaved progress will be lost!\n\n{SaveInfo}", "Save Restoration Confirmation"))
				return;

			var progressForm = new RestorationProgressForm { SelectedSave = this.SelectedSave };

			if (progressForm.ShowDialog() == DialogResult.OK)
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
						FileExplorer.Browse(World.WorldDirectory);
				}
			}
		}

		private void deleteSaveButton_Click(object sender, EventArgs e)
		{
			if (saveList.SelectedIndices.Count == 0 || SelectedSave is null)
				return;

			if (!MessageBoxManager.ShowConfirmation($"Are you sure you want to delete the following save?\nThis action cannot be undone!\n\n{SaveInfo}", "Save Deletion Confirmation"))
				return;

			try
			{
				Directory.Delete(Directory.GetParent(SelectedSave.ArchivePath!)!.FullName, true);
				UpdateSaveList();
			}
			catch
			{
				MessageBoxManager.ShowError("The specified save could not be deleted. It may still be deleted manually.");
			}
		}

		private void SetSaveButtonsEnabled(bool value) => restoreSaveButton.Enabled = deleteSaveButton.Enabled = value;

		private void ShowSaveInProgressError() => MessageBoxManager.ShowError("Another save process is already in progress. Please wait until it is completed.");
	}
}
