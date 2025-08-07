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
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			exitToolStripMenuItem = new ToolStripMenuItem();
			optionsToolStripMenuItem = new ToolStripMenuItem();
			configureSaveOptionsToolStripMenuItem = new ToolStripMenuItem();
			helpToolStripMenuItem = new ToolStripMenuItem();
			checkForUpdatesToolStripMenuItem = new ToolStripMenuItem();
			aboutToolStripMenuItem = new ToolStripMenuItem();
			pagePanel = new Panel();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// menuStrip1
			// 
			menuStrip1.BackColor = SystemColors.ControlLightLight;
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, optionsToolStripMenuItem, helpToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(734, 24);
			menuStrip1.TabIndex = 1;
			menuStrip1.Text = "menuStrip1";
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
			configureSaveOptionsToolStripMenuItem.Size = new Size(205, 22);
			configureSaveOptionsToolStripMenuItem.Text = "&Configure save options...";
			configureSaveOptionsToolStripMenuItem.Click += configureSaveOptionsToolStripMenuItem_Click;
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
			checkForUpdatesToolStripMenuItem.Size = new Size(170, 22);
			checkForUpdatesToolStripMenuItem.Text = "Check for &updates";
			checkForUpdatesToolStripMenuItem.Click += checkForUpdatesToolStripMenuItem_Click;
			// 
			// aboutToolStripMenuItem
			// 
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new Size(170, 22);
			aboutToolStripMenuItem.Text = "&About...";
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
			Controls.Add(menuStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			MainMenuStrip = menuStrip1;
			MinimumSize = new Size(400, 570);
			Name = "MainForm";
			Text = "Project Zomboid Save Manager";
			FormClosing += MainForm_FormClosing;
			Shown += MainForm_Shown;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem exitToolStripMenuItem;
		private ToolStripMenuItem optionsToolStripMenuItem;
		private ToolStripMenuItem configureSaveOptionsToolStripMenuItem;
		private ToolStripMenuItem helpToolStripMenuItem;
		private ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private ToolStripMenuItem aboutToolStripMenuItem;
		private Panel pagePanel;
	}
}