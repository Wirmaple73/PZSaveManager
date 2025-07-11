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
	public partial class NewSaveForm : Form
	{
		public string? SaveDescription { get; private set; }

		public NewSaveForm() => InitializeComponent();

		private void okButton_Click(object sender, EventArgs e)
		{
			SaveDescription = saveDescription.Text;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void NewSavepointForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}
	}
}
