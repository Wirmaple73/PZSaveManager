using SavepointManager.Classes;
using System.Media;

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
					deletionMessage.Text = $"Warning: You are about to PERMANENTLY delete the world {value.Name} ({value.Gamemode}), including all of its saves ({value.GetSaves().Count()} in total). This action cannot be undone!";
			}
		}

		public WorldDeletionConfirmationForm()
		{
			InitializeComponent();
			warningImage.Image = SystemIcons.Warning.ToBitmap();
		}

		private void WorldDeletionConfirmationForm_Shown(object sender, EventArgs e) => SystemSounds.Beep.Play();

		private async void deleteButton_Click(object sender, EventArgs e)
		{
			if (Subject is null)
				throw new InvalidOperationException($"{nameof(Subject)} is null.");

			deleteButton.Enabled = cancelButton.Enabled = confirmationTextBox.Enabled = false;
			WindowHelper.Buttons.DisableCloseButton(this.Handle);

			isDeletionInProgress = true;
			progressBar.Visible = true;

			await Subject.DeleteAsync();

			isDeletionInProgress = false;
			this.DialogResult = DialogResult.OK;
		}

		private void confirmationBox_TextChanged(object sender, EventArgs e)
			=> deleteButton.Enabled = confirmationTextBox.Text.Trim().Equals("delete", StringComparison.OrdinalIgnoreCase);

		private void WorldDeletionConfirmationForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (isDeletionInProgress)
				e.Cancel = true;
		}
	}
}
