namespace PZSaveManager.Forms
{
	partial class SaveOptionsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveOptionsForm));
            groupBox1 = new GroupBox();
            warningIcon = new PictureBox();
            label7 = new Label();
            clearAbortSaveHotkeyButton = new Button();
            clearSaveHotkeyButton = new Button();
            abortSaveHotkey = new TextBox();
            saveHotkey = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            label4 = new Label();
            autosaveInterval = new TextBox();
            label3 = new Label();
            enableAutosave = new CheckBox();
            toolTip = new ToolTip(components);
            backupPath = new TextBox();
            useSaveSounds = new CheckBox();
            duserPath = new TextBox();
            groupBox3 = new GroupBox();
            label9 = new Label();
            browseDuserPathButton = new Button();
            label8 = new Label();
            saveRelocationLabel = new Label();
            useCompression = new CheckBox();
            browseBackupPathButton = new Button();
            label5 = new Label();
            compressToolTip = new ToolTip(components);
            backupPathBrowser = new FolderBrowserDialog();
            groupBox4 = new GroupBox();
            previewButton = new Button();
            soundVolumeLabel = new Label();
            soundVolume = new TrackBar();
            label6 = new Label();
            panel1 = new Panel();
            resetButton = new Button();
            cancelButton = new Button();
            okButton = new Button();
            mainPanel = new Panel();
            duserPathBrowser = new FolderBrowserDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)warningIcon).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)soundVolume).BeginInit();
            panel1.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(warningIcon);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(clearAbortSaveHotkeyButton);
            groupBox1.Controls.Add(clearSaveHotkeyButton);
            groupBox1.Controls.Add(abortSaveHotkey);
            groupBox1.Controls.Add(saveHotkey);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(8, 400);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(376, 124);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Hotkeys";
            // 
            // warningIcon
            // 
            warningIcon.Location = new Point(16, 88);
            warningIcon.Name = "warningIcon";
            warningIcon.Size = new Size(24, 24);
            warningIcon.SizeMode = PictureBoxSizeMode.Zoom;
            warningIcon.TabIndex = 8;
            warningIcon.TabStop = false;
            toolTip.SetToolTip(warningIcon, resources.GetString("warningIcon.ToolTip"));
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(40, 88);
            label7.Name = "label7";
            label7.Size = new Size(160, 24);
            label7.TabIndex = 6;
            label7.Text = "Warning (hover for details)";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            toolTip.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // clearAbortSaveHotkeyButton
            // 
            clearAbortSaveHotkeyButton.FlatStyle = FlatStyle.System;
            clearAbortSaveHotkeyButton.Location = new Point(288, 55);
            clearAbortSaveHotkeyButton.Name = "clearAbortSaveHotkeyButton";
            clearAbortSaveHotkeyButton.Size = new Size(72, 26);
            clearAbortSaveHotkeyButton.TabIndex = 5;
            clearAbortSaveHotkeyButton.Text = "Clear";
            clearAbortSaveHotkeyButton.UseVisualStyleBackColor = true;
            clearAbortSaveHotkeyButton.Click += clearAbortSaveHotkeyButton_Click;
            // 
            // clearSaveHotkeyButton
            // 
            clearSaveHotkeyButton.FlatStyle = FlatStyle.System;
            clearSaveHotkeyButton.Location = new Point(288, 23);
            clearSaveHotkeyButton.Name = "clearSaveHotkeyButton";
            clearSaveHotkeyButton.Size = new Size(72, 26);
            clearSaveHotkeyButton.TabIndex = 2;
            clearSaveHotkeyButton.Text = "Clear";
            clearSaveHotkeyButton.UseVisualStyleBackColor = true;
            clearSaveHotkeyButton.Click += clearSaveHotkeyButton_Click;
            // 
            // abortSaveHotkey
            // 
            abortSaveHotkey.Location = new Point(128, 56);
            abortSaveHotkey.Name = "abortSaveHotkey";
            abortSaveHotkey.ReadOnly = true;
            abortSaveHotkey.Size = new Size(152, 23);
            abortSaveHotkey.TabIndex = 4;
            abortSaveHotkey.KeyDown += saveHotkey_KeyDown;
            // 
            // saveHotkey
            // 
            saveHotkey.Location = new Point(128, 24);
            saveHotkey.Name = "saveHotkey";
            saveHotkey.ReadOnly = true;
            saveHotkey.Size = new Size(152, 23);
            saveHotkey.TabIndex = 1;
            saveHotkey.KeyDown += saveHotkey_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 28);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Save &hotkey:";
            toolTip.SetToolTip(label1, "Used to select the key that triggers a manual save on the active world when pressed.\r\nIf this feature is not desired, please select \"None\".\r\n");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 60);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 3;
            label2.Text = "&Abort save hotkey:";
            toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(autosaveInterval);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(enableAutosave);
            groupBox2.Location = new Point(8, 532);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(376, 88);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Auto-save";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(172, 56);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 3;
            label4.Text = "minutes";
            // 
            // autosaveInterval
            // 
            autosaveInterval.Location = new Point(128, 52);
            autosaveInterval.Name = "autosaveInterval";
            autosaveInterval.Size = new Size(40, 23);
            autosaveInterval.TabIndex = 2;
            toolTip.SetToolTip(autosaveInterval, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 56);
            label3.Name = "label3";
            label3.Size = new Size(106, 15);
            label3.TabIndex = 1;
            label3.Text = "A&uto-save interval:";
            toolTip.SetToolTip(label3, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
            // 
            // enableAutosave
            // 
            enableAutosave.AutoSize = true;
            enableAutosave.Location = new Point(19, 24);
            enableAutosave.Name = "enableAutosave";
            enableAutosave.Size = new Size(116, 19);
            enableAutosave.TabIndex = 0;
            enableAutosave.Text = "E&nable auto-save";
            toolTip.SetToolTip(enableAutosave, "Auto-save automatically saves the active world within the time interval specified below (e.g. every 10 minutes).");
            enableAutosave.UseVisualStyleBackColor = true;
            enableAutosave.CheckedChanged += enableAutosave_CheckedChanged;
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 12000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 100;
            // 
            // backupPath
            // 
            backupPath.Location = new Point(19, 151);
            backupPath.Name = "backupPath";
            backupPath.ReadOnly = true;
            backupPath.Size = new Size(237, 23);
            backupPath.TabIndex = 1;
            toolTip.SetToolTip(backupPath, "Specifies the path that save backups will be loaded from and written to. The chosen path should be located on the C: drive for optimal performance.");
            // 
            // useSaveSounds
            // 
            useSaveSounds.AutoSize = true;
            useSaveSounds.Location = new Point(18, 24);
            useSaveSounds.Name = "useSaveSounds";
            useSaveSounds.Size = new Size(132, 19);
            useSaveSounds.TabIndex = 0;
            useSaveSounds.Text = "Enable save &narrator";
            toolTip.SetToolTip(useSaveSounds, "Plays sound effects when saving a world begins, succeeds, fails, or gets canceled. This setting only affects the manual & automatic save functions.");
            useSaveSounds.UseVisualStyleBackColor = true;
            useSaveSounds.CheckedChanged += useSaveSounds_CheckedChanged;
            // 
            // duserPath
            // 
            duserPath.Location = new Point(19, 48);
            duserPath.Name = "duserPath";
            duserPath.ReadOnly = true;
            duserPath.Size = new Size(237, 23);
            duserPath.TabIndex = 6;
            toolTip.SetToolTip(duserPath, "Specifies the path that save backups will be loaded from and written to. The chosen path should be located on the C: drive for optimal performance.");
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(browseDuserPathButton);
            groupBox3.Controls.Add(duserPath);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(saveRelocationLabel);
            groupBox3.Controls.Add(useCompression);
            groupBox3.Controls.Add(browseBackupPathButton);
            groupBox3.Controls.Add(backupPath);
            groupBox3.Controls.Add(label5);
            groupBox3.Location = new Point(8, 8);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(376, 256);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "General Options";
            // 
            // label9
            // 
            label9.Location = new Point(16, 80);
            label9.Name = "label9";
            label9.Size = new Size(344, 32);
            label9.TabIndex = 8;
            label9.Text = "Note: Only change this if you've customized the \"Duser.home\" path in ProjectZomboid32/64.json. Don't change otherwise.";
            // 
            // browseDuserPathButton
            // 
            browseDuserPathButton.FlatStyle = FlatStyle.System;
            browseDuserPathButton.Location = new Point(264, 47);
            browseDuserPathButton.Name = "browseDuserPathButton";
            browseDuserPathButton.Size = new Size(96, 26);
            browseDuserPathButton.TabIndex = 7;
            browseDuserPathButton.Text = "&Browse...";
            browseDuserPathButton.UseVisualStyleBackColor = true;
            browseDuserPathButton.Click += browseDuserPathButton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(16, 24);
            label8.Name = "label8";
            label8.Size = new Size(101, 15);
            label8.TabIndex = 5;
            label8.Text = "Duser.home path:";
            // 
            // saveRelocationLabel
            // 
            saveRelocationLabel.Location = new Point(16, 181);
            saveRelocationLabel.Name = "saveRelocationLabel";
            saveRelocationLabel.Size = new Size(344, 35);
            saveRelocationLabel.TabIndex = 3;
            saveRelocationLabel.Text = "Note: If this is changed, all saves will be moved to the new path after you click 'OK'. This might take some time.";
            // 
            // useCompression
            // 
            useCompression.AutoSize = true;
            useCompression.Location = new Point(19, 224);
            useCompression.Name = "useCompression";
            useCompression.Size = new Size(254, 19);
            useCompression.TabIndex = 4;
            useCompression.Text = "&Enable save compression (hover for details)";
            compressToolTip.SetToolTip(useCompression, resources.GetString("useCompression.ToolTip"));
            useCompression.UseVisualStyleBackColor = true;
            // 
            // browseBackupPathButton
            // 
            browseBackupPathButton.FlatStyle = FlatStyle.System;
            browseBackupPathButton.Location = new Point(264, 150);
            browseBackupPathButton.Name = "browseBackupPathButton";
            browseBackupPathButton.Size = new Size(96, 26);
            browseBackupPathButton.TabIndex = 2;
            browseBackupPathButton.Text = "Bro&wse...";
            browseBackupPathButton.UseVisualStyleBackColor = true;
            browseBackupPathButton.Click += browseBackupPathButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 128);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 0;
            label5.Text = "Save backup path:";
            // 
            // compressToolTip
            // 
            compressToolTip.AutoPopDelay = 32000;
            compressToolTip.InitialDelay = 500;
            compressToolTip.ReshowDelay = 100;
            compressToolTip.ToolTipIcon = ToolTipIcon.Info;
            compressToolTip.ToolTipTitle = "Compress save data";
            // 
            // backupPathBrowser
            // 
            backupPathBrowser.Description = "Save Backup Path";
            backupPathBrowser.UseDescriptionForTitle = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(previewButton);
            groupBox4.Controls.Add(soundVolumeLabel);
            groupBox4.Controls.Add(soundVolume);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(useSaveSounds);
            groupBox4.Location = new Point(8, 272);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(376, 120);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "Save Narrator";
            // 
            // previewButton
            // 
            previewButton.FlatStyle = FlatStyle.System;
            previewButton.Location = new Point(264, 23);
            previewButton.Name = "previewButton";
            previewButton.Size = new Size(96, 26);
            previewButton.TabIndex = 4;
            previewButton.Text = "&Preview";
            previewButton.UseVisualStyleBackColor = true;
            previewButton.Click += previewButton_Click;
            // 
            // soundVolumeLabel
            // 
            soundVolumeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            soundVolumeLabel.Location = new Point(320, 80);
            soundVolumeLabel.Name = "soundVolumeLabel";
            soundVolumeLabel.Size = new Size(40, 24);
            soundVolumeLabel.TabIndex = 3;
            soundVolumeLabel.Text = "50%";
            soundVolumeLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // soundVolume
            // 
            soundVolume.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            soundVolume.AutoSize = false;
            soundVolume.LargeChange = 20;
            soundVolume.Location = new Point(8, 80);
            soundVolume.Maximum = 100;
            soundVolume.Name = "soundVolume";
            soundVolume.Size = new Size(318, 36);
            soundVolume.SmallChange = 10;
            soundVolume.TabIndex = 2;
            soundVolume.TickFrequency = 10;
            soundVolume.Value = 50;
            soundVolume.ValueChanged += soundVolume_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 56);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 1;
            label6.Text = "&Sound volume:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(resetButton);
            panel1.Controls.Add(cancelButton);
            panel1.Controls.Add(okButton);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 528);
            panel1.Name = "panel1";
            panel1.Size = new Size(408, 57);
            panel1.TabIndex = 4;
            // 
            // resetButton
            // 
            resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            resetButton.FlatStyle = FlatStyle.System;
            resetButton.Location = new Point(16, 16);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(104, 28);
            resetButton.TabIndex = 1;
            resetButton.Text = "&Reset all";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.FlatStyle = FlatStyle.System;
            cancelButton.Location = new Point(296, 16);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(96, 28);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "&Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.FlatStyle = FlatStyle.System;
            okButton.Location = new Point(196, 16);
            okButton.Name = "okButton";
            okButton.Size = new Size(96, 28);
            okButton.TabIndex = 2;
            okButton.Text = "&OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.AutoScrollMinSize = new Size(0, 636);
            mainPanel.Controls.Add(groupBox3);
            mainPanel.Controls.Add(groupBox1);
            mainPanel.Controls.Add(groupBox4);
            mainPanel.Controls.Add(groupBox2);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(408, 528);
            mainPanel.TabIndex = 5;
            // 
            // duserPathBrowser
            // 
            duserPathBrowser.Description = "Duser Path";
            duserPathBrowser.UseDescriptionForTitle = true;
            // 
            // SaveOptionsForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = cancelButton;
            ClientSize = new Size(408, 585);
            Controls.Add(mainPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(270, 340);
            Name = "SaveOptionsForm";
            ShowIcon = false;
            Text = "Save Options";
            Shown += SaveOptionsForm_Shown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)warningIcon).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)soundVolume).EndInit();
            panel1.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
		private Label label1;
		private GroupBox groupBox2;
		private CheckBox enableAutosave;
		private Label label3;
		private TextBox autosaveInterval;
		private Label label4;
		private Label label2;
		private ToolTip toolTip;
		private GroupBox groupBox3;
		private Label label5;
		private TextBox backupPath;
		private Button browseBackupPathButton;
		private CheckBox useCompression;
		private ToolTip compressToolTip;
		private FolderBrowserDialog backupPathBrowser;
		private Label saveRelocationLabel;
		private GroupBox groupBox4;
		private CheckBox useSaveSounds;
		private Label label6;
		private TrackBar soundVolume;
		private Label soundVolumeLabel;
		private Button previewButton;
		private Panel panel1;
		private Button resetButton;
		private Button cancelButton;
		private Button okButton;
		private TextBox saveHotkey;
		private TextBox abortSaveHotkey;
		private Button clearAbortSaveHotkeyButton;
		private Button clearSaveHotkeyButton;
		private PictureBox warningIcon;
		private Label label7;
        private Panel mainPanel;
        private Button browseDuserPathButton;
        private TextBox duserPath;
        private Label label8;
        private Label label9;
        private FolderBrowserDialog duserPathBrowser;
    }
}