namespace SavepointManager.Pages
{
	partial class SaveSelectionPage
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			saveList = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			newSave = new Button();
			restoreSaveButton = new Button();
			label2 = new Label();
			worldName = new Label();
			deleteSaveButton = new Button();
			backButton = new Button();
			label3 = new Label();
			savePreview = new PictureBox();
			((System.ComponentModel.ISupportInitialize)savePreview).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 40);
			label1.Name = "label1";
			label1.Size = new Size(76, 15);
			label1.TabIndex = 6;
			label1.Text = "Select a save.";
			// 
			// saveList
			// 
			saveList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			saveList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
			saveList.FullRowSelect = true;
			saveList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			saveList.Location = new Point(16, 66);
			saveList.MultiSelect = false;
			saveList.Name = "saveList";
			saveList.Size = new Size(485, 411);
			saveList.TabIndex = 12;
			saveList.UseCompatibleStateImageBehavior = false;
			saveList.View = View.Details;
			saveList.SelectedIndexChanged += saveList_SelectedIndexChanged;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Title";
			columnHeader1.Width = 330;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Date";
			columnHeader2.Width = 140;
			// 
			// newSave
			// 
			newSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			newSave.Location = new Point(518, 369);
			newSave.Name = "newSave";
			newSave.Size = new Size(200, 28);
			newSave.TabIndex = 13;
			newSave.Text = "&New save...";
			newSave.UseVisualStyleBackColor = true;
			newSave.Click += newSavepoint_Click;
			// 
			// restoreSaveButton
			// 
			restoreSaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			restoreSaveButton.Location = new Point(518, 409);
			restoreSaveButton.Name = "restoreSaveButton";
			restoreSaveButton.Size = new Size(200, 28);
			restoreSaveButton.TabIndex = 14;
			restoreSaveButton.Text = "&Restore save";
			restoreSaveButton.UseVisualStyleBackColor = true;
			restoreSaveButton.Click += restoreSaveButton_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label2.Location = new Point(13, 10);
			label2.Name = "label2";
			label2.Size = new Size(44, 15);
			label2.TabIndex = 15;
			label2.Text = "World:";
			// 
			// worldName
			// 
			worldName.AutoSize = true;
			worldName.Location = new Point(54, 10);
			worldName.Name = "worldName";
			worldName.Size = new Size(72, 15);
			worldName.TabIndex = 16;
			worldName.Text = "World name";
			// 
			// deleteSaveButton
			// 
			deleteSaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deleteSaveButton.Location = new Point(518, 449);
			deleteSaveButton.Name = "deleteSaveButton";
			deleteSaveButton.Size = new Size(200, 28);
			deleteSaveButton.TabIndex = 17;
			deleteSaveButton.Text = "&Delete";
			deleteSaveButton.UseVisualStyleBackColor = true;
			deleteSaveButton.Click += deleteSaveButton_Click;
			// 
			// backButton
			// 
			backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			backButton.DialogResult = DialogResult.OK;
			backButton.Location = new Point(15, 493);
			backButton.Name = "backButton";
			backButton.Size = new Size(112, 28);
			backButton.TabIndex = 18;
			backButton.Text = "&Back";
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label3.Location = new Point(518, 269);
			label3.Name = "label3";
			label3.Size = new Size(200, 15);
			label3.TabIndex = 19;
			label3.Text = "Save preview";
			label3.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// savePreview
			// 
			savePreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			savePreview.BorderStyle = BorderStyle.FixedSingle;
			savePreview.Location = new Point(518, 66);
			savePreview.Name = "savePreview";
			savePreview.Size = new Size(200, 200);
			savePreview.SizeMode = PictureBoxSizeMode.Zoom;
			savePreview.TabIndex = 20;
			savePreview.TabStop = false;
			// 
			// SaveSelectionPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(savePreview);
			Controls.Add(label3);
			Controls.Add(backButton);
			Controls.Add(deleteSaveButton);
			Controls.Add(worldName);
			Controls.Add(label2);
			Controls.Add(restoreSaveButton);
			Controls.Add(newSave);
			Controls.Add(saveList);
			Controls.Add(label1);
			Name = "SaveSelectionPage";
			Size = new Size(734, 537);
			((System.ComponentModel.ISupportInitialize)savePreview).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ListView saveList;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private Button newSave;
		private Button restoreSaveButton;
		private Label label2;
		private Label worldName;
		private Button deleteSaveButton;
		private Button backButton;
		private Label label3;
		private PictureBox savePreview;
	}
}
