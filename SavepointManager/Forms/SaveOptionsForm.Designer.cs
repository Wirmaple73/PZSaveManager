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
			okButton = new Button();
			cancelButton = new Button();
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
			resetButton = new Button();
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox3.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(saveHotkeys);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(abortSaveHotkeys);
			groupBox1.Location = new Point(12, 173);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(360, 100);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Hotkeys";
			// 
			// saveHotkeys
			// 
			saveHotkeys.DropDownStyle = ComboBoxStyle.DropDownList;
			saveHotkeys.FormattingEnabled = true;
			saveHotkeys.Location = new Point(122, 26);
			saveHotkeys.Name = "saveHotkeys";
			saveHotkeys.Size = new Size(105, 23);
			saveHotkeys.TabIndex = 1;
			toolTip.SetToolTip(saveHotkeys, "Used to select the key that triggers a manual save on the active world when pressed.\r\nIf this feature is not desired, please select \"None\".");
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(14, 29);
			label1.Name = "label1";
			label1.Size = new Size(73, 15);
			label1.TabIndex = 0;
			label1.Text = "Save hotkey:";
			toolTip.SetToolTip(label1, "Used to select the key that triggers a manual save on the active world when pressed.\r\nIf this feature is not desired, please select \"None\".\r\n");
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(14, 62);
			label2.Name = "label2";
			label2.Size = new Size(105, 15);
			label2.TabIndex = 4;
			label2.Text = "Abort save hotkey:";
			toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
			// 
			// abortSaveHotkeys
			// 
			abortSaveHotkeys.DropDownStyle = ComboBoxStyle.DropDownList;
			abortSaveHotkeys.FormattingEnabled = true;
			abortSaveHotkeys.Location = new Point(122, 59);
			abortSaveHotkeys.Name = "abortSaveHotkeys";
			abortSaveHotkeys.Size = new Size(105, 23);
			abortSaveHotkeys.TabIndex = 5;
			toolTip.SetToolTip(abortSaveHotkeys, resources.GetString("abortSaveHotkeys.ToolTip"));
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(autosaveInterval);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(enableAutosave);
			groupBox2.Location = new Point(12, 279);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(360, 87);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Auto-save";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(168, 56);
			label4.Name = "label4";
			label4.Size = new Size(50, 15);
			label4.TabIndex = 3;
			label4.Text = "minutes";
			// 
			// autosaveInterval
			// 
			autosaveInterval.Location = new Point(126, 52);
			autosaveInterval.Name = "autosaveInterval";
			autosaveInterval.Size = new Size(40, 23);
			autosaveInterval.TabIndex = 2;
			toolTip.SetToolTip(autosaveInterval, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(18, 55);
			label3.Name = "label3";
			label3.Size = new Size(106, 15);
			label3.TabIndex = 1;
			label3.Text = "Auto-save interval:";
			toolTip.SetToolTip(label3, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
			// 
			// enableAutosave
			// 
			enableAutosave.AutoSize = true;
			enableAutosave.Location = new Point(21, 25);
			enableAutosave.Name = "enableAutosave";
			enableAutosave.Size = new Size(116, 19);
			enableAutosave.TabIndex = 0;
			enableAutosave.Text = "Enable auto-save";
			toolTip.SetToolTip(enableAutosave, "Auto-save automatically saves the active world within the time interval specified below (e.g. every 10 minutes).");
			enableAutosave.UseVisualStyleBackColor = true;
			enableAutosave.CheckedChanged += enableAutosave_CheckedChanged;
			// 
			// okButton
			// 
			okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			okButton.Location = new Point(171, 401);
			okButton.Name = "okButton";
			okButton.Size = new Size(97, 28);
			okButton.TabIndex = 6;
			okButton.Text = "&OK";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += okButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cancelButton.Location = new Point(278, 401);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(97, 28);
			cancelButton.TabIndex = 7;
			cancelButton.Text = "&Cancel";
			cancelButton.UseVisualStyleBackColor = true;
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
			useSaveSounds.Location = new Point(190, 121);
			useSaveSounds.Name = "useSaveSounds";
			useSaveSounds.Size = new Size(161, 19);
			useSaveSounds.TabIndex = 5;
			useSaveSounds.Text = "Enable save sound effects";
			toolTip.SetToolTip(useSaveSounds, "Plays sound effects when saving a world succeeds, fails, or gets canceled. This setting only affects the manual & automatic save functions.");
			useSaveSounds.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox3.Controls.Add(saveRelocationLabel);
			groupBox3.Controls.Add(useSaveSounds);
			groupBox3.Controls.Add(useCompression);
			groupBox3.Controls.Add(browseButton);
			groupBox3.Controls.Add(backupPath);
			groupBox3.Controls.Add(label5);
			groupBox3.Location = new Point(12, 12);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(360, 155);
			groupBox3.TabIndex = 8;
			groupBox3.TabStop = false;
			groupBox3.Text = "Save Options";
			// 
			// saveRelocationLabel
			// 
			saveRelocationLabel.Location = new Point(13, 75);
			saveRelocationLabel.Name = "saveRelocationLabel";
			saveRelocationLabel.Size = new Size(332, 33);
			saveRelocationLabel.TabIndex = 6;
			saveRelocationLabel.Text = "Note: If this is changed, all saves will be moved to the new path after you click 'OK'. This might take some time.";
			// 
			// useCompression
			// 
			useCompression.AutoSize = true;
			useCompression.Location = new Point(16, 121);
			useCompression.Name = "useCompression";
			useCompression.Size = new Size(131, 19);
			useCompression.TabIndex = 3;
			useCompression.Text = "Compress save data";
			compressToolTip.SetToolTip(useCompression, resources.GetString("useCompression.ToolTip"));
			useCompression.UseVisualStyleBackColor = true;
			// 
			// browseButton
			// 
			browseButton.Location = new Point(262, 44);
			browseButton.Name = "browseButton";
			browseButton.Size = new Size(83, 25);
			browseButton.TabIndex = 2;
			browseButton.Text = "Browse...";
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
			compressToolTip.AutoPopDelay = 30000;
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
			// resetButton
			// 
			resetButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			resetButton.Location = new Point(12, 401);
			resetButton.Name = "resetButton";
			resetButton.Size = new Size(110, 28);
			resetButton.TabIndex = 9;
			resetButton.Text = "&Reset all";
			resetButton.UseVisualStyleBackColor = true;
			resetButton.Click += resetButton_Click;
			// 
			// SaveOptionsForm
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = cancelButton;
			ClientSize = new Size(384, 441);
			Controls.Add(resetButton);
			Controls.Add(groupBox3);
			Controls.Add(cancelButton);
			Controls.Add(okButton);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
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
		private Button okButton;
		private Button cancelButton;
		private ToolTip toolTip;
		private GroupBox groupBox3;
		private Label label5;
		private TextBox backupPath;
		private Button browseButton;
		private CheckBox useCompression;
		private ToolTip compressToolTip;
		private FolderBrowserDialog folderBrowser;
		private CheckBox useSaveSounds;
		private Button resetButton;
		private Label saveRelocationLabel;
	}
}