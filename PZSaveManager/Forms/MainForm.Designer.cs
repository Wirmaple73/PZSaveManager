namespace PZSaveManager.Forms
{
	partial class MainForm
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
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openLogFileToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            configureSaveOptionsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            sendFeedbackToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pagePanel = new Panel();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.AllowMerge = false;
            menuStrip.BackColor = SystemColors.Menu;
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(784, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openLogFileToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openLogFileToolStripMenuItem
            // 
            openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            openLogFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            openLogFileToolStripMenuItem.Size = new Size(196, 22);
            openLogFileToolStripMenuItem.Text = "&Open Log File...";
            openLogFileToolStripMenuItem.Click += openLogFileToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(193, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(196, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configureSaveOptionsToolStripMenuItem });
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(61, 20);
            optionsToolStripMenuItem.Text = "&Options";
            // 
            // configureSaveOptionsToolStripMenuItem
            // 
            configureSaveOptionsToolStripMenuItem.Name = "configureSaveOptionsToolStripMenuItem";
            configureSaveOptionsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            configureSaveOptionsToolStripMenuItem.Size = new Size(248, 22);
            configureSaveOptionsToolStripMenuItem.Text = "&Configure Save Options...";
            configureSaveOptionsToolStripMenuItem.Click += configureSaveOptionsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { checkForUpdatesToolStripMenuItem, toolStripMenuItem3, sendFeedbackToolStripMenuItem, reportToolStripMenuItem, toolStripMenuItem2, aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            checkForUpdatesToolStripMenuItem.Size = new Size(228, 22);
            checkForUpdatesToolStripMenuItem.Text = "Check for &Updates...";
            checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(225, 6);
            // 
            // sendFeedbackToolStripMenuItem
            // 
            sendFeedbackToolStripMenuItem.Name = "sendFeedbackToolStripMenuItem";
            sendFeedbackToolStripMenuItem.Size = new Size(228, 22);
            sendFeedbackToolStripMenuItem.Text = "&Send Feedback";
            sendFeedbackToolStripMenuItem.Click += sendFeedbackToolStripMenuItem_Click;
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new Size(228, 22);
            reportToolStripMenuItem.Text = "&Feature Request / Bug Report";
            reportToolStripMenuItem.Click += reportToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(225, 6);
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(228, 22);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // pagePanel
            // 
            pagePanel.Dock = DockStyle.Fill;
            pagePanel.Location = new Point(0, 24);
            pagePanel.Name = "pagePanel";
            pagePanel.Size = new Size(784, 537);
            pagePanel.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(784, 561);
            Controls.Add(pagePanel);
            Controls.Add(menuStrip);
            Icon = Properties.Resources.Icon;
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(540, 350);
            Name = "MainForm";
            Text = "Project Zomboid Save Manager";
            FormClosing += MainForm_FormClosing;
            Shown += MainForm_Shown;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem optionsToolStripMenuItem;
		private ToolStripMenuItem configureSaveOptionsToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Panel pagePanel;
		private ToolStripMenuItem openLogFileToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem sendFeedbackToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem2;
    }
}