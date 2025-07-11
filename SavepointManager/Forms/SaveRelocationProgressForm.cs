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

			this.DialogResult = result;
			this.Close();
		}

		private async Task MoveSaves()
		{
			await Task.Run(() =>
			{
				// Copy all saves to the new folder
				var savePaths = Directory.GetDirectories(OldPath, "*", SearchOption.TopDirectoryOnly);
				int totalDirs = savePaths.Length;

				for (int i = 0; i < totalDirs; i++)
				{
					string tarPath = Path.Combine(savePaths[i], $"{Save.ArchiveFileName}.tar");
					string zipPath = Path.Combine(savePaths[i], $"{Save.ArchiveFileName}.zip");

					if (!File.Exists(tarPath) && !File.Exists(zipPath))
						continue;

					string destPath = Path.Combine(NewPath, new DirectoryInfo(savePaths[i]).Name);

					try
					{
						// Directory.Move sucks when it comes to moving folders to another drive
						Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(savePaths[i], destPath);

						this.Invoke(() =>
						{
							int percentDone = (int)(((double)i + 1) / totalDirs * 100);

							status.Text = $"{i + 1} out of {totalDirs} folders moved ({percentDone}% done)";
							progressBar.Value = percentDone;
						});
					}
					catch (Exception ex)
					{
						Logger.Log($"The directory {savePaths[i]} could not be moved to {destPath}", ex);
						ErrorMessage = ex.Message;

						result = DialogResult.Cancel;
						break;
					}
				}
			});

			if (result == DialogResult.None)
				result = DialogResult.OK;
		}

		private void SaveRelocationProgressForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (result == DialogResult.None)
				e.Cancel = true;
		}
	}
}
