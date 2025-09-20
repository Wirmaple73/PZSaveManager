namespace PZSaveManager.Pages
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
            components = new System.ComponentModel.Container();
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
            toolStrip = new ToolStrip();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            saveList = new ListView();
            listContextMenu = new ContextMenuStrip(components);
            refreshToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            newToolStripMenuItem = new ToolStripMenuItem();
            restoreToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            viewInExplorerToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)savePreview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saveLabelIcon).BeginInit();
            toolStrip.SuspendLayout();
            listContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(13, 32);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "World:";
            // 
            // worldName
            // 
            worldName.AutoEllipsis = true;
            worldName.Location = new Point(54, 32);
            worldName.Name = "worldName";
            worldName.Size = new Size(353, 15);
            worldName.TabIndex = 2;
            worldName.Text = "Fetching...";
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            backButton.DialogResult = DialogResult.OK;
            backButton.FlatStyle = FlatStyle.System;
            backButton.Location = new Point(15, 493);
            backButton.Name = "backButton";
            backButton.Size = new Size(112, 28);
            backButton.TabIndex = 7;
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
            saveLabel.BackColor = Color.Transparent;
            saveLabel.Location = new Point(175, 479);
            saveLabel.Name = "saveLabel";
            saveLabel.Size = new Size(543, 54);
            saveLabel.TabIndex = 8;
            saveLabel.Text = "No saves have been created yet. If this is not the case and you have changed the save backup path recently, please make sure it is set correctly by navigating to Options > Configure Save Options.";
            saveLabel.TextAlign = ContentAlignment.MiddleLeft;
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
            label4.TabIndex = 6;
            label4.Text = "Preview may not be fully accurate.";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(408, 32);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 3;
            label5.Text = "Save disk usage:";
            // 
            // diskUsage
            // 
            diskUsage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            diskUsage.AutoSize = true;
            diskUsage.Location = new Point(503, 32);
            diskUsage.Name = "diskUsage";
            diskUsage.Size = new Size(76, 15);
            diskUsage.TabIndex = 4;
            diskUsage.Text = "Calculating...";
            diskUsage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // refreshSaveButton
            // 
            refreshSaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            refreshSaveButton.Image = Properties.Resources.RefreshList;
            refreshSaveButton.ImageTransparentColor = Color.Magenta;
            refreshSaveButton.Name = "refreshSaveButton";
            refreshSaveButton.Overflow = ToolStripItemOverflow.Never;
            refreshSaveButton.Size = new Size(23, 22);
            refreshSaveButton.Text = "Refresh list";
            refreshSaveButton.ToolTipText = "Refreshes the save list.";
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
            newSaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newSaveButton.Image = Properties.Resources.New;
            newSaveButton.ImageTransparentColor = Color.Magenta;
            newSaveButton.Name = "newSaveButton";
            newSaveButton.Overflow = ToolStripItemOverflow.Never;
            newSaveButton.Size = new Size(23, 22);
            newSaveButton.Text = "New...";
            newSaveButton.ToolTipText = "Saves your current progress.";
            newSaveButton.Click += newSaveButton_Click;
            // 
            // restoreSaveButton
            // 
            restoreSaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            restoreSaveButton.Enabled = false;
            restoreSaveButton.Image = Properties.Resources.Restore;
            restoreSaveButton.ImageTransparentColor = Color.Magenta;
            restoreSaveButton.Name = "restoreSaveButton";
            restoreSaveButton.Overflow = ToolStripItemOverflow.Never;
            restoreSaveButton.Size = new Size(23, 22);
            restoreSaveButton.Text = "Restore...";
            restoreSaveButton.ToolTipText = "Discards all current unsaved progress and rolls back your progress to the selected save.";
            restoreSaveButton.Click += restoreSaveButton_Click;
            // 
            // renameSaveButton
            // 
            renameSaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            renameSaveButton.Enabled = false;
            renameSaveButton.Image = Properties.Resources.Rename;
            renameSaveButton.ImageTransparentColor = Color.Magenta;
            renameSaveButton.Name = "renameSaveButton";
            renameSaveButton.Overflow = ToolStripItemOverflow.Never;
            renameSaveButton.Size = new Size(23, 22);
            renameSaveButton.Text = "Rename...";
            renameSaveButton.ToolTipText = "Renames the description of the selected save.";
            renameSaveButton.Click += renameSaveButton_Click;
            // 
            // deleteSaveButton
            // 
            deleteSaveButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            deleteSaveButton.Enabled = false;
            deleteSaveButton.Image = Properties.Resources.Delete;
            deleteSaveButton.ImageTransparentColor = Color.Magenta;
            deleteSaveButton.Name = "deleteSaveButton";
            deleteSaveButton.Overflow = ToolStripItemOverflow.Never;
            deleteSaveButton.Size = new Size(23, 22);
            deleteSaveButton.Text = "Delete...";
            deleteSaveButton.ToolTipText = "Deletes the selected save.";
            deleteSaveButton.Click += deleteSaveButton_Click;
            // 
            // toolStrip
            // 
            toolStrip.AllowMerge = false;
            toolStrip.BackColor = SystemColors.Window;
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { refreshSaveButton, toolStripSeparator1, newSaveButton, restoreSaveButton, renameSaveButton, deleteSaveButton });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new Padding(13, 0, 1, 0);
            toolStrip.Size = new Size(734, 25);
            toolStrip.TabIndex = 0;
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
            saveList.AllowColumnReorder = true;
            saveList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            saveList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            saveList.ContextMenuStrip = listContextMenu;
            saveList.FullRowSelect = true;
            saveList.Location = new Point(16, 56);
            saveList.MultiSelect = false;
            saveList.Name = "saveList";
            saveList.Size = new Size(485, 420);
            saveList.TabIndex = 5;
            saveList.UseCompatibleStateImageBehavior = false;
            saveList.View = View.Details;
            saveList.SelectedIndexChanged += saveList_SelectedIndexChanged;
            // 
            // listContextMenu
            // 
            listContextMenu.Items.AddRange(new ToolStripItem[] { refreshToolStripMenuItem, toolStripMenuItem1, newToolStripMenuItem, restoreToolStripMenuItem, renameToolStripMenuItem, deleteToolStripMenuItem, toolStripMenuItem2, viewInExplorerToolStripMenuItem });
            listContextMenu.Name = "listContextMenu";
            listContextMenu.Size = new Size(164, 148);
            listContextMenu.Opening += listContextMenu_Opening;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.ShortcutKeys = Keys.F5;
            refreshToolStripMenuItem.Size = new Size(163, 22);
            refreshToolStripMenuItem.Text = "&Refresh";
            refreshToolStripMenuItem.ToolTipText = "Refreshes the save list.";
            refreshToolStripMenuItem.Click += refreshListButton_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(160, 6);
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(163, 22);
            newToolStripMenuItem.Text = "&New...";
            newToolStripMenuItem.ToolTipText = "Saves your current progress.";
            newToolStripMenuItem.Click += newSaveButton_Click;
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            restoreToolStripMenuItem.Size = new Size(163, 22);
            restoreToolStripMenuItem.Text = "Re&store...";
            restoreToolStripMenuItem.ToolTipText = "Discards all current unsaved progress and rolls back your progress to the selected save.";
            restoreToolStripMenuItem.Click += restoreSaveButton_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.ShortcutKeys = Keys.F2;
            renameToolStripMenuItem.Size = new Size(163, 22);
            renameToolStripMenuItem.Text = "R&ename...";
            renameToolStripMenuItem.ToolTipText = "Renames the description of the selected save.";
            renameToolStripMenuItem.Click += renameSaveButton_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(163, 22);
            deleteToolStripMenuItem.Text = "&Delete...";
            deleteToolStripMenuItem.ToolTipText = "Deletes the selected save.";
            deleteToolStripMenuItem.Click += deleteSaveButton_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(160, 6);
            // 
            // viewInExplorerToolStripMenuItem
            // 
            viewInExplorerToolStripMenuItem.Name = "viewInExplorerToolStripMenuItem";
            viewInExplorerToolStripMenuItem.Size = new Size(163, 22);
            viewInExplorerToolStripMenuItem.Text = "&View in Explorer";
            viewInExplorerToolStripMenuItem.Click += viewInExplorerToolStripMenuItem_Click;
            // 
            // SaveSelectionPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(toolStrip);
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
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            listContextMenu.ResumeLayout(false);
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
		private ToolStrip toolStrip;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ListView saveList;
		private ContextMenuStrip listContextMenu;
		private ToolStripMenuItem newToolStripMenuItem;
		private ToolStripMenuItem restoreToolStripMenuItem;
		private ToolStripMenuItem renameToolStripMenuItem;
		private ToolStripMenuItem deleteToolStripMenuItem;
		private ToolStripMenuItem refreshToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripMenuItem viewInExplorerToolStripMenuItem;
	}
}
