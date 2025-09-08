namespace PZSaveManager.Forms
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
			progressBar = new ProgressBar();
			deleteButton = new Button();
			cancelButton = new Button();
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
			label1.Location = new Point(9, 71);
			label1.Name = "label1";
			label1.Size = new Size(478, 15);
			label1.TabIndex = 1;
			label1.Text = "&To proceed with deletion, please type \"delete\" in the box below. This may take some time.";
			// 
			// confirmationTextBox
			// 
			confirmationTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			confirmationTextBox.Location = new Point(12, 94);
			confirmationTextBox.Name = "confirmationTextBox";
			confirmationTextBox.Size = new Size(500, 23);
			confirmationTextBox.TabIndex = 2;
			confirmationTextBox.TextChanged += confirmationBox_TextChanged;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.Control;
			panel1.Controls.Add(progressBar);
			panel1.Controls.Add(deleteButton);
			panel1.Controls.Add(cancelButton);
			panel1.Dock = DockStyle.Bottom;
			panel1.Location = new Point(0, 127);
			panel1.Name = "panel1";
			panel1.Size = new Size(524, 54);
			panel1.TabIndex = 3;
			// 
			// progressBar
			// 
			progressBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			progressBar.Location = new Point(12, 15);
			progressBar.MarqueeAnimationSpeed = 10;
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(308, 26);
			progressBar.Style = ProgressBarStyle.Marquee;
			progressBar.TabIndex = 0;
			progressBar.Visible = false;
			// 
			// deleteButton
			// 
			deleteButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			deleteButton.Enabled = false;
			deleteButton.FlatStyle = FlatStyle.System;
			deleteButton.Location = new Point(334, 14);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(86, 28);
			deleteButton.TabIndex = 1;
			deleteButton.Text = "&Delete";
			deleteButton.UseVisualStyleBackColor = true;
			deleteButton.Click += deleteButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cancelButton.FlatStyle = FlatStyle.System;
			cancelButton.Location = new Point(426, 14);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(86, 28);
			cancelButton.TabIndex = 2;
			cancelButton.Text = "&Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			panel2.AutoScroll = true;
			panel2.Controls.Add(deletionMessage);
			panel2.Location = new Point(50, 12);
			panel2.Name = "panel2";
			panel2.Size = new Size(470, 56);
			panel2.TabIndex = 0;
			// 
			// WorldDeletionConfirmationForm
			// 
			AcceptButton = deleteButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Window;
			CancelButton = cancelButton;
			ClientSize = new Size(524, 181);
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
		private ProgressBar progressBar;
		private Button deleteButton;
		private Button cancelButton;
		private Panel panel2;
	}
}