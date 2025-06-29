using SavepointManager.Classes;
using SavepointManager.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavepointManager.Pages
{
	public partial class SaveSelectionPage : UserControl
	{
		private World? selectedWorld;

		public World? SelectedWorld
		{
			get => selectedWorld;
			set
			{
				selectedWorld = value;

				if (value is not null)
				{
					RefillSaveList();
					worldName.Text = value.Title;
				}
				else
				{
					saveList.Items.Clear();
				}
			}
		}

		public Button BackButton => backButton;

		public SaveSelectionPage()
		{
			InitializeComponent();
		}

		private void RefillSaveList()
		{
			saveList.Items.Clear();

			foreach (var save in SelectedWorld!.Savepoints)
				saveList.Items.Add(new ListViewItem(new[] { save.Title, save.Date.ToString("G") }));
		}

		private void newSavepoint_Click(object sender, EventArgs e)
		{
			var newSaveForm = new NewSavepointForm();
			newSaveForm.ShowDialog();

			string saveTitle = newSaveForm.SaveTitle is not null && newSaveForm.SaveTitle.Length > 0 ? newSaveForm.SaveTitle : "Manual save";

			var sp = new Savepoint(SelectedWorld!.FolderPath, saveTitle, DateTime.Now);
			sp.Save();

			RefillSaveList();
		}
	}
}
