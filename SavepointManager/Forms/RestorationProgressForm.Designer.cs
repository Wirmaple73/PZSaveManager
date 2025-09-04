namespace SavepointManager.Forms
{
	partial class RestorationProgressForm
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
			status = new Label();
			label3 = new Label();
			progressBar = new ProgressBar();
			label1 = new Label();
			label2 = new Label();
			progress = new Label();
			label4 = new Label();
			SuspendLayout();
			// 
			// status
			// 
			status.AutoSize = true;
			status.Location = new Point(60, 70);
			status.Name = "status";
			status.Size = new Size(211, 15);
			status.TabIndex = 13;
			status.Text = "Backing up current unsaved progress...";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(8, 70);
			label3.Name = "label3";
			label3.Size = new Size(42, 15);
			label3.TabIndex = 10;
			label3.Text = "Status:";
			// 
			// progressBar
			// 
			progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			progressBar.Location = new Point(12, 32);
			progressBar.MarqueeAnimationSpeed = 10;
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(400, 23);
			progressBar.Style = ProgressBarStyle.Marquee;
			progressBar.TabIndex = 8;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(10, 9);
			label1.Name = "label1";
			label1.Size = new Size(74, 15);
			label1.TabIndex = 7;
			label1.Text = "Please wait...";
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new Point(8, 125);
			label2.Name = "label2";
			label2.Size = new Size(368, 15);
			label2.TabIndex = 14;
			label2.Text = "Please do not open the world in-game until this process is complete.";
			// 
			// progress
			// 
			progress.AutoSize = true;
			progress.Location = new Point(60, 89);
			progress.Name = "progress";
			progress.Size = new Size(76, 15);
			progress.TabIndex = 18;
			progress.Text = "Calculating...";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(8, 89);
			label4.Name = "label4";
			label4.Size = new Size(55, 15);
			label4.TabIndex = 17;
			label4.Text = "Progress:";
			// 
			// RestorationProgressForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(424, 151);
			Controls.Add(progress);
			Controls.Add(label4);
			Controls.Add(label2);
			Controls.Add(status);
			Controls.Add(label3);
			Controls.Add(progressBar);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			Name = "RestorationProgressForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Restoring";
			FormClosing += RestorationProgressForm_FormClosing;
			Shown += RestorationProgressForm_Shown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label status;
		private Label label3;
		private ProgressBar progressBar;
		private Label label1;
		private Label label2;
		private Label progress;
		private Label label4;
	}
}