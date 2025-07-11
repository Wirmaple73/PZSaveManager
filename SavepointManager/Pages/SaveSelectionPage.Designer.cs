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
			newSaveButton = new Button();
			restoreSaveButton = new Button();
			label2 = new Label();
			worldName = new Label();
			deleteSaveButton = new Button();
			backButton = new Button();
			label3 = new Label();
			savePreview = new PictureBox();
			refreshListButton = new Button();
			saveLabel = new Label();
			saveLabelIcon = new PictureBox();
			((System.ComponentModel.ISupportInitialize)savePreview).BeginInit();
			((System.ComponentModel.ISupportInitialize)saveLabelIcon).BeginInit();
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
			columnHeader1.Text = "Description";
			columnHeader1.Width = 300;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Date";
			columnHeader2.Width = 150;
			// 
			// newSaveButton
			// 
			newSaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			newSaveButton.Location = new Point(518, 374);
			newSaveButton.Name = "newSaveButton";
			newSaveButton.Size = new Size(200, 28);
			newSaveButton.TabIndex = 13;
			newSaveButton.Text = "&New save...";
			newSaveButton.UseVisualStyleBackColor = true;
			newSaveButton.Click += newSaveButton_Click;
			// 
			// restoreSaveButton
			// 
			restoreSaveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			restoreSaveButton.Location = new Point(518, 412);
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
			deleteSaveButton.Location = new Point(518, 450);
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
			// refreshListButton
			// 
			refreshListButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			refreshListButton.Location = new Point(518, 326);
			refreshListButton.Name = "refreshListButton";
			refreshListButton.Size = new Size(200, 28);
			refreshListButton.TabIndex = 21;
			refreshListButton.Text = "R&efresh list";
			refreshListButton.UseVisualStyleBackColor = true;
			refreshListButton.Click += refreshListButton_Click;
			// 
			// saveLabel
			// 
			saveLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			saveLabel.AutoEllipsis = true;
			saveLabel.Location = new Point(175, 493);
			saveLabel.Name = "saveLabel";
			saveLabel.Size = new Size(543, 40);
			saveLabel.TabIndex = 22;
			saveLabel.Text = "No saves have been created yet. If this is not the case and you have changed the save backup path recently, please make sure it is set correctly by navigating to Options > Configure save options.";
			saveLabel.Visible = false;
			// 
			// saveLabelIcon
			// 
			saveLabelIcon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			saveLabelIcon.Location = new Point(141, 493);
			saveLabelIcon.Name = "saveLabelIcon";
			saveLabelIcon.Size = new Size(28, 28);
			saveLabelIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			saveLabelIcon.TabIndex = 23;
			saveLabelIcon.TabStop = false;
			saveLabelIcon.Visible = false;
			// 
			// SaveSelectionPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(saveLabelIcon);
			Controls.Add(saveLabel);
			Controls.Add(refreshListButton);
			Controls.Add(savePreview);
			Controls.Add(label3);
			Controls.Add(backButton);
			Controls.Add(deleteSaveButton);
			Controls.Add(worldName);
			Controls.Add(label2);
			Controls.Add(restoreSaveButton);
			Controls.Add(newSaveButton);
			Controls.Add(saveList);
			Controls.Add(label1);
			Name = "SaveSelectionPage";
			Size = new Size(734, 537);
			((System.ComponentModel.ISupportInitialize)savePreview).EndInit();
			((System.ComponentModel.ISupportInitialize)saveLabelIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ListView saveList;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private Button newSaveButton;
		private Button restoreSaveButton;
		private Label label2;
		private Label worldName;
		private Button deleteSaveButton;
		private Button backButton;
		private Label label3;
		private PictureBox savePreview;
		private Button refreshListButton;
		private Label saveLabel;
		private PictureBox saveLabelIcon;
	}
}
