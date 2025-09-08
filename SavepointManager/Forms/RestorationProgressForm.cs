using SavepointManager.Classes;
using SavepointManager.Classes.Exceptions;

namespace SavepointManager.Forms
{
	public partial class RestorationProgressForm : Form
	{
		public Save? SelectedSave { get; set; }
		public bool? IsOriginalWorldRestored { get; private set; } = null;
		public bool? IsRedundantBackupDeleted { get; private set; } = null;
		public string? ErrorMessage { get; private set; } = null;

		private DialogResult result = DialogResult.None;

		public RestorationProgressForm() => InitializeComponent();

		private async void RestorationProgressForm_Shown(object sender, EventArgs e)
		{
			await RestoreAsync();
			this.Close();
		}

		private async Task RestoreAsync()
		{
			if (SelectedSave is null || SelectedSave.AssociatedWorld is null)
				throw new InvalidOperationException($"{nameof(SelectedSave)} or the world associated with it is null.");

			this.Invoke(() => this.Text = $"Restoring {SelectedSave.AssociatedWorld.Name}");
			WindowHelper.Buttons.DisableCloseButton(this.Handle);

			try
			{
				try
				{
					await Task.Run(() =>
					{
						// Delete the old save backup
						if (Directory.Exists(SelectedSave.AssociatedWorld.BackupPath))
							Directory.Delete(SelectedSave.AssociatedWorld.BackupPath, true);

						Directory.Move(SelectedSave.AssociatedWorld.Path, SelectedSave.AssociatedWorld.BackupPath);
						Directory.CreateDirectory(SelectedSave.AssociatedWorld.Path);
					});
				}
				catch (Exception exc)
				{
					throw new SaveBackupException("Could not rename the original world", exc);
				}

				this.Invoke(() =>
				{
					progressBar.Style = ProgressBarStyle.Continuous;
					progressLabel.Visible = actualProgress.Visible = true;
				});

				SelectedSave.ArchiveProgressChanged += SelectedSave_ArchiveProgressChanged;
				SelectedSave.ArchiveStatusChanged += SelectedSave_ArchiveStatusChanged;

				await SelectedSave.RestoreAsync();
				result = DialogResult.OK;
			}
			catch (SaveExtractionException ex)
			{
				// The original world folder is now likely corrupted

				this.Invoke(() =>
				{
					status.Text = "Save restoration failed. Recovering your current unsaved progress...";
					progressBar.Style = ProgressBarStyle.Marquee;

					WindowHelper.TaskbarProgress.State = WindowHelper.TaskbarProgress.TaskbarState.Indeterminate;
				});

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
			}
			catch (Exception ex) /* when (ex is WorldActiveException or ArchivePathNullException or InvalidSaveArchiveException or SaveBackupException) */
			{
				// The original world is still safe
				HandleException(ex);
				IsOriginalWorldRestored = true;
			}
			finally
			{
				SelectedSave.ArchiveProgressChanged -= SelectedSave_ArchiveProgressChanged;
				SelectedSave.ArchiveStatusChanged -= SelectedSave_ArchiveStatusChanged;

				if (result != DialogResult.Cancel)  // If everything went smoothly
				{
					this.Invoke(() =>
					{
						status.Text = "Deleting temporary world backup...";
						progressLabel.Visible = actualProgress.Visible = false;

						progressBar.Style = ProgressBarStyle.Marquee;
						WindowHelper.TaskbarProgress.State = WindowHelper.TaskbarProgress.TaskbarState.Indeterminate;
					});

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
			}

			void HandleException(Exception ex)
			{
				Logger.Log("Unable to restore save data", ex is SaveExtractionException ? ex.InnerException! : ex);
				result = DialogResult.Cancel;
				ErrorMessage = ex.Message;
			}
		}

		private void SelectedSave_ArchiveStatusChanged(object? sender, ArchiveStatusChangedEventArgs e)
		{
			this.Invoke(() =>
			{
				progressBar.Style = ProgressBarStyle.Continuous;

				status.Text = e.Status switch
				{
					ArchiveStatus.Extracting => "Extracting entries...",
					ArchiveStatus.SavingToDisk => "Saving entries to disk...",
					_ => "Unknown status"
				};
			});
		}

		private void SelectedSave_ArchiveProgressChanged(object? sender, ArchiveProgressEventArgs e)
		{
			int percentDone = (int)((float)e.FilesProcessed / e.TotalFiles * 100);

			this.Invoke(() =>
			{
				progressBar.Value = WindowHelper.TaskbarProgress.Progress = percentDone;
				actualProgress.Text = $"{e.FilesProcessed} out of {e.TotalFiles} files processed ({percentDone}% done)";
			});
		}

		private void RestorationProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			// Don't allow the user to halt the extraction process till it's done
			if (result == DialogResult.None)
				e.Cancel = true;

			this.DialogResult = result;
			WindowHelper.TaskbarProgress.Finish();
		}
	}
}
