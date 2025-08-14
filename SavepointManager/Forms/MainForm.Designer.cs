namespace SavepointManager.Forms
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			menuStrip = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			openLogFileToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			exitToolStripMenuItem = new ToolStripMenuItem();
			optionsToolStripMenuItem = new ToolStripMenuItem();
			configureSaveOptionsToolStripMenuItem = new ToolStripMenuItem();
			changethemeToolStripMenuItem = new ToolStripMenuItem();
			defaultThemeToolStripMenuItem = new ToolStripMenuItem();
			darkThemeToolStripMenuItem = new ToolStripMenuItem();
			useSystemThemeToolStripMenuItem = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			pagePanel = new Panel();
			menuStrip.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip
			// 
			menuStrip.BackColor = SystemColors.ControlLightLight;
			menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
			menuStrip.Location = new Point(0, 0);
			menuStrip.Name = "menuStrip";
			menuStrip.Size = new Size(734, 24);
			menuStrip.TabIndex = 1;
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
			openLogFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
			openLogFileToolStripMenuItem.Size = new Size(185, 22);
			openLogFileToolStripMenuItem.Text = "&Open log file";
			openLogFileToolStripMenuItem.Click += openLogFileToolStripMenuItem_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(182, 6);
			// 
			// exitToolStripMenuItem
			// 
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
			exitToolStripMenuItem.Size = new Size(185, 22);
			exitToolStripMenuItem.Text = "&Exit";
			exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
			// 
			// optionsToolStripMenuItem
			// 
			optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configureSaveOptionsToolStripMenuItem, changethemeToolStripMenuItem });
			optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			optionsToolStripMenuItem.Size = new Size(61, 20);
			optionsToolStripMenuItem.Text = "&Options";
			// 
			// configureSaveOptionsToolStripMenuItem
			// 
			configureSaveOptionsToolStripMenuItem.Name = "configureSaveOptionsToolStripMenuItem";
			configureSaveOptionsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
			configureSaveOptionsToolStripMenuItem.Size = new Size(245, 22);
			configureSaveOptionsToolStripMenuItem.Text = "&Configure save options...";
			configureSaveOptionsToolStripMenuItem.Click += configureSaveOptionsToolStripMenuItem_Click;
			// 
			// changethemeToolStripMenuItem
			// 
			changethemeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { defaultThemeToolStripMenuItem, darkThemeToolStripMenuItem, useSystemThemeToolStripMenuItem });
			changethemeToolStripMenuItem.Name = "changethemeToolStripMenuItem";
			changethemeToolStripMenuItem.Size = new Size(245, 22);
			changethemeToolStripMenuItem.Text = "C&hange theme...";
			// 
			// defaultThemeToolStripMenuItem
			// 
			defaultThemeToolStripMenuItem.CheckOnClick = true;
			defaultThemeToolStripMenuItem.Name = "defaultThemeToolStripMenuItem";
			defaultThemeToolStripMenuItem.Size = new Size(180, 22);
			defaultThemeToolStripMenuItem.Text = "&Default theme";
			// 
			// darkThemeToolStripMenuItem
			// 
			darkThemeToolStripMenuItem.CheckOnClick = true;
			darkThemeToolStripMenuItem.Name = "darkThemeToolStripMenuItem";
			darkThemeToolStripMenuItem.Size = new Size(180, 22);
			darkThemeToolStripMenuItem.Text = "D&ark theme";
			// 
			// useSystemThemeToolStripMenuItem
			// 
			useSystemThemeToolStripMenuItem.CheckOnClick = true;
			useSystemThemeToolStripMenuItem.Name = "useSystemThemeToolStripMenuItem";
			useSystemThemeToolStripMenuItem.Size = new Size(180, 22);
			useSystemThemeToolStripMenuItem.Text = "&Use system theme";
			// 
			// helpToolStripMenuItem
			// 
			helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { checkForUpdatesToolStripMenuItem, aboutToolStripMenuItem });
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new Size(44, 20);
			helpToolStripMenuItem.Text = "&Help";
			// 
			// checkForUpdatesToolStripMenuItem
			// 
			checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
			checkForUpdatesToolStripMenuItem.Size = new Size(179, 22);
			checkForUpdatesToolStripMenuItem.Text = "Check for &updates...";
			checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new Size(179, 22);
			aboutToolStripMenuItem.Text = "&About...";
			aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
			// 
			// pagePanel
			// 
			pagePanel.Dock = DockStyle.Fill;
			pagePanel.Location = new Point(0, 24);
			pagePanel.Name = "pagePanel";
			pagePanel.Size = new Size(734, 537);
			pagePanel.TabIndex = 0;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(734, 561);
			Controls.Add(pagePanel);
			Controls.Add(menuStrip);
			Icon = (Icon)resources.GetObject("$this.Icon");
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
		private ToolStripMenuItem changethemeToolStripMenuItem;
		private ToolStripMenuItem defaultThemeToolStripMenuItem;
		private ToolStripMenuItem darkThemeToolStripMenuItem;
		private ToolStripMenuItem useSystemThemeToolStripMenuItem;
		private ToolStripMenuItem openLogFileToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem1;
	}
}