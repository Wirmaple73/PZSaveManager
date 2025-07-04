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
			saveHotkey = new ComboBox();
			label1 = new Label();
			groupBox2 = new GroupBox();
			label4 = new Label();
			autosaveInterval = new TextBox();
			label3 = new Label();
			enableAutosave = new CheckBox();
			abortSaveHotkey = new ComboBox();
			label2 = new Label();
			okButton = new Button();
			cancelButton = new Button();
			toolTip = new ToolTip(components);
			groupBox1.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// groupBox1
			// 
			groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox1.Controls.Add(saveHotkey);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(320, 65);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Manual save";
			// 
			// saveHotkey
			// 
			saveHotkey.DropDownStyle = ComboBoxStyle.DropDownList;
			saveHotkey.FormattingEnabled = true;
			saveHotkey.Location = new Point(96, 26);
			saveHotkey.Name = "saveHotkey";
			saveHotkey.Size = new Size(119, 23);
			saveHotkey.TabIndex = 1;
			toolTip.SetToolTip(saveHotkey, "Used to select the key that triggers a manual save on the active world when pressed.\r\nIf this feature is not desired, please select \"None\".");
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(18, 29);
			label1.Name = "label1";
			label1.Size = new Size(73, 15);
			label1.TabIndex = 0;
			label1.Text = "Save hotkey:";
			toolTip.SetToolTip(label1, "Used to select the key that triggers a manual save on the active world when pressed.\r\nIf this feature is not desired, please select \"None\".\r\n");
			// 
			// groupBox2
			// 
			groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(autosaveInterval);
			groupBox2.Controls.Add(label3);
			groupBox2.Controls.Add(enableAutosave);
			groupBox2.Location = new Point(12, 88);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(320, 93);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Auto-save";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(171, 60);
			label4.Name = "label4";
			label4.Size = new Size(50, 15);
			label4.TabIndex = 3;
			label4.Text = "minutes";
			// 
			// autosaveInterval
			// 
			autosaveInterval.Location = new Point(128, 56);
			autosaveInterval.Name = "autosaveInterval";
			autosaveInterval.Size = new Size(40, 23);
			autosaveInterval.TabIndex = 2;
			toolTip.SetToolTip(autosaveInterval, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(18, 59);
			label3.Name = "label3";
			label3.Size = new Size(106, 15);
			label3.TabIndex = 1;
			label3.Text = "Auto-save interval:";
			toolTip.SetToolTip(label3, "Determines the time interval of the auto-save function (e.g. every 10 minutes).");
			// 
			// enableAutosave
			// 
			enableAutosave.AutoSize = true;
			enableAutosave.Location = new Point(21, 29);
			enableAutosave.Name = "enableAutosave";
			enableAutosave.Size = new Size(116, 19);
			enableAutosave.TabIndex = 0;
			enableAutosave.Text = "Enable auto-save";
			toolTip.SetToolTip(enableAutosave, "Auto-save automatically saves the active world within the time interval specified below (e.g. every 10 minutes).");
			enableAutosave.UseVisualStyleBackColor = true;
			enableAutosave.CheckedChanged += enableAutosave_CheckedChanged;
			// 
			// abortSaveHotkey
			// 
			abortSaveHotkey.DropDownStyle = ComboBoxStyle.DropDownList;
			abortSaveHotkey.FormattingEnabled = true;
			abortSaveHotkey.Location = new Point(122, 200);
			abortSaveHotkey.Name = "abortSaveHotkey";
			abortSaveHotkey.Size = new Size(105, 23);
			abortSaveHotkey.TabIndex = 5;
			toolTip.SetToolTip(abortSaveHotkey, resources.GetString("abortSaveHotkey.ToolTip"));
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 203);
			label2.Name = "label2";
			label2.Size = new Size(105, 15);
			label2.TabIndex = 4;
			label2.Text = "Abort save hotkey:";
			toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
			// 
			// okButton
			// 
			okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			okButton.Location = new Point(128, 321);
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
			cancelButton.Location = new Point(235, 321);
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
			// SaveOptionsForm
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = cancelButton;
			ClientSize = new Size(344, 361);
			Controls.Add(cancelButton);
			Controls.Add(okButton);
			Controls.Add(abortSaveHotkey);
			Controls.Add(label2);
			Controls.Add(groupBox2);
			Controls.Add(groupBox1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
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
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private GroupBox groupBox1;
		private Label label1;
		private ComboBox saveHotkey;
		private GroupBox groupBox2;
		private CheckBox enableAutosave;
		private Label label3;
		private TextBox autosaveInterval;
		private Label label4;
		private ComboBox abortSaveHotkey;
		private Label label2;
		private Button okButton;
		private Button cancelButton;
		private ToolTip toolTip;
	}
}