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
				saveHotkey.Items.Add(keys[i]);
				abortSaveHotkey.Items.Add(keys[i]);
			}

			saveHotkey.Text = Settings.Default.SaveHotkey;
			abortSaveHotkey.Text = Settings.Default.AbortSaveHotkey;
			autosaveInterval.Text = Settings.Default.AutosaveInterval.ToString();
			enableAutosave.Checked = autosaveInterval.Enabled = Settings.Default.EnableAutosave;
		}

		private void enableAutosave_CheckedChanged(object sender, EventArgs e)
			=> autosaveInterval.Enabled = enableAutosave.Checked;

		private void okButton_Click(object sender, EventArgs e)
		{
			if (enableAutosave.Checked && !int.TryParse(autosaveInterval.Text, out _))
			{
				MessageBoxManager.ShowError("Please enter a valid interval for auto-save.");
				return;
			}

			Settings.Default.SaveHotkey = saveHotkey.Text;
			Settings.Default.AbortSaveHotkey = abortSaveHotkey.Text;
			Settings.Default.EnableAutosave = enableAutosave.Checked;
			Settings.Default.AutosaveInterval = enableAutosave.Checked ? int.Parse(autosaveInterval.Text) : 10;

			Settings.Default.Save();
			this.Close();
		}
	}
}
