namespace SavepointManager.Forms
{
	partial class SaveRelocationProgressForm
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
			SuspendLayout();
			// 
			// status
			// 
			status.AutoSize = true;
			status.Location = new Point(47, 70);
			status.Name = "status";
			status.Size = new Size(174, 15);
			status.TabIndex = 13;
			status.Text = "Moving saves to the new path...";
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
			progressBar.Style = ProgressBarStyle.Continuous;
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
			// SaveRelocationProgressForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(424, 101);
			ControlBox = false;
			Controls.Add(status);
			Controls.Add(label3);
			Controls.Add(progressBar);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "SaveRelocationProgressForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "Moving Saves";
			FormClosing += SaveRelocationProgressForm_FormClosing;
			Shown += SaveRelocationProgressForm_Shown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label status;
		private Label label3;
		private ProgressBar progressBar;
		private Label label1;
	}
}
