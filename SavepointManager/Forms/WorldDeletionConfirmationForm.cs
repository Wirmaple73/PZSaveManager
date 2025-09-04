using SavepointManager.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavepointManager.Forms
{
	public partial class WorldDeletionConfirmationForm : Form
	{
		private bool isDeletionInProgress = false;
		private World? subject;

		public World? Subject
		{
			get => subject;
			set
			{
				subject = value;

				if (value is not null)
					deletionMessage.Text = $"Warning: You are about to PERMANENTLY delete the world {value.Name} ({value.Gamemode}), including all of its saves ({value.GetSaves().Count()} in total). This action cannot be undone.";
			}
		}

		public WorldDeletionConfirmationForm()
		{
			InitializeComponent();
			warningImage.Image = SystemIcons.Warning.ToBitmap();
		}

		private void WorldDeletionConfirmationForm_Shown(object sender, EventArgs e) => SystemSounds.Beep.Play();

		private async void removeButton_Click(object sender, EventArgs e)
		{
			cancelButton.Enabled = removeButton.Enabled = confirmationTextBox.Enabled = false;
			WindowHelper.Buttons.DisableCloseButton(this.Handle);

			isDeletionInProgress = true;
			statusLabel.Visible = actualStatusLabel.Visible = progressLabel.Visible = progressBar.Visible = true;

			// TODO: Parallelize and report progress
			//Subject?.Delete();
			await Task.Delay(10000);

			isDeletionInProgress = false;
			this.DialogResult = DialogResult.OK;
		}

		private void confirmationBox_TextChanged(object sender, EventArgs e)
			=> removeButton.Enabled = confirmationTextBox.Text.Trim().Equals("delete", StringComparison.OrdinalIgnoreCase);

		private void WorldDeletionConfirmationForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (isDeletionInProgress)
				e.Cancel = true;
		}
	}
}
