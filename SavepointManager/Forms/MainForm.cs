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

namespace SavepointManager.Forms
{
	public partial class MainForm : Form
	{
		private readonly SaveSelectionPage saveSelectionPage = new();

		public MainForm()
		{
			InitializeComponent();

			FormPageLoader.Load(pagePanel, saveSelectionPage);
			this.AcceptButton = saveSelectionPage.NextButton;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
	}
}
