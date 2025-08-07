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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveSelectionPage));
			label2 = new Label();
			worldName = new Label();
			backButton = new Button();
			savePreview = new PictureBox();
			saveLabel = new Label();
			saveLabelIcon = new PictureBox();
			label4 = new Label();
			label5 = new Label();
			diskUsage = new Label();
			refreshSaveButton = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			newSaveButton = new ToolStripButton();
			restoreSaveButton = new ToolStripButton();
			renameSaveButton = new ToolStripButton();
			deleteSaveButton = new ToolStripButton();
			toolStrip1 = new ToolStrip();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			saveList = new ListView();
			((System.ComponentModel.ISupportInitialize)savePreview).BeginInit();
			((System.ComponentModel.ISupportInitialize)saveLabelIcon).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label2.Location = new Point(13, 31);
			label2.Name = "label2";
			label2.Size = new Size(44, 15);
			label2.TabIndex = 15;
			label2.Text = "World:";
			// 
			// worldName
			// 
			worldName.AutoEllipsis = true;
			worldName.Location = new Point(54, 31);
			worldName.Name = "worldName";
			worldName.Size = new Size(410, 15);
			worldName.TabIndex = 16;
			worldName.Text = "World name";
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
			// savePreview
			// 
			savePreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			savePreview.BorderStyle = BorderStyle.FixedSingle;
			savePreview.Location = new Point(518, 56);
			savePreview.Name = "savePreview";
			savePreview.Size = new Size(200, 200);
			savePreview.SizeMode = PictureBoxSizeMode.Zoom;
			savePreview.TabIndex = 20;
			savePreview.TabStop = false;
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
			// label4
			// 
			label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label4.Location = new Point(518, 261);
			label4.Name = "label4";
			label4.Size = new Size(200, 15);
			label4.TabIndex = 24;
			label4.Text = "Preview may not be fully accurate.";
			label4.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label5.Location = new Point(470, 31);
			label5.Name = "label5";
			label5.Size = new Size(97, 15);
			label5.TabIndex = 25;
			label5.Text = "Save disk usage:";
			// 
			// diskUsage
			// 
			diskUsage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			diskUsage.Location = new Point(564, 31);
			diskUsage.Name = "diskUsage";
			diskUsage.Size = new Size(152, 15);
			diskUsage.TabIndex = 26;
			diskUsage.Text = "Calculating...";
			diskUsage.TextAlign = ContentAlignment.MiddleRight;
			// 
			// refreshSaveButton
			// 
			refreshSaveButton.Image = (Image)resources.GetObject("refreshSaveButton.Image");
			refreshSaveButton.ImageTransparentColor = Color.Magenta;
			refreshSaveButton.Name = "refreshSaveButton";
			refreshSaveButton.Overflow = ToolStripItemOverflow.Never;
			refreshSaveButton.Size = new Size(84, 22);
			refreshSaveButton.Text = "Refresh list";
			refreshSaveButton.Click += refreshListButton_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Overflow = ToolStripItemOverflow.Never;
			toolStripSeparator1.Size = new Size(6, 25);
			// 
			// newSaveButton
			// 
			newSaveButton.Image = (Image)resources.GetObject("newSaveButton.Image");
			newSaveButton.ImageTransparentColor = Color.Magenta;
			newSaveButton.Name = "newSaveButton";
			newSaveButton.Overflow = ToolStripItemOverflow.Never;
			newSaveButton.Size = new Size(60, 22);
			newSaveButton.Text = "New...";
			newSaveButton.ToolTipText = "Create a new save";
			newSaveButton.Click += newSaveButton_Click;
			// 
			// restoreSaveButton
			// 
			restoreSaveButton.Image = (Image)resources.GetObject("restoreSaveButton.Image");
			restoreSaveButton.ImageTransparentColor = Color.Magenta;
			restoreSaveButton.Name = "restoreSaveButton";
			restoreSaveButton.Overflow = ToolStripItemOverflow.Never;
			restoreSaveButton.Size = new Size(66, 22);
			restoreSaveButton.Text = "Restore";
			restoreSaveButton.ToolTipText = "Restore the selected save";
			restoreSaveButton.Click += restoreSaveButton_Click;
			// 
			// renameSaveButton
			// 
			renameSaveButton.Image = (Image)resources.GetObject("renameSaveButton.Image");
			renameSaveButton.ImageTransparentColor = Color.Magenta;
			renameSaveButton.Name = "renameSaveButton";
			renameSaveButton.Overflow = ToolStripItemOverflow.Never;
			renameSaveButton.Size = new Size(79, 22);
			renameSaveButton.Text = "Rename...";
			renameSaveButton.ToolTipText = "Rename the selected save's description";
			renameSaveButton.Click += renameSaveButton_Click;
			// 
			// deleteSaveButton
			// 
			deleteSaveButton.Image = (Image)resources.GetObject("deleteSaveButton.Image");
			deleteSaveButton.ImageTransparentColor = Color.Magenta;
			deleteSaveButton.Name = "deleteSaveButton";
			deleteSaveButton.Overflow = ToolStripItemOverflow.Never;
			deleteSaveButton.Size = new Size(60, 22);
			deleteSaveButton.Text = "Delete";
			deleteSaveButton.ToolTipText = "Delete the selected save";
			deleteSaveButton.Click += deleteSaveButton_Click;
			// 
			// toolStrip1
			// 
			toolStrip1.AllowMerge = false;
			toolStrip1.CanOverflow = false;
			toolStrip1.Items.AddRange(new ToolStripItem[] { refreshSaveButton, toolStripSeparator1, newSaveButton, restoreSaveButton, renameSaveButton, deleteSaveButton });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.Size = new Size(734, 25);
			toolStrip1.TabIndex = 27;
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
			// saveList
			// 
			saveList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			saveList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
			saveList.FullRowSelect = true;
			saveList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			saveList.Location = new Point(16, 56);
			saveList.MultiSelect = false;
			saveList.Name = "saveList";
			saveList.Size = new Size(485, 420);
			saveList.TabIndex = 12;
			saveList.UseCompatibleStateImageBehavior = false;
			saveList.View = View.Details;
			saveList.SelectedIndexChanged += saveList_SelectedIndexChanged;
			// 
			// SaveSelectionPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(toolStrip1);
			Controls.Add(diskUsage);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(saveLabelIcon);
			Controls.Add(saveLabel);
			Controls.Add(savePreview);
			Controls.Add(backButton);
			Controls.Add(worldName);
			Controls.Add(label2);
			Controls.Add(saveList);
			Name = "SaveSelectionPage";
			Size = new Size(734, 537);
			((System.ComponentModel.ISupportInitialize)savePreview).EndInit();
			((System.ComponentModel.ISupportInitialize)saveLabelIcon).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label label2;
		private Label worldName;
		private Button backButton;
		private PictureBox savePreview;
		private Label saveLabel;
		private PictureBox saveLabelIcon;
		private Label label4;
		private Label label5;
		private Label diskUsage;
		private ToolStripButton refreshSaveButton;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton newSaveButton;
		private ToolStripButton restoreSaveButton;
		private ToolStripButton renameSaveButton;
		private ToolStripButton deleteSaveButton;
		private ToolStrip toolStrip1;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ListView saveList;
	}
}
