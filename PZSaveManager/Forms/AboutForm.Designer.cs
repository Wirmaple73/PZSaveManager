namespace PZSaveManager.Forms
{
	partial class AboutForm
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
			label1 = new Label();
			appIcon = new PictureBox();
			versionLabel = new Label();
			okButton = new Button();
			githubLink = new LinkLabel();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)appIcon).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(98, 12);
			label1.Name = "label1";
			label1.Size = new Size(173, 15);
			label1.TabIndex = 0;
			label1.Text = "Project Zomboid Save Manager";
			// 
			// appIcon
			// 
			appIcon.Location = new Point(10, 12);
			appIcon.Name = "appIcon";
			appIcon.Size = new Size(80, 80);
			appIcon.SizeMode = PictureBoxSizeMode.Zoom;
			appIcon.TabIndex = 1;
			appIcon.TabStop = false;
			// 
			// versionLabel
			// 
			versionLabel.AutoSize = true;
			versionLabel.Location = new Point(98, 31);
			versionLabel.Name = "versionLabel";
			versionLabel.Size = new Size(103, 15);
			versionLabel.TabIndex = 1;
			versionLabel.Text = "Fetching version...";
			// 
			// okButton
			// 
			okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			okButton.FlatStyle = FlatStyle.System;
			okButton.Location = new Point(295, 131);
			okButton.Name = "okButton";
			okButton.Size = new Size(97, 28);
			okButton.TabIndex = 4;
			okButton.Text = "&OK";
			okButton.UseVisualStyleBackColor = true;
			// 
			// githubLink
			// 
			githubLink.AutoSize = true;
			githubLink.Location = new Point(98, 77);
			githubLink.Name = "githubLink";
			githubLink.Size = new Size(267, 15);
			githubLink.TabIndex = 3;
			githubLink.TabStop = true;
			githubLink.Text = "https://github.com/Wirmaple73/PZSaveManager";
			githubLink.LinkClicked += githubLink_LinkClicked;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(98, 59);
			label2.Name = "label2";
			label2.Size = new Size(130, 15);
			label2.TabIndex = 2;
			label2.Text = "Created by Wirmaple73";
			// 
			// AboutForm
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Window;
			CancelButton = okButton;
			ClientSize = new Size(404, 171);
			Controls.Add(label2);
			Controls.Add(githubLink);
			Controls.Add(okButton);
			Controls.Add(versionLabel);
			Controls.Add(appIcon);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutForm";
			Text = "About";
			Load += AboutForm_Load;
			((System.ComponentModel.ISupportInitialize)appIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private PictureBox appIcon;
		private Label versionLabel;
		private Button okButton;
		private LinkLabel githubLink;
		private Label label2;
	}
}