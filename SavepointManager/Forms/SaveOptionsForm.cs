using NHotkey;
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
	public partial class SaveOptionsForm : Form
	{
		public SaveOptionsForm()
		{
			InitializeComponent();

			var keys = Enum.GetNames(typeof(Keys));

			for (int i = 0; i < keys.Length; i++)
			{
				saveHotkeys.Items.Add(keys[i]);
				abortSaveHotkeys.Items.Add(keys[i]);
			}

			if (Directory.Exists(Save.BackupPath))
				folderBrowser.InitialDirectory = Save.BackupPath;

			backupPath.Text = Save.BackupPath;
			useCompression.Checked = Settings.Default.UseCompression;
			useSaveSounds.Checked = Settings.Default.UseSaveSounds;
			soundVolume.Enabled = previewButton.Enabled = useSaveSounds.Checked;
			soundVolume.Value = Settings.Default.SoundVolume;
			saveHotkeys.Text = Settings.Default.SaveHotkey;
			abortSaveHotkeys.Text = Settings.Default.AbortSaveHotkey;
			autosaveInterval.Text = Settings.Default.AutosaveInterval.ToString();
			enableAutosave.Checked = autosaveInterval.Enabled = Settings.Default.EnableAutosave;

			soundVolume_ValueChanged(this, EventArgs.Empty);
		}

		private void useSaveSounds_CheckedChanged(object sender, EventArgs e)
			=> soundVolume.Enabled = previewButton.Enabled = useSaveSounds.Checked;

		private void enableAutosave_CheckedChanged(object sender, EventArgs e)
			=> autosaveInterval.Enabled = enableAutosave.Checked;

		private void previewButton_Click(object sender, EventArgs e)
			=> SoundPlayer.Shared.Play(SoundEffect.SaveComplete, soundVolume.Value);

		private void soundVolume_ValueChanged(object sender, EventArgs e)
			=> soundVolumeLabel.Text = soundVolume.Value.ToString() + "%";

		private void browseButton_Click(object sender, EventArgs e)
		{
			folderBrowser.InitialDirectory = Directory.Exists(backupPath.Text) ? backupPath.Text : "";
			var result = folderBrowser.ShowDialog(this);

			if (result == DialogResult.OK)
				backupPath.Text = folderBrowser.SelectedPath;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			if (enableAutosave.Checked && (!int.TryParse(autosaveInterval.Text, out int interval) || interval <= 0))
			{
				MessageBoxManager.ShowError("The auto-save interval must be greater than zero.");
				return;
			}

			if (soundVolume.Value == 0 && !MessageBoxManager.ShowConfirmation("The sound volume is set to zero. Would you like to continue anyway?", "Sound Volume Confirmation"))
				return;

			var saveKey = SaveHelper.GetKeyFromString(saveHotkeys.Text);
			var abortKey = SaveHelper.GetKeyFromString(abortSaveHotkeys.Text);

			if (saveKey.IsErroneous || abortKey.IsErroneous)
			{
				MessageBoxManager.ShowError("One of the selected hotkeys is invalid. Please select another one.");
				return;
			}

			SaveHelper.UnbindAll();

			if (saveKey.Key is not null && saveKey.Key != Keys.None && !SaveHelper.IsHotkeyAvailable(saveKey.Key.Value))
			{
				MessageBoxManager.ShowError($"The specified hotkey for manual save ({saveKey.Key.Value}) could not be registered, probably because it's already in use by another process. Please select another one.");
				return;
			}

			if (abortKey.Key is not null && abortKey.Key != Keys.None && !SaveHelper.IsHotkeyAvailable(abortKey.Key.Value))
			{
				MessageBoxManager.ShowError($"The specified hotkey for aborting saves ({abortKey.Key.Value}) could not be registered, probably because it's already in use by another process. Please select another one.");
				return;
			}

			if (saveKey.Key is not null && abortKey.Key is not null && saveKey.Key.Value == abortKey.Key.Value)
			{
				MessageBoxManager.ShowError("The 'manual save' and 'abort save' hotkeys are the same. Please make sure they are different from each other.");
				return;
			}

			if (new DriveInfo(Save.BackupPath).AvailableFreeSpace < )

			if (!Directory.Exists(backupPath.Text))
			{
				try
				{
					Directory.CreateDirectory(backupPath.Text);
				}
				catch (Exception ex)
				{
					Logger.Log($"Could not create the save backup directory at {Save.BackupPath}", ex);
					MessageBoxManager.ShowError("The selected save backup path could not be created automatically. Please select another path.");

					return;
				}
			}

			if (backupPath.Text != Settings.Default.SavePath && Directory.Exists(Settings.Default.SavePath))  // If the user has changed the backup path
			{
				using var form = new SaveRelocationProgressForm()
				{
					OldPath = Settings.Default.SavePath,
					NewPath = backupPath.Text
				};

				if (form.ShowDialog() != DialogResult.OK && MessageBoxManager.ShowConfirmation($"Some backup folders could not be moved to the new backup path automatically. These folders have to be moved manually in order to be recognized by the program later. Would you like to browse and move the folders yourself now?\n\nError message: {form.ErrorMessage}", "Backup Path Error", MessageBoxIcon.Error, true))
					FileExplorer.Browse(Settings.Default.SavePath);
			}

			Settings.Default.SavePath = backupPath.Text;
			Settings.Default.UseCompression = useCompression.Checked;
			Settings.Default.UseSaveSounds = useSaveSounds.Checked;
			Settings.Default.SoundVolume = soundVolume.Value;
			Settings.Default.SaveHotkey = saveHotkeys.Text;
			Settings.Default.AbortSaveHotkey = abortSaveHotkeys.Text;
			Settings.Default.EnableAutosave = enableAutosave.Checked;
			Settings.Default.AutosaveInterval = enableAutosave.Checked ? int.Parse(autosaveInterval.Text) : SaveHelper.DefaultAutosaveInterval;

			Settings.Default.Save();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			backupPath.Text = Save.DefaultBackupPath;
			useCompression.Checked = false;
			useSaveSounds.Checked = true;
			soundVolume.Value = 80;
			saveHotkeys.Text = Keys.F5.ToString();
			abortSaveHotkeys.Text = Keys.F6.ToString();
			enableAutosave.Checked = true;
			autosaveInterval.Text = SaveHelper.DefaultAutosaveInterval.ToString();
		}
	}
}
