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
            components = new System.ComponentModel.Container();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            viewLogsToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            configureSaveOptionsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            checkForUpdatesAutomaticallyToolStripMenuItem = new ToolStripMenuItem();
            minimizeToSystemTrayToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            sendFeedbackToolStripMenuItem = new ToolStripMenuItem();
            reportToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            pagePanel = new Panel();
            notifyIcon = new NotifyIcon(components);
            notifyIconContextMenu = new ContextMenuStrip(components);
            showWindowToolStripMenuItem = new ToolStripMenuItem();
            exitCMToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            notifyIconContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.AllowMerge = false;
            menuStrip.BackColor = SystemColors.Menu;
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, logsToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(784, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(135, 22);
            exitToolStripMenuItem.Text = "&Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewLogsToolStripMenuItem });
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(44, 20);
            logsToolStripMenuItem.Text = "&Logs";
            // 
            // viewLogsToolStripMenuItem
            // 
            viewLogsToolStripMenuItem.Name = "viewLogsToolStripMenuItem";
            viewLogsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            viewLogsToolStripMenuItem.Size = new Size(167, 22);
            viewLogsToolStripMenuItem.Text = "&View Logs";
            viewLogsToolStripMenuItem.Click += viewLogsToolStripMenuItem_Click;
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configureSaveOptionsToolStripMenuItem, toolStripMenuItem1, checkForUpdatesAutomaticallyToolStripMenuItem, minimizeToSystemTrayToolStripMenuItem });
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
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(245, 6);
            // 
            // checkForUpdatesAutomaticallyToolStripMenuItem
            // 
            checkForUpdatesAutomaticallyToolStripMenuItem.CheckOnClick = true;
            checkForUpdatesAutomaticallyToolStripMenuItem.Name = "checkForUpdatesAutomaticallyToolStripMenuItem";
            checkForUpdatesAutomaticallyToolStripMenuItem.Size = new Size(248, 22);
            checkForUpdatesAutomaticallyToolStripMenuItem.Text = "Check for &Updates Automatically";
            checkForUpdatesAutomaticallyToolStripMenuItem.Click += checkForUpdatesAutomaticallyToolStripMenuItem_Click;
            // 
            // minimizeToSystemTrayToolStripMenuItem
            // 
            minimizeToSystemTrayToolStripMenuItem.CheckOnClick = true;
            minimizeToSystemTrayToolStripMenuItem.Name = "minimizeToSystemTrayToolStripMenuItem";
            minimizeToSystemTrayToolStripMenuItem.Size = new Size(248, 22);
            minimizeToSystemTrayToolStripMenuItem.Text = "Minimize to &System Tray";
            minimizeToSystemTrayToolStripMenuItem.Click += MinimizeToSystemTrayToolStripMenuItem_Click;
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
            checkForUpdatesToolStripMenuItem.Text = "&Check for Updates...";
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
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.BalloonTipText = "Save Manager has been minimized to the system tray.";
            notifyIcon.BalloonTipTitle = "Minimized to Tray";
            notifyIcon.ContextMenuStrip = notifyIconContextMenu;
            notifyIcon.Icon = Properties.Resources.Icon;
            notifyIcon.Text = "Project Zomboid Save Manager";
            notifyIcon.MouseUp += NotifyIcon_MouseUp;
            // 
            // notifyIconContextMenu
            // 
            notifyIconContextMenu.Items.AddRange(new ToolStripItem[] { showWindowToolStripMenuItem, exitCMToolStripMenuItem });
            notifyIconContextMenu.Name = "notifyIconContextMenu";
            notifyIconContextMenu.Size = new Size(181, 70);
            // 
            // showWindowToolStripMenuItem
            // 
            showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            showWindowToolStripMenuItem.Size = new Size(180, 22);
            showWindowToolStripMenuItem.Text = "&Show";
            showWindowToolStripMenuItem.Click += ShowWindowToolStripMenuItem_Click;
            // 
            // exitCMToolStripMenuItem
            // 
            exitCMToolStripMenuItem.Name = "exitCMToolStripMenuItem";
            exitCMToolStripMenuItem.Size = new Size(180, 22);
            exitCMToolStripMenuItem.Text = "&Exit";
            exitCMToolStripMenuItem.Click += exitToolStripMenuItem_Click;
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
            Resize += MainForm_Resize;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            notifyIconContextMenu.ResumeLayout(false);
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
        private ToolStripMenuItem sendFeedbackToolStripMenuItem;
        private ToolStripMenuItem reportToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem checkForUpdatesAutomaticallyToolStripMenuItem;
        private ToolStripMenuItem logsToolStripMenuItem;
        private ToolStripMenuItem viewLogsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem minimizeToSystemTrayToolStripMenuItem;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyIconContextMenu;
        private ToolStripMenuItem showWindowToolStripMenuItem;
        private ToolStripMenuItem exitCMToolStripMenuItem;
    }
}