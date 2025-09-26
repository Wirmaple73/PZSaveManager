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
            appNameLabel = new Label();
            appIcon = new PictureBox();
            versionLabel = new Label();
            okButton = new Button();
            githubLink = new LinkLabel();
            label2 = new Label();
            label3 = new Label();
            licenseLink = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)appIcon).BeginInit();
            SuspendLayout();
            // 
            // appNameLabel
            // 
            appNameLabel.AutoSize = true;
            appNameLabel.Location = new Point(98, 12);
            appNameLabel.Name = "appNameLabel";
            appNameLabel.Size = new Size(173, 15);
            appNameLabel.TabIndex = 0;
            appNameLabel.Text = "Project Zomboid Save Manager";
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
            okButton.Location = new Point(295, 161);
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 105);
            label3.Name = "label3";
            label3.Size = new Size(256, 15);
            label3.TabIndex = 5;
            label3.Text = "This program is licensed under the MIT License.";
            // 
            // licenseLink
            // 
            licenseLink.AutoSize = true;
            licenseLink.Location = new Point(98, 123);
            licenseLink.Name = "licenseLink";
            licenseLink.Size = new Size(71, 15);
            licenseLink.TabIndex = 6;
            licenseLink.TabStop = true;
            licenseLink.Text = "View license";
            licenseLink.Click += licenseLink_Click;
            // 
            // AboutForm
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            CancelButton = okButton;
            ClientSize = new Size(404, 201);
            Controls.Add(licenseLink);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(githubLink);
            Controls.Add(okButton);
            Controls.Add(versionLabel);
            Controls.Add(appIcon);
            Controls.Add(appNameLabel);
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

        private Label appNameLabel;
		private PictureBox appIcon;
		private Label versionLabel;
		private Button okButton;
		private LinkLabel githubLink;
		private Label label2;
		private Label label3;
		private LinkLabel licenseLink;
	}
}