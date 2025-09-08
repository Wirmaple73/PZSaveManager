namespace PZSaveManager.Forms
{
	public partial class SaveNameForm : Form
	{
		public string? SaveDescription { get => saveDescription.Text; set => saveDescription.Text = value; }

		public SaveNameForm() => InitializeComponent();

		private void okButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void SaveNameForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}
	}
}
