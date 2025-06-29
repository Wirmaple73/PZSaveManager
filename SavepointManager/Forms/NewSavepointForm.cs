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
	public partial class NewSavepointForm : Form
	{
		public string? SaveTitle { get; private set; }

		public NewSavepointForm() => InitializeComponent();
		private void okButton_Click(object sender, EventArgs e)
		{
			SaveTitle = saveTitle.Text;
			this.Close();
		}
	}
}
