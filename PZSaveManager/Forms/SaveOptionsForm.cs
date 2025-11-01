using System.Diagnostics;
using PZSaveManager.Classes;
using PZSaveManager.Properties;

namespace PZSaveManager.Forms
{
    public partial class SaveOptionsForm : Form
    {
        public SaveOptionsForm() => InitializeComponent();

        private void SaveOptionsForm_Shown(object sender, EventArgs e)
        {
            if (Directory.Exists(Save.BackupPath))
                backupPathBrowser.InitialDirectory = Save.BackupPath;

            duserPath.Text = duserPathBrowser.InitialDirectory = Directory.Exists(Settings.Default.DuserPath) ? Settings.Default.DuserPath : World.DefaultDuserPath;
            backupPath.Text = Save.BackupPath;
            useCompression.Checked = Settings.Default.UseCompression;
            useSaveSounds.Checked = Settings.Default.UseSaveSounds;
            soundVolume.Enabled = previewButton.Enabled = useSaveSounds.Checked;
            soundVolume.Value = Settings.Default.SoundVolume;
            saveHotkey.Text = Settings.Default.SaveHotkey;
            abortSaveHotkey.Text = Settings.Default.AbortSaveHotkey;
            autosaveInterval.Text = Settings.Default.AutosaveInterval.ToString();
            enableAutosave.Checked = autosaveInterval.Enabled = Settings.Default.EnableAutosave;

            warningIcon.Image = SystemIcons.Warning.ToBitmap();
            soundVolume_ValueChanged(this, EventArgs.Empty);

            SaveHelper.Hotkeys.UnbindAll();  // Used to prevent current hotkeys from being unselectable
        }

        private void useSaveSounds_CheckedChanged(object sender, EventArgs e)
            => soundVolume.Enabled = previewButton.Enabled = useSaveSounds.Checked;

        private void enableAutosave_CheckedChanged(object sender, EventArgs e)
            => autosaveInterval.Enabled = enableAutosave.Checked;

        private void previewButton_Click(object sender, EventArgs e)
            => SoundPlayer.Shared.Play(SoundEffect.SaveComplete, soundVolume.Value);

        private void soundVolume_ValueChanged(object sender, EventArgs e)
            => soundVolumeLabel.Text = soundVolume.Value.ToString() + "%";

        private void browseBackupPathButton_Click(object sender, EventArgs e)
        {
            backupPathBrowser.InitialDirectory = Directory.Exists(backupPath.Text) ? backupPath.Text : "";
            var result = backupPathBrowser.ShowDialog(this);

            if (result == DialogResult.OK)
                backupPath.Text = backupPathBrowser.SelectedPath;
        }

