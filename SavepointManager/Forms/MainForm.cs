using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavepointManager.Classes;
using SavepointManager.Pages;
using SavepointManager.Properties;

namespace SavepointManager.Forms
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

			if (!SaveHelper.UpdateHotkeys() && MessageBoxManager.ShowConfirmation("One of the save hotkeys could not be loaded properly. Would you like to open the save options now?", "Save Hotkey Error", isYesDefault: true))
				configureSaveOptionsToolStripMenuItem_Click(this, EventArgs.Empty);

			void InitializeApplication()
			{
				Application.ApplicationExit += Application_ApplicationExit;

				worldSelectionPage.NextButton.Click += NextButton_Click;
				saveSelectionPage.BackButton.Click += BackButton_Click;

				this.AcceptButton = worldSelectionPage.NextButton;
				pagePanel.LoadPage(worldSelectionPage);
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
			pagePanel.LoadPage(worldSelectionPage);
			this.CancelButton = saveSelectionPage.BackButton;
		}

		private void NextButton_Click(object? sender, EventArgs e)
		{
			pagePanel.LoadPage(saveSelectionPage);
			saveSelectionPage.SelectedWorld = worldSelectionPage.SelectedWorld!;
		}

		private void configureSaveOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using var form = new SaveOptionsForm();

			if (form.ShowDialog() == DialogResult.OK)
			{
				SaveHelper.UpdateHotkeys();
				SaveHelper.UpdateAutosaveTimer();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (SaveHelper.GetKeyFromString(Settings.Default.SaveHotkey).Key is null && !Settings.Default.EnableAutosave)
				return;

			if (!MessageBoxManager.ShowConfirmation("Are you sure you want to quit? The program must be kept running in the background in order to perform manual or automatic saves!", "Exit Confirmation"))
				e.Cancel = true;
		}

		private void Application_ApplicationExit(object? sender, EventArgs e)
		{
			SaveHelper.UnbindAll();

			Settings.Default.Save();
			Logger.Log("All settings have been saved.", LogSeverity.Info);

			SoundPlayer.Shared.Dispose();
			SaveHelper.Dispose();

			Logger.Log("Application shutting down.", LogSeverity.Info);
			Logger.Dispose();
		}

		private async void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Version newVersion;

			try
			{
				newVersion = await VersionManager.GetLatestVersion();
			}
			catch (Exception ex)
			{
				Logger.Log("Could not check for updates", ex);
				MessageBoxManager.ShowError("Could not check for updates. Please ensure you are connected to the internet properly and try again.");
				return;
			}

			if (newVersion > VersionManager.CurrentVersion)
			{
				if (MessageBoxManager.ShowConfirmation("A new version is available. Would you like to open the download page now?", "Update Confirmation", MessageBoxIcon.Asterisk, true))
					FileExplorer.Browse(VersionManager.RepoUrl);
			}
			else
			{
				MessageBoxManager.ShowInfo("You are currently running the latest version of the program.", "Update Check");
			}
		}
	}
}
