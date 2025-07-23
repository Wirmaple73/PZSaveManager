namespace SavepointManager.Forms
{
	partial class SavingProgressForm
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
			progressBar = new ProgressBar();
			label3 = new Label();
			cancelButton = new Button();
			status = new Label();
			progress = new Label();
			label4 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(10, 9);
			label1.Name = "label1";
			label1.Size = new Size(74, 15);
			label1.TabIndex = 0;
			label1.Text = "Please wait...";
			// 
			// progressBar
			// 
			progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			progressBar.Location = new Point(12, 32);
			progressBar.MarqueeAnimationSpeed = 10;
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(400, 23);
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 1;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(8, 70);
			label3.Name = "label3";
			label3.Size = new Size(42, 15);
			label3.TabIndex = 3;
			label3.Text = "Status:";
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cancelButton.Location = new Point(326, 111);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(86, 28);
			cancelButton.TabIndex = 4;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// status
			// 
			status.AutoSize = true;
			status.Location = new Point(60, 70);
			status.Name = "status";
			status.Size = new Size(121, 15);
			status.TabIndex = 6;
			status.Text = "Beginning to export...";
			// 
			// progress
			// 
			progress.AutoSize = true;
			progress.Location = new Point(60, 89);
			progress.Name = "progress";
			progress.Size = new Size(76, 15);
			progress.TabIndex = 8;
			progress.Text = "Calculating...";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(8, 89);
			label4.Name = "label4";
			label4.Size = new Size(55, 15);
			label4.TabIndex = 7;
			label4.Text = "Progress:";
			// 
			// SavingProgressForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = cancelButton;
			ClientSize = new Size(424, 151);
			Controls.Add(progress);
			Controls.Add(label4);
			Controls.Add(status);
			Controls.Add(cancelButton);
			Controls.Add(label3);
			Controls.Add(progressBar);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			KeyPreview = true;
			MaximizeBox = false;
			Name = "SavingProgressForm";
			ShowIcon = false;
			Text = "Saving";
			FormClosing += ArchiveProgressForm_FormClosing;
			Shown += SavingProgressForm_Shown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ProgressBar progressBar;
		private Label label3;
		private Button cancelButton;
		private Label status;
		private Label progress;
		private Label label4;
	}
}