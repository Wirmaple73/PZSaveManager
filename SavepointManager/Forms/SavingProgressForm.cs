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

namespace SavepointManager.Forms
{
	public partial class SavingProgressForm : Form
	{
		public Save? Save { get; set; }
		public bool UseCompression { get; set; }

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
				await Save.ExportAsync(UseCompression, tokenSource.Token);
				result = DialogResult.OK;
			}
			catch (TaskCanceledException)
			{
				Save.ArchiveProgressChanged -= Save_ArchiveProgressChanged;
				Save.ExportStarted -= Save_ExportStarted;
				result = DialogResult.Cancel;
			}

			this.Close();
		}

		private void Save_ExportStarted(object? sender, EventArgs e)
		{
			this.Invoke(() =>
			{
				status.Text = UseCompression ? "Compressing and exporting archive..." : "Exporting archive...";
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
