namespace SavepointManager.Forms
{
	partial class WorldDeletionConfirmationForm
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
			deletionMessage = new Label();
			warningImage = new PictureBox();
			label1 = new Label();
			confirmationTextBox = new TextBox();
			panel1 = new Panel();
			progressLabel = new Label();
			actualStatusLabel = new Label();
			statusLabel = new Label();
			progressBar = new ProgressBar();
			cancelButton = new Button();
			removeButton = new Button();
			panel2 = new Panel();
			((System.ComponentModel.ISupportInitialize)warningImage).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			SuspendLayout();
			// 
			// deletionMessage
			// 
			deletionMessage.AutoSize = true;
			deletionMessage.Location = new Point(0, 0);
			deletionMessage.MaximumSize = new Size(450, 0);
			deletionMessage.Name = "deletionMessage";
			deletionMessage.Size = new Size(74, 15);
			deletionMessage.TabIndex = 0;
			deletionMessage.Text = "Please wait...";
			// 
			// warningImage
			// 
			warningImage.Location = new Point(12, 12);
			warningImage.Name = "warningImage";
			warningImage.Size = new Size(32, 32);
			warningImage.SizeMode = PictureBoxSizeMode.Zoom;
			warningImage.TabIndex = 1;
			warningImage.TabStop = false;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label1.AutoSize = true;
			label1.Location = new Point(9, 77);
			label1.Name = "label1";
			label1.Size = new Size(478, 15);
			label1.TabIndex = 1;
			label1.Text = "&To proceed with removal, please type \"delete\" in the box below. This may take some time.";
			// 
			// confirmationTextBox
			// 
			confirmationTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			confirmationTextBox.Location = new Point(12, 100);
			confirmationTextBox.Name = "confirmationTextBox";
			confirmationTextBox.Size = new Size(500, 23);
			confirmationTextBox.TabIndex = 2;
			confirmationTextBox.TextChanged += confirmationBox_TextChanged;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.Control;
			panel1.Controls.Add(progressLabel);
			panel1.Controls.Add(actualStatusLabel);
			panel1.Controls.Add(statusLabel);
			panel1.Controls.Add(progressBar);
			panel1.Controls.Add(cancelButton);
			panel1.Controls.Add(removeButton);
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(0, 136);
			panel1.Name = "panel1";
			panel1.Size = new Size(524, 65);
			panel1.TabIndex = 8;
			// 
			// progressLabel
			// 
			progressLabel.AutoSize = true;
			progressLabel.Location = new Point(276, 32);
			progressLabel.Name = "progressLabel";
			progressLabel.Size = new Size(35, 15);
			progressLabel.TabIndex = 13;
			progressLabel.Text = "100%";
			progressLabel.Visible = false;
			// 
			// actualStatusLabel
			// 
			actualStatusLabel.AutoSize = true;
			actualStatusLabel.Location = new Point(50, 6);
			actualStatusLabel.Name = "actualStatusLabel";
			actualStatusLabel.Size = new Size(57, 15);
			actualStatusLabel.TabIndex = 11;
			actualStatusLabel.Text = "Starting...";
			actualStatusLabel.Visible = false;
			// 
			// statusLabel
			// 
			statusLabel.AutoSize = true;
			statusLabel.Location = new Point(11, 6);
			statusLabel.Name = "statusLabel";
			statusLabel.Size = new Size(42, 15);
			statusLabel.TabIndex = 10;
			statusLabel.Text = "Status:";
			statusLabel.Visible = false;
			// 
			// progressBar
			// 
			progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			progressBar.Location = new Point(12, 26);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(260, 26);
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 12;
			progressBar.Visible = false;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cancelButton.FlatStyle = FlatStyle.System;
			cancelButton.Location = new Point(334, 25);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(86, 28);
			cancelButton.TabIndex = 8;
			cancelButton.Text = "&Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// removeButton
			// 
			removeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			removeButton.Enabled = false;
			removeButton.FlatStyle = FlatStyle.System;
			removeButton.Location = new Point(426, 25);
			removeButton.Name = "removeButton";
			removeButton.Size = new Size(86, 28);
			removeButton.TabIndex = 9;
			removeButton.Text = "&Remove";
			removeButton.UseVisualStyleBackColor = true;
			removeButton.Click += removeButton_Click;
			// 
			// panel2
			// 
			panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel2.AutoScroll = true;
			panel2.Controls.Add(deletionMessage);
			panel2.Location = new Point(50, 12);
			panel2.Name = "panel2";
			panel2.Size = new Size(470, 60);
			panel2.TabIndex = 9;
			// 
			// WorldDeletionConfirmationForm
			// 
			AcceptButton = removeButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Window;
			CancelButton = cancelButton;
			ClientSize = new Size(524, 201);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(confirmationTextBox);
			Controls.Add(label1);
			Controls.Add(warningImage);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			Name = "WorldDeletionConfirmationForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "World Deletion Confirmation";
			FormClosing += WorldDeletionConfirmationForm_FormClosing;
			Shown += WorldDeletionConfirmationForm_Shown;
			((System.ComponentModel.ISupportInitialize)warningImage).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label deletionMessage;
		private PictureBox warningImage;
		private Label label1;
		private TextBox confirmationTextBox;
		private Panel panel1;
		private Label actualStatusLabel;
		private Label statusLabel;
		private ProgressBar progressBar;
		private Button cancelButton;
		private Button removeButton;
		private Panel panel2;
		private Label progressLabel;
	}
}