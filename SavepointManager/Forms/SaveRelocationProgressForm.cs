using SavepointManager.Classes;
using SavepointManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavepointManager.Forms
{
	public partial class SaveRelocationProgressForm : Form
	{
		public string OldPath { get; set; } = "";
		public string NewPath { get; set; } = "";
		public string? ErrorMessage { get; private set; } = null;

		private DialogResult result = DialogResult.None;

		public SaveRelocationProgressForm() => InitializeComponent();

		private async void SaveRelocationProgressForm_Shown(object sender, EventArgs e)
		{
			await MoveSaves();

			if (result == DialogResult.None)
				result = DialogResult.OK;

			this.DialogResult = result;
			this.Close();
		}

		private async Task MoveSaves()
		{
			WindowHelper.Buttons.DisableCloseButton(this.Handle);
			var dt = DateTime.Now;

			await Task.Run(() =>
			{
				// Copy all saves to the new folder
				var savePaths = Directory.GetDirectories(OldPath, "*", SearchOption.TopDirectoryOnly);
				int filesMoved = 0, totalDirs = savePaths.Length;

				Logger.Log($"Beginning to relocate saves from {OldPath} to {NewPath}...", LogSeverity.Info);

				Parallel.ForEach(savePaths, (string path, ParallelLoopState ls) =>
				{
					string tarPath = Path.Combine(path, $"{Save.ArchiveFileName}.tar");
					string zipPath = Path.Combine(path, $"{Save.ArchiveFileName}.zip");

					if (!File.Exists(tarPath) && !File.Exists(zipPath))
						return;  // Continue

					string destPath = Path.Combine(NewPath, new DirectoryInfo(path).Name);

					try
					{
						Logger.Log($"Beginning to move directory {path}...", LogSeverity.Info);

						// Directory.Move is unable to move folders to another drive. VB is a hidden treasure.
						Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(path, destPath);
					}
					catch (Exception ex)
					{
						WindowHelper.TaskbarProgress.State = WindowHelper.TaskbarProgress.TaskbarState.Error;

						Logger.Log($"The directory {path} could not be moved to {destPath}", ex);
						ErrorMessage = ex.Message;

						result = DialogResult.Cancel;
						ls.Stop();  // Break
					}

					int filesMovedNew = Interlocked.Increment(ref filesMoved);

					this.Invoke(() =>
					{
						int percentDone = (int)((double)filesMovedNew / totalDirs * 100);

						status.Text = $"{filesMovedNew} out of {totalDirs} folders moved ({percentDone}% done)";
						progressBar.Value = WindowHelper.TaskbarProgress.Progress = percentDone;
					});
				});
			});

			Logger.Log($"Save relocation took {(DateTime.Now - dt).TotalSeconds:f1} seconds.", LogSeverity.Info);
		}

		private void SaveRelocationProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (result == DialogResult.None)
				e.Cancel = true;

			WindowHelper.TaskbarProgress.Finish();
		}
	}
}
