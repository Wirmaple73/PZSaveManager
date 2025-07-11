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

		private async void ArchiveProgressForm_Load(object sender, EventArgs e)
		{
			this.Text = $"Saving {Save!.AssociatedWorld.Name}";

			Save.ArchiveProgressChanged += Save_ArchiveProgressChanged;
			Save.ExportStarted += Save_ExportStarted;

			try
			{
				await Save.ExportAsync(Settings.Default.UseCompression, tokenSource.Token);
				result = DialogResult.OK;
			}
			catch (TaskCanceledException)
			{
				result = DialogResult.Cancel;
			}
			catch (Exception ex)
			{
				result = DialogResult.Cancel;
				ErrorMessage = ex.Message;

				Logger.Log($"The world {Save.AssociatedWorld} could not be exported", ex);
			}
			finally
			{
				Save.ArchiveProgressChanged -= Save_ArchiveProgressChanged;
				Save.ExportStarted -= Save_ExportStarted;
			}

			this.Close();
		}

		private void Save_ExportStarted(object? sender, EventArgs e)
		{
			this.Invoke(() =>
			{
				status.Text = Settings.Default.UseCompression ? "Compressing and exporting archive..." : "Exporting archive...";
				progressBar.Style = ProgressBarStyle.Marquee;
			});
		}

		private void Save_ArchiveProgressChanged(object? sender, ArchiveProgressEventArgs e)
		{
			int percentDone = (int)((float)e.FilesProcessed / e.TotalFiles * 100);

			this.Invoke(() =>
			{
				progressBar.Value = percentDone;
				status.Text = $"{e.FilesProcessed} out of {e.TotalFiles} files saved ({percentDone}% done)";
			});
		}

		private void ArchiveProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (result == DialogResult.None)
				tokenSource.Cancel();

			this.DialogResult = result;
		}
	}
}
