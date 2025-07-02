using SavepointManager.Classes;
using SavepointManager.Classes.Exceptions;
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
	public partial class RestorationProgressForm : Form
	{
		public Save? SelectedSave { get; set; }
		public bool? IsOriginalWorldRestored { get; private set; } = null;
		public bool? IsRedundantBackupDeleted { get; private set; } = null;

		private DialogResult result = DialogResult.None;

		public RestorationProgressForm() => InitializeComponent();

		private async void RestorationProgressForm_Load(object sender, EventArgs e)
		{
			if (SelectedSave is null)
				throw new NullReferenceException("The selected save is null.");

			this.Text = $"Restoring {SelectedSave.AssociatedWorld.Name}";
			status.Text = "Backing up current unsaved progress...";

			try
			{
				try
				{
					await Task.Run(() =>
					{
						if (Directory.Exists(SelectedSave.AssociatedWorld.BackupPath))
							Directory.Delete(SelectedSave.AssociatedWorld.BackupPath, true);

						Directory.Move(SelectedSave.AssociatedWorld.Path, SelectedSave.AssociatedWorld.BackupPath);
						Directory.CreateDirectory(SelectedSave.AssociatedWorld.Path);
					});
				}
				catch (Exception ex)
				{
					throw new SaveBackupException("Could not rename the original world.", ex);
				}

				progressBar.Style = ProgressBarStyle.Continuous;

				SelectedSave.ArchiveProgressChanged += SelectedSave_ArchiveProgressChanged;
				await SelectedSave.RestoreAsync();

				result = DialogResult.OK;
			}
			catch (SaveExtractionException ex)
			{
				// The original world folder is now likely corrupted
				status.Text = "Save restoration failed. Recovering your current unsaved progress...";
				progressBar.Style = ProgressBarStyle.Continuous;
				progressBar.Value = 0;

				try
				{
					Directory.Delete(SelectedSave.AssociatedWorld.Path, true);
					Directory.Move(SelectedSave.AssociatedWorld.BackupPath, SelectedSave.AssociatedWorld.Path);

					IsOriginalWorldRestored = true;
				}
				catch
				{
					IsOriginalWorldRestored = false;
				}

				HandleException(ex);
				throw;
			}
			catch (Exception ex) /* when (ex is WorldActiveException or ArchivePathNullException or InvalidSaveArchiveException or SaveBackupException) */
			{
				// The original world is still safe
				HandleException(ex);
				IsOriginalWorldRestored = true;
			}
			finally
			{
				if (result != DialogResult.Cancel)  // If everything went smoothly
				{
					status.Text = "Deleting temporary world backup...";
					progressBar.Style = ProgressBarStyle.Marquee;

					try
					{
						// Delete the world backup as it's of no use anymore
						await Task.Run(() => Directory.Delete(SelectedSave.AssociatedWorld.BackupPath, true));
						IsRedundantBackupDeleted = true;
					}
					catch
					{
						IsRedundantBackupDeleted = false;
					}
				}

				this.Close();
			}
		}

		private void SelectedSave_ArchiveProgressChanged(object? sender, ArchiveProgressEventArgs e)
		{
			int percentDone = (int)((float)e.FilesProcessed / e.TotalFiles * 100);

			this.Invoke(() =>
			{
				progressBar.Value = percentDone;
				status.Text = $"{e.FilesProcessed} out of {e.TotalFiles} files restored ({percentDone}% done)";
			});
		}

		private void RestorationProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Don't allow the user to halt the extraction process
			if (result == DialogResult.None)
				e.Cancel = true;

			this.DialogResult = result;
		}

		private void HandleException(Exception ex)
		{
			Logger.Log($"Unable to restore save data: ({ex.GetType().Name}) {ex.Message}", LogSeverity.Error);
			result = DialogResult.Cancel;
		}
	}
}
