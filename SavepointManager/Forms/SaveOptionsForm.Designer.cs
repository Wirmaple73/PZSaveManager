namespace SavepointManager.Forms
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
			saveHotkeys = new ComboBox();
			label1 = new Label();
			label2 = new Label();
			abortSaveHotkeys = new ComboBox();
			groupBox2 = new GroupBox();
			label4 = new Label();
			autosaveInterval = new TextBox();
			label3 = new Label();
			enableAutosave = new CheckBox();
			toolTip = new ToolTip(components);
			backupPath = new TextBox();
			useSaveSounds = new CheckBox();
			groupBox3 = new GroupBox();
			saveRelocationLabel = new Label();
			useCompression = new CheckBox();
			browseButton = new Button();
			label5 = new Label();
			compressToolTip = new ToolTip(components);
			folderBrowser = new FolderBrowserDialog();
			groupBox4 = new GroupBox();
			previewButton = new Button();
			soundVolumeLabel = new Label();
			soundVolume = new TrackBar();
			label6 = new Label();
			panel1 = new Panel();
			resetButton = new Button();
			cancelButton = new Button();
			okButton = new Button();
			progressBar = new ProgressBar();
			deleteButton = new Button();
			button1 = new Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)soundVolume).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(saveHotkeys);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(abortSaveHotkeys);
			groupBox1.Location = new Point(12, 298);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(361, 88);
			groupBox1.TabIndex = 2;
			groupBox1.TabStop = false;
			groupBox1.Text = "Hotkeys";
			// 
			// saveHotkeys
			// 
			saveHotkeys.DropDownStyle = ComboBoxStyle.DropDownList;
			saveHotkeys.FormattingEnabled = true;
			saveHotkeys.Location = new Point(122, 21);
			saveHotkeys.Name = "saveHotkeys";
			saveHotkeys.Size = new Size(105, 23);
			saveHotkeys.TabIndex = 1;
			toolTip.SetToolTip(saveHotkeys, "Used to select the key that triggers a manual save on the active world when pressed.\r\nIf this feature is not desired, please select \"None\".");
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 24);
			label1.Name = "label1";
			label1.Size = new Size(73, 15);
			label1.TabIndex = 0;
			label1.Text = "Save &hotkey:";
			toolTip.SetToolTip(label1, "Used to select the key that triggers a manual save on the active world when pressed.\r\nIf this feature is not desired, please select \"None\".\r\n");
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 56);
			label2.Name = "label2";
			label2.Size = new Size(105, 15);
			label2.TabIndex = 2;
			label2.Text = "&Abort save hotkey:";
			toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
			// 
			// abortSaveHotkeys
			// 
			abortSaveHotkeys.DropDownStyle = ComboBoxStyle.DropDownList;
			abortSaveHotkeys.FormattingEnabled = true;
			abortSaveHotkeys.Location = new Point(122, 53);
			abortSaveHotkeys.Name = "abortSaveHotkeys";
			abortSaveHotkeys.Size = new Size(105, 23);
			abortSaveHotkeys.TabIndex = 3;
			toolTip.SetToolTip(abortSaveHotkeys, resources.GetString("abortSaveHotkeys.ToolTip"));
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(autosaveInterval);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(enableAutosave);
			groupBox2.Location = new Point(12, 392);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(361, 84);
			groupBox2.TabIndex = 3;
			groupBox2.TabStop = false;
			groupBox2.Text = "Auto-save";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(164, 52);
			label4.Name = "label4";
			label4.Size = new Size(50, 15);
			label4.TabIndex = 3;
			label4.Text = "minutes";
			// 
			// autosaveInterval
			// 
			autosaveInterval.Location = new Point(122, 48);
			autosaveInterval.Name = "autosaveInterval";
			autosaveInterval.Size = new Size(40, 23);
			autosaveInterval.TabIndex = 2;
			toolTip.SetToolTip(autosaveInterval, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(14, 52);
			label3.Name = "label3";
			label3.Size = new Size(106, 15);
			label3.TabIndex = 1;
			label3.Text = "A&uto-save interval:";
			toolTip.SetToolTip(label3, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
			// 
			// enableAutosave
			// 
			enableAutosave.AutoSize = true;
			enableAutosave.Location = new Point(17, 23);
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
			toolTip.AutoPopDelay = 8000;
			toolTip.InitialDelay = 500;
			toolTip.ReshowDelay = 100;
			// 
			// backupPath
			// 
			backupPath.Location = new Point(16, 45);
			backupPath.Name = "backupPath";
			backupPath.ReadOnly = true;
			backupPath.Size = new Size(240, 23);
			backupPath.TabIndex = 1;
			toolTip.SetToolTip(backupPath, "Specifies the path that save backups will be loaded from and written to. The chosen path should be located on the C: drive for optimal performance.");
			// 
			// useSaveSounds
			// 
			useSaveSounds.AutoSize = true;
			useSaveSounds.Location = new Point(16, 26);
			useSaveSounds.Name = "useSaveSounds";
			useSaveSounds.Size = new Size(161, 19);
			useSaveSounds.TabIndex = 0;
			useSaveSounds.Text = "&Enable save sound effects";
			toolTip.SetToolTip(useSaveSounds, "Plays sound effects when saving a world begins, succeeds, fails, or gets canceled. This setting only affects the manual & automatic save functions.");
			useSaveSounds.UseVisualStyleBackColor = true;
			useSaveSounds.CheckedChanged += useSaveSounds_CheckedChanged;
			// 
			// groupBox3
			// 
			groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox3.Controls.Add(saveRelocationLabel);
			groupBox3.Controls.Add(useCompression);
			groupBox3.Controls.Add(browseButton);
			groupBox3.Controls.Add(backupPath);
			groupBox3.Controls.Add(label5);
			groupBox3.Location = new Point(12, 12);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(360, 146);
			groupBox3.TabIndex = 0;
			groupBox3.TabStop = false;
			groupBox3.Text = "General Options";
			// 
			// saveRelocationLabel
			// 
			saveRelocationLabel.Location = new Point(13, 75);
			saveRelocationLabel.Name = "saveRelocationLabel";
			saveRelocationLabel.Size = new Size(332, 33);
			saveRelocationLabel.TabIndex = 3;
			saveRelocationLabel.Text = "Note: If this is changed, all saves will be moved to the new path after you click 'OK'. This might take some time.";
			// 
			// useCompression
			// 
			useCompression.AutoSize = true;
			useCompression.Location = new Point(16, 117);
			useCompression.Name = "useCompression";
			useCompression.Size = new Size(131, 19);
			useCompression.TabIndex = 4;
			useCompression.Text = "Compress save &data";
			compressToolTip.SetToolTip(useCompression, resources.GetString("useCompression.ToolTip"));
			useCompression.UseVisualStyleBackColor = true;
			// 
			// browseButton
			// 
			browseButton.FlatStyle = FlatStyle.System;
			browseButton.Location = new Point(262, 44);
			browseButton.Name = "browseButton";
			browseButton.Size = new Size(83, 25);
			browseButton.TabIndex = 2;
			browseButton.Text = "&Browse...";
			browseButton.UseVisualStyleBackColor = true;
			browseButton.Click += browseButton_Click;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(13, 25);
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
			// folderBrowser
			// 
			folderBrowser.Description = "Save Backup Path";
			folderBrowser.UseDescriptionForTitle = true;
			// 
			// groupBox4
			// 
			groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox4.Controls.Add(previewButton);
			groupBox4.Controls.Add(soundVolumeLabel);
			groupBox4.Controls.Add(soundVolume);
			groupBox4.Controls.Add(label6);
			groupBox4.Controls.Add(useSaveSounds);
			groupBox4.Location = new Point(12, 164);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(361, 128);
			groupBox4.TabIndex = 1;
			groupBox4.TabStop = false;
			groupBox4.Text = "Save Audio";
			// 
			// previewButton
			// 
			previewButton.FlatStyle = FlatStyle.System;
			previewButton.Location = new Point(262, 23);
			previewButton.Name = "previewButton";
			previewButton.Size = new Size(83, 25);
			previewButton.TabIndex = 4;
			previewButton.Text = "&Preview";
			previewButton.UseVisualStyleBackColor = true;
			previewButton.Click += previewButton_Click;
			// 
			// soundVolumeLabel
			// 
			soundVolumeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			soundVolumeLabel.Location = new Point(322, 78);
			soundVolumeLabel.Name = "soundVolumeLabel";
			soundVolumeLabel.Size = new Size(37, 23);
			soundVolumeLabel.TabIndex = 3;
			soundVolumeLabel.Text = "80%";
			soundVolumeLabel.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// soundVolume
			// 
			soundVolume.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			soundVolume.LargeChange = 20;
			soundVolume.Location = new Point(6, 80);
			soundVolume.Maximum = 100;
			soundVolume.Name = "soundVolume";
			soundVolume.Size = new Size(316, 45);
			soundVolume.SmallChange = 10;
			soundVolume.TabIndex = 2;
			soundVolume.TickFrequency = 10;
			soundVolume.Value = 80;
			soundVolume.ValueChanged += soundVolume_ValueChanged;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(12, 60);
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
			panel1.Controls.Add(progressBar);
			panel1.Controls.Add(deleteButton);
			panel1.Controls.Add(button1);
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(0, 492);
			panel1.Name = "panel1";
			panel1.Size = new Size(384, 54);
			panel1.TabIndex = 4;
			// 
			// resetButton
			// 
			resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			resetButton.FlatStyle = FlatStyle.System;
			resetButton.Location = new Point(12, 14);
			resetButton.Name = "resetButton";
			resetButton.Size = new Size(110, 28);
			resetButton.TabIndex = 1;
			resetButton.Text = "&Reset all";
			resetButton.UseVisualStyleBackColor = true;
			resetButton.Click += resetButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cancelButton.FlatStyle = FlatStyle.System;
			cancelButton.Location = new Point(277, 14);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(97, 28);
			cancelButton.TabIndex = 3;
			cancelButton.Text = "&Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			okButton.FlatStyle = FlatStyle.System;
			okButton.Location = new Point(170, 14);
			okButton.Name = "okButton";
			okButton.Size = new Size(97, 28);
			okButton.TabIndex = 2;
			okButton.Text = "&OK";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += okButton_Click;
			// 
			// progressBar
			// 
			progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			progressBar.Location = new Point(12, -27);
			progressBar.MarqueeAnimationSpeed = 10;
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(492, 26);
			progressBar.Style = ProgressBarStyle.Marquee;
			progressBar.TabIndex = 0;
			progressBar.Visible = false;
			// 
			// deleteButton
			// 
			deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deleteButton.Enabled = false;
			deleteButton.FlatStyle = FlatStyle.System;
			deleteButton.Location = new Point(518, -28);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(86, 28);
			deleteButton.TabIndex = 8;
			deleteButton.Text = "&Delete";
			deleteButton.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			button1.FlatStyle = FlatStyle.System;
			button1.Location = new Point(610, -28);
			button1.Name = "button1";
			button1.Size = new Size(86, 28);
			button1.TabIndex = 9;
			button1.Text = "&Cancel";
			button1.UseVisualStyleBackColor = true;
			// 
			// SaveOptionsForm
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Window;
			CancelButton = cancelButton;
			ClientSize = new Size(384, 546);
			Controls.Add(panel1);
			Controls.Add(groupBox4);
			Controls.Add(groupBox3);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = Properties.Resources.Icon;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new Size(270, 340);
			Name = "SaveOptionsForm";
			Text = "Save Options";
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)soundVolume).EndInit();
			panel1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBox1;
		private Label label1;
		private ComboBox saveHotkeys;
		private GroupBox groupBox2;
		private CheckBox enableAutosave;
		private Label label3;
		private TextBox autosaveInterval;
		private Label label4;
		private ComboBox abortSaveHotkeys;
		private Label label2;
		private ToolTip toolTip;
		private GroupBox groupBox3;
		private Label label5;
		private TextBox backupPath;
		private Button browseButton;
		private CheckBox useCompression;
		private ToolTip compressToolTip;
		private FolderBrowserDialog folderBrowser;
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
		private ProgressBar progressBar;
		private Button deleteButton;
		private Button button1;
	}
}