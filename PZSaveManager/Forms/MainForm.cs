using PZSaveManager.Classes;
using PZSaveManager.Pages;
using PZSaveManager.Properties;

namespace PZSaveManager.Forms
{
    public partial class MainForm : Form
    {
        private readonly WorldSelectionPage worldSelectionPage = new();
        private readonly SaveSelectionPage saveSelectionPage = new();

        public MainForm() => InitializeComponent();

        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitializeApplication();
            CheckForInsufficientDiskSpace();

            SaveHelper.UpdateAutosaveTimer();

            if (!SaveHelper.Hotkeys.UpdateAll() && MessageBoxManager.ShowConfirmation("One of the save hotkeys could not be loaded properly. Would you like to open the save options now?", "Save Hotkey Error", isYesDefault: true))
                configureSaveOptionsToolStripMenuItem_Click(this, EventArgs.Empty);


            void InitializeApplication()
            {
                Application.ApplicationExit += Application_ApplicationExit;

                worldSelectionPage.NextButton.Click += NextButton_Click;
                saveSelectionPage.BackButton.Click += BackButton_Click;

                this.AcceptButton = worldSelectionPage.NextButton;
                BackButton_Click(this, EventArgs.Empty);
            }

            void CheckForInsufficientDiskSpace()
            {
                const double LowDiskSpaceThreshold = 3;  // in gigabytes
                double freeSpace = new DriveInfo(Save.BackupPath).AvailableFreeSpace / 1e+9;  // in gigabytes

                if (freeSpace < LowDiskSpaceThreshold && MessageBoxManager.ShowConfirmation($"You are currently low on disk space (<{LowDiskSpaceThreshold} GB). This may cause newer saves to completely fill up your disk space. You are suggested to change the save backup path to another drive.\n\nWould you like to do that now?", "Low Disk Space", isYesDefault: true))
                    configureSaveOptionsToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void BackButton_Click(object? sender, EventArgs e)
        {
            PageLoader.Load(pagePanel, worldSelectionPage);

            this.CancelButton = saveSelectionPage.BackButton;
            this.ContextMenuStrip = worldSelectionPage.ContextMenuStrip;
        }

        private void NextButton_Click(object? sender, EventArgs e)
        {
            saveSelectionPage.SelectedWorld = worldSelectionPage.SelectedWorld;
            PageLoader.Load(pagePanel, saveSelectionPage);

            this.ContextMenuStrip = saveSelectionPage.ContextMenuStrip;
        }

        private void configureSaveOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new SaveOptionsForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                SaveHelper.UpdateAutosaveTimer();
                saveSelectionPage.UpdateUI();
            }

            SaveHelper.Hotkeys.UpdateAll();
        }

        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FileExplorer.Browse(Logger.FilePath))
                MessageBoxManager.ShowError($"The log file could not be opened. It may still be opened manually at {Logger.FilePath}.");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var form = new AboutForm();
            form.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveHelper.Hotkeys.GetKeyByString(Settings.Default.SaveHotkey).Key is null && !Settings.Default.EnableAutosave)
                return;

            if (!MessageBoxManager.ShowConfirmation("Are you sure you want to quit? The program must be kept running in the background in order to perform manual or automatic saves!", "Exit Confirmation"))
                e.Cancel = true;
        }

        private void Application_ApplicationExit(object? sender, EventArgs e)
        {
            SaveHelper.Hotkeys.UnbindAll();

            Settings.Default.Save();
            Logger.Log("All settings have been saved.", LogSeverity.Info);

            SoundPlayer.Shared.Dispose();
            SaveHelper.Dispose();

            Logger.Log("Application shutting down.", LogSeverity.Info);
            Logger.Dispose();
        }

        private async void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (Version LatestVersion, DateTime ReleaseDate, string ReleaseNotes) versionInfo;

            try
            {
                versionInfo = await VersionManager.GetLatestVersionInfo();
            }
            catch (Exception ex)
            {
                Logger.Log("Could not check for updates", ex);
                MessageBoxManager.ShowError($"Could not check for updates. Please ensure you are properly connected to the internet and try again.\n\nError message: {ex.Message}");
                return;
            }

            if (versionInfo.LatestVersion > VersionManager.ApplicationVersion)
            {
                if (MessageBoxManager.ShowConfirmation($"A new version is available.\n\nCurrent version: {VersionManager.ApplicationVersionText}\nLatest version: {versionInfo.LatestVersion} ({versionInfo.ReleaseDate:yyyy/MM/dd})\n\nRelease notes:\n{versionInfo.ReleaseNotes}\n\nWould you like to open the download page now?", "Update Confirmation", MessageBoxIcon.Asterisk, true))
                    FileExplorer.Browse(VersionManager.LatestReleaseUrl);
            }
            else
            {
                MessageBoxManager.ShowInfo("You are currently running the latest version of the program.", "Check for Updates");
            }
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e) => FileExplorer.Browse(VersionManager.FeedbackUrl);
        private void reportToolStripMenuItem_Click(object sender, EventArgs e) => FileExplorer.Browse(VersionManager.IssueReportUrl);

        // TODO: Figure out a way to prevent controls from stealing pressed keys
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //	if (PageLoader.CurrentPage is not null)
        //	{
        //		// Propagate pressed keys to child pages
        //		((IPage)PageLoader.CurrentPage).GlobalKeyDown(keyData);

        //		return true;
        //	}

        //	return base.ProcessCmdKey(ref msg, keyData);
        //}
    }
}
