using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SavepointManager.Classes;
using SavepointManager.Pages;

namespace SavepointManager.Forms
{
	public partial class MainForm : Form
	{
		private readonly WorldSelectionPage worldSelectionPage = new();
		private readonly SaveSelectionPage saveSelectionPage = new();

		public MainForm()
		{
			InitializeComponent();

			FormPageLoader.Load(pagePanel, worldSelectionPage);

			worldSelectionPage.NextButton.Click += NextButton_Click;
			saveSelectionPage.BackButton.Click += BackButton_Click;

			this.AcceptButton = worldSelectionPage.NextButton;
		}

		private void BackButton_Click(object? sender, EventArgs e)
		{
			FormPageLoader.Load(pagePanel, worldSelectionPage);
			this.CancelButton = saveSelectionPage.BackButton;
		}

		private void NextButton_Click(object? sender, EventArgs e)
		{
			FormPageLoader.Load(pagePanel, saveSelectionPage);
			saveSelectionPage.SelectedWorld = worldSelectionPage.SelectedWorld!;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

		private void configureSaveOptionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new SaveOptionsForm().ShowDialog();
		}
	}
}
