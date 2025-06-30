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
	public partial class ArchiveProgressForm : Form
	{
		public Save? Save { get; set; }

		private readonly CancellationTokenSource tokenSource = new();
		private DialogResult result = DialogResult.None;

		public ArchiveProgressForm() => InitializeComponent();

		private async void ArchiveProgressForm_Load(object sender, EventArgs e)
		{
			this.Text = $"Saving {Save!.AssociatedWorld.Name}";
			Save.ArchiveProgressChanged += Save_ArchiveProgressChanged;

			try
			{
				await Save.ExportAsync(tokenSource.Token);
				result = DialogResult.OK;
			}
			catch (TaskCanceledException)
			{
				Save.ArchiveProgressChanged -= Save_ArchiveProgressChanged;
				result = DialogResult.Cancel;
			}

			this.Close();
		}

		private void Save_ArchiveProgressChanged(object? sender, ArchiveProgressEventArgs e) => this.Invoke(() => UpdateProgress(e));

		private void UpdateProgress(ArchiveProgressEventArgs e)
		{
			int percentDone = (int)((float)e.CurrentIndex / e.TotalFiles * 100);

			progressBar.Value = percentDone;
			fileName.Text = e.CurrentFileName;
			progress.Text = $"{e.CurrentIndex} out of {e.TotalFiles} files done ({percentDone}%)";
		}

		private void ArchiveProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (result == DialogResult.None)
				tokenSource.Cancel();

			this.DialogResult = result;
		}
	}
}
