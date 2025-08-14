namespace SavepointManager.Forms
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
			pictureBox1 = new PictureBox();
			versionLabel = new Label();
			okButton = new Button();
			githubLink = new LinkLabel();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
			// pictureBox1
			// 
			pictureBox1.Location = new Point(10, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(80, 80);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			// 
			// versionLabel
			// 
			versionLabel.AutoSize = true;
			versionLabel.Location = new Point(98, 31);
			versionLabel.Name = "versionLabel";
			versionLabel.Size = new Size(78, 15);
			versionLabel.TabIndex = 2;
			versionLabel.Text = "Version ..........";
			// 
			// okButton
			// 
			okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			okButton.FlatStyle = FlatStyle.System;
			okButton.Location = new Point(295, 131);
			okButton.Name = "okButton";
			okButton.Size = new Size(97, 28);
			okButton.TabIndex = 7;
			okButton.Text = "&OK";
			okButton.UseVisualStyleBackColor = true;
			// 
			// githubLink
			// 
			githubLink.AutoSize = true;
			githubLink.Location = new Point(98, 77);
			githubLink.Name = "githubLink";
			githubLink.Size = new Size(267, 15);
			githubLink.TabIndex = 8;
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
			label2.TabIndex = 9;
			label2.Text = "Created by Wirmaple73";
			// 
			// AboutForm
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = okButton;
			ClientSize = new Size(404, 171);
			Controls.Add(label2);
			Controls.Add(githubLink);
			Controls.Add(okButton);
			Controls.Add(versionLabel);
			Controls.Add(pictureBox1);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "AboutForm";
			Text = "About";
			Load += AboutForm_Load;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private PictureBox pictureBox1;
		private Label versionLabel;
		private Button okButton;
		private LinkLabel githubLink;
		private Label label2;
	}
}