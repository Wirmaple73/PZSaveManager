using SavepointManager.Classes;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavepointManager.Properties;

namespace SavepointManager.Forms
{
	public partial class SavingProgressForm : Form
	{
		public Save? Save { get; set; }
		public string? ErrorMessage { get; private set; } = null;

		private readonly CancellationTokenSource tokenSource = new();
		private DialogResult result = DialogResult.None;

		public SavingProgressForm() => InitializeComponent();

		private async void SavingProgressForm_Shown(object sender, EventArgs e)
		{
			this.Text = $"Saving {Save!.AssociatedWorld.Name}";

			Save.ArchiveProgressChanged += Save_ArchiveProgressChanged;
			Save.ArchiveStatusChanged += Save_ArchiveStatusChanged;

			try
			{
				await Save.ExportAsync(Settings.Default.UseCompression, tokenSource.Token);
				result = DialogResult.OK;
			}
			catch (OperationCanceledException)
			{
				WindowHelper.TaskbarProgress.State = WindowHelper.TaskbarProgress.TaskbarState.Paused;

				result = DialogResult.OK;
				Logger.Log($"Saving has been canceled by the user.", LogSeverity.Info);
			}
			catch (Exception ex)
			{
				WindowHelper.TaskbarProgress.State = WindowHelper.TaskbarProgress.TaskbarState.Error;

				result = DialogResult.Cancel;
				ErrorMessage = ex.Message;

				Logger.Log($"The world {Save.AssociatedWorld} could not be exported", ex);
			}
			finally
			{
				Save.ArchiveProgressChanged -= Save_ArchiveProgressChanged;
				Save.ArchiveStatusChanged -= Save_ArchiveStatusChanged;
			}

			this.Close();
		}

		private void Save_ArchiveStatusChanged(object? sender, ArchiveStatusChangedEventArgs e)
		{
			this.Invoke(() =>
			{
				(status.Text, progressBar.Style) = e.Status switch
				{
					ArchiveStatus.AddingFromDisk => ("Adding files from disk...", ProgressBarStyle.Continuous),
					ArchiveStatus.AddingToArchive => ("Adding files to archive...", ProgressBarStyle.Continuous),
					ArchiveStatus.Exporting => (Settings.Default.UseCompression ? "Compressing and exporting archive..." : "Exporting archive...", ProgressBarStyle.Marquee),
					_ => ("Unknown status", ProgressBarStyle.Marquee)
				};

				if (e.Status == ArchiveStatus.Exporting)
					progress.Text = "~";

				if (progressBar.Style == ProgressBarStyle.Marquee)
					WindowHelper.TaskbarProgress.State = WindowHelper.TaskbarProgress.TaskbarState.Indeterminate;
			});
		}

		private void Save_ArchiveProgressChanged(object? sender, ArchiveProgressEventArgs e)
		{
			this.Invoke(() =>
			{
				int percentDone = (int)((float)e.FilesProcessed / e.TotalFiles * 100);

				progressBar.Value = WindowHelper.TaskbarProgress.Progress = percentDone;
				progress.Text = $"{e.FilesProcessed} out of {e.TotalFiles} files added ({percentDone}% done)";
			});
		}

		private void ArchiveProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (result == DialogResult.None)
				tokenSource.Cancel();

			this.DialogResult = result;
			WindowHelper.TaskbarProgress.FinishProgress();
		}
	}
}
