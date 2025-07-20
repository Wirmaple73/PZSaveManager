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

		public MainForm()
		{
			InitializeComponent();
			Application.ApplicationExit += Application_ApplicationExit;

			FormPageLoader.Load(pagePanel, worldSelectionPage);

			worldSelectionPage.NextButton.Click += NextButton_Click;
			saveSelectionPage.BackButton.Click += BackButton_Click;

			this.AcceptButton = worldSelectionPage.NextButton;

			SaveHelper.UpdateAutosaveTimer();

			if (!SaveHelper.UpdateHotkeys() && MessageBoxManager.ShowConfirmation("One of the save hotkeys could not be loaded properly. Would you like to open the save options now?", "Save Hotkey Error", isYesDefault: true))
				configureSaveOptionsToolStripMenuItem_Click(this, EventArgs.Empty);
		}

		private void BackButton_Click(object? sender, EventArgs e)
		{
			FormPageLoader.Load(pagePanel, worldSelectionPage);
			this.CancelButton = saveSelectionPage.BackButton;
		}

		private void NextButton_Click(object? sender, EventArgs e)
		{
			FormPageLoader.Load(pagePanel, saveSelectionPage);
			saveSelectionPage.SelectedWorld = worldSelectionPage.SelectedWorld!;
		}

		private void configureSaveOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (new SaveOptionsForm().ShowDialog() == DialogResult.OK)
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

			Logger.Log("All objects have been disposed.", LogSeverity.Info);
			Logger.Log("Application shutting down.", LogSeverity.Info);

			Logger.Dispose();
		}
	}
}
