namespace SavepointManager.Forms
{
	partial class WorldSelectionPage
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldSelectionPage));
			nextButton = new Button();
			worldPreview = new PictureBox();
			label2 = new Label();
			label1 = new Label();
			worldList = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			columnHeader4 = new ColumnHeader();
			errorLabel = new Label();
			errorLabelIcon = new PictureBox();
			totalDiskUsage = new Label();
			label5 = new Label();
			toolStrip = new ToolStrip();
			refreshWorldButton = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			deleteWorldButton = new ToolStripButton();
			listContextMenu = new ContextMenuStrip(components);
			refreshToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			deleteToolStripMenuItem = new ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)worldPreview).BeginInit();
			((System.ComponentModel.ISupportInitialize)errorLabelIcon).BeginInit();
			toolStrip.SuspendLayout();
			listContextMenu.SuspendLayout();
			SuspendLayout();
			// 
			// nextButton
			// 
			nextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			nextButton.DialogResult = DialogResult.OK;
			nextButton.FlatStyle = FlatStyle.System;
			nextButton.Location = new Point(15, 493);
			nextButton.Name = "nextButton";
			nextButton.Size = new Size(112, 28);
			nextButton.TabIndex = 6;
			nextButton.Text = "&Next";
			// 
			// worldPreview
			// 
			worldPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			worldPreview.BorderStyle = BorderStyle.FixedSingle;
			worldPreview.Location = new Point(568, 56);
			worldPreview.Name = "worldPreview";
			worldPreview.Size = new Size(200, 200);
			worldPreview.SizeMode = PictureBoxSizeMode.Zoom;
			worldPreview.TabIndex = 8;
			worldPreview.TabStop = false;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label2.Location = new Point(568, 261);
			label2.Name = "label2";
			label2.Size = new Size(200, 15);
			label2.TabIndex = 5;
			label2.Text = "World preview";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 31);
			label1.Name = "label1";
			label1.Size = new Size(156, 15);
			label1.TabIndex = 1;
			label1.Text = "Select a world to begin with.";
			// 
			// worldList
			// 
			worldList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			worldList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
			worldList.FullRowSelect = true;
			worldList.Location = new Point(16, 56);
			worldList.MultiSelect = false;
			worldList.Name = "worldList";
			worldList.Size = new Size(535, 420);
			worldList.TabIndex = 4;
			worldList.UseCompatibleStateImageBehavior = false;
			worldList.View = View.Details;
			worldList.SelectedIndexChanged += saveList_SelectedIndexChanged;
			worldList.DoubleClick += worldList_DoubleClick;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Title";
			columnHeader1.Width = 220;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Gamemode";
			columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Active";
			// 
			// columnHeader4
			// 
			columnHeader4.Text = "Last played";
			columnHeader4.Width = 145;
			// 
			// errorLabel
			// 
			errorLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			errorLabel.AutoEllipsis = true;
			errorLabel.Location = new Point(175, 479);
			errorLabel.Name = "errorLabel";
			errorLabel.Size = new Size(593, 54);
			errorLabel.TabIndex = 7;
			errorLabel.TextAlign = ContentAlignment.MiddleLeft;
			errorLabel.Visible = false;
			errorLabel.TextChanged += errorLabel_TextChanged;
			// 
			// errorLabelIcon
			// 
			errorLabelIcon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			errorLabelIcon.Location = new Point(141, 493);
			errorLabelIcon.Name = "errorLabelIcon";
			errorLabelIcon.Size = new Size(28, 28);
			errorLabelIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			errorLabelIcon.TabIndex = 13;
			errorLabelIcon.TabStop = false;
			errorLabelIcon.Visible = false;
			// 
			// totalDiskUsage
			// 
			totalDiskUsage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			totalDiskUsage.AutoSize = true;
			totalDiskUsage.Location = new Point(553, 31);
			totalDiskUsage.Name = "totalDiskUsage";
			totalDiskUsage.Size = new Size(76, 15);
			totalDiskUsage.TabIndex = 3;
			totalDiskUsage.Text = "Calculating...";
			totalDiskUsage.TextAlign = ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label5.Location = new Point(430, 31);
			label5.Name = "label5";
			label5.Size = new Size(125, 15);
			label5.TabIndex = 2;
			label5.Text = "Total save disk usage:";
			// 
			// toolStrip
			// 
			toolStrip.AllowMerge = false;
			toolStrip.CanOverflow = false;
			toolStrip.Items.AddRange(new ToolStripItem[] { refreshWorldButton, toolStripSeparator1, deleteWorldButton });
			toolStrip.Location = new Point(0, 0);
			toolStrip.Name = "toolStrip";
			toolStrip.Size = new Size(784, 25);
			toolStrip.TabIndex = 0;
			// 
			// refreshWorldButton
			// 
			refreshWorldButton.Image = (Image)resources.GetObject("refreshWorldButton.Image");
			refreshWorldButton.ImageTransparentColor = Color.Magenta;
			refreshWorldButton.Name = "refreshWorldButton";
			refreshWorldButton.Overflow = ToolStripItemOverflow.Never;
			refreshWorldButton.Size = new Size(84, 22);
			refreshWorldButton.Text = "Refresh list";
			refreshWorldButton.ToolTipText = "Refreshes the world list.";
			refreshWorldButton.Click += refreshListButton_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Overflow = ToolStripItemOverflow.Never;
			toolStripSeparator1.Size = new Size(6, 25);
			// 
			// deleteWorldButton
			// 
			deleteWorldButton.Image = (Image)resources.GetObject("deleteWorldButton.Image");
			deleteWorldButton.ImageTransparentColor = Color.Magenta;
			deleteWorldButton.Name = "deleteWorldButton";
			deleteWorldButton.Overflow = ToolStripItemOverflow.Never;
			deleteWorldButton.Size = new Size(69, 22);
			deleteWorldButton.Text = "Delete...";
			deleteWorldButton.ToolTipText = "Deletes the selected world and all of its saves.";
			deleteWorldButton.Click += deleteWorldButton_Click;
			// 
			// listContextMenu
			// 
			listContextMenu.Items.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, toolStripMenuItem1, deleteToolStripMenuItem });
			listContextMenu.Name = "listContextMenu";
			listContextMenu.Size = new Size(141, 54);
			listContextMenu.Opening += listContextMenu_Opening;
			// 
			// refreshToolStripMenuItem
			// 
			refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
			refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
			refreshToolStripMenuItem.Size = new Size(140, 22);
			refreshToolStripMenuItem.Text = "&Refresh";
			refreshToolStripMenuItem.ToolTipText = "Refreshes the world list.";
			refreshToolStripMenuItem.Click += refreshListButton_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(137, 6);
			// 
			// deleteToolStripMenuItem
			// 
			deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
			deleteToolStripMenuItem.Size = new Size(140, 22);
			deleteToolStripMenuItem.Text = "&Delete...";
			deleteToolStripMenuItem.ToolTipText = "Deletes the selected world and all of its saves.";
			deleteToolStripMenuItem.Click += deleteWorldButton_Click;
			// 
			// WorldSelectionPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ContextMenuStrip = listContextMenu;
			Controls.Add(toolStrip);
			Controls.Add(totalDiskUsage);
			Controls.Add(label5);
			Controls.Add(errorLabelIcon);
			Controls.Add(errorLabel);
			Controls.Add(worldList);
			Controls.Add(nextButton);
			Controls.Add(worldPreview);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "WorldSelectionPage";
			Size = new Size(784, 537);
			((System.ComponentModel.ISupportInitialize)worldPreview).EndInit();
			((System.ComponentModel.ISupportInitialize)errorLabelIcon).EndInit();
			toolStrip.ResumeLayout(false);
			toolStrip.PerformLayout();
			listContextMenu.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label label2;
		private Label label1;
		private PictureBox worldPreview;
		private ListView worldList;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private Button nextButton;
		private Label errorLabel;
		private PictureBox errorLabelIcon;
		private Label totalDiskUsage;
		private Label label5;
		private ToolStrip toolStrip;
		private ToolStripButton refreshWorldButton;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton deleteWorldButton;
		private ContextMenuStrip listContextMenu;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem refreshToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem1;
		private ColumnHeader columnHeader4;
	}
}