        private void browseDuserPathButton_Click(object sender, EventArgs e)
        {
            duserPathBrowser.InitialDirectory = Directory.Exists(duserPath.Text) ? duserPath.Text : "";
            var result = duserPathBrowser.ShowDialog(this);

            if (result == DialogResult.OK)
                duserPath.Text = duserPathBrowser.SelectedPath;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int interval = 0;

            if (enableAutosave.Checked && (!int.TryParse(autosaveInterval.Text, out interval) || interval <= 0))
            {
                MessageBoxManager.ShowError("The auto-save interval must be greater than zero.");
                return;
            }

            if (soundVolume.Value == 0 && !MessageBoxManager.ShowConfirmation("The sound volume is set to zero. Would you like to continue anyway?", "Sound Volume Confirmation"))
                return;

            // Validate hotkeys
            var saveKey = SaveHelper.Hotkeys.GetKeyByString(saveHotkey.Text);
            var abortKey = SaveHelper.Hotkeys.GetKeyByString(abortSaveHotkey.Text);

            if (saveKey.IsErroneous || abortKey.IsErroneous)
            {
                MessageBoxManager.ShowError("One of the selected hotkeys is invalid. Please select another one.");
                return;
            }

            if (!ValidateHotkey(saveKey.Key, "manual save") || !ValidateHotkey(abortKey.Key, "cancelling saves"))
                return;

            if (saveKey.Key is not null && abortKey.Key is not null && saveKey.Key.Value == abortKey.Key.Value)
            {
                MessageBoxManager.ShowError("The 'manual save' and 'abort save' functions are binded to the same hotkey. Please ensure they are binded to different hotkeys.");
                return;
            }

            // Check for insufficient disk space
            const double Headroom = 64e+6;  // 64 MB
            double requiredDiskSpace = Save.DiskInfo.TotalOccupiedSaveSize + Headroom;

            var srcDrive = new DriveInfo(Save.BackupPath);
            var destDrive = new DriveInfo(backupPath.Text);

            if (srcDrive.Name != destDrive.Name && destDrive.AvailableFreeSpace < requiredDiskSpace)
            {
                MessageBoxManager.ShowError($"There is not enough disk space on the target drive ({destDrive.Name}). You need to choose a drive with at least {requiredDiskSpace / 1e+9:f1} GB of free space to relocate your saves.");
                return;
            }

            if (!Directory.Exists(backupPath.Text))
            {
                try
                {
                    Directory.CreateDirectory(backupPath.Text);
                }
                catch (Exception ex)
                {
                    Logger.Log($"Could not create the save backup directory at {backupPath.Text}", ex);
                    MessageBoxManager.ShowDetailedError("The selected save backup path could not be created automatically. Please select another path.", ex);

                    return;
                }
            }

            if (backupPath.Text != Save.BackupPath && Directory.Exists(Save.BackupPath))  // If the user has changed the backup path
            {
                using var form = new SaveRelocationProgressForm()
                {
                    OldPath = Save.BackupPath,
                    NewPath = backupPath.Text
                };

                var result = form.ShowDialog();
                WindowHelper.FlashIfMinimized();

                if (result != DialogResult.OK && MessageBoxManager.ShowConfirmation($"Some backup folders could not be moved to the new backup path automatically. These folders have to be moved manually in order to be recognized by the program later. Would you like to browse and move the folders yourself now?\n\nError message: {form.ErrorMessage}", "Backup Path Error", MessageBoxIcon.Error, true))
                    FileExplorer.Browse(Save.BackupPath);
            }

            Settings.Default.DuserPath = duserPath.Text;
            Settings.Default.SavePath = backupPath.Text;
            Settings.Default.UseCompression = useCompression.Checked;
            Settings.Default.UseSaveSounds = useSaveSounds.Checked;
            Settings.Default.SoundVolume = soundVolume.Value;
            Settings.Default.SaveHotkey = saveHotkey.Text;
            Settings.Default.AbortSaveHotkey = abortSaveHotkey.Text;
            Settings.Default.EnableAutosave = enableAutosave.Checked;
            Settings.Default.AutosaveInterval = enableAutosave.Checked ? interval : SaveHelper.DefaultAutosaveInterval;

            Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();


            static bool ValidateHotkey(Keys? hotkey, string hotkeyFunction)
            {
                if (hotkey is not null && hotkey != Keys.None && !SaveHelper.Hotkeys.IsHotkeyAvailable(hotkey.Value))
                {
                    MessageBoxManager.ShowError($"The specified hotkey for {hotkeyFunction} ({hotkey.Value}) could not be registered, probably because it's already in use by another process. Please select another one.");
                    return false;
                }

                return true;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            duserPath.Text = World.DefaultDuserPath;
            backupPath.Text = Path.Combine(World.DefaultDuserPath, "Backups");
            useCompression.Checked = false;
            useSaveSounds.Checked = true;
            soundVolume.Value = 50;
            saveHotkey.Text = (Keys.Control | Keys.F5).ToString();
            abortSaveHotkey.Text = (Keys.Control | Keys.F6).ToString();
            enableAutosave.Checked = false;
            autosaveInterval.Text = SaveHelper.DefaultAutosaveInterval.ToString();
        }

        private void saveHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            ((TextBox)sender).Text = e.KeyData.ToString();
            e.SuppressKeyPress = true;
        }

        private void clearSaveHotkeyButton_Click(object sender, EventArgs e) => saveHotkey.Text = Keys.None.ToString();
        private void clearAbortSaveHotkeyButton_Click(object sender, EventArgs e) => abortSaveHotkey.Text = Keys.None.ToString();
    }
}
