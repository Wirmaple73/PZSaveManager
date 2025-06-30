namespace SavepointManager.Forms
{
	partial class ArchiveProgressForm
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
			label2 = new Label();
			label3 = new Label();
			cancelButton = new Button();
			fileName = new Label();
			progress = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(10, 7);
			label1.Name = "label1";
			label1.Size = new Size(74, 15);
			label1.TabIndex = 0;
			label1.Text = "Please wait...";
			// 
			// progressBar
			// 
			progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			progressBar.Location = new Point(12, 30);
			progressBar.Name = "progressBar";
			progressBar.Size = new Size(400, 23);
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.TabIndex = 1;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label2.AutoSize = true;
			label2.Location = new Point(8, 87);
			label2.Name = "label2";
			label2.Size = new Size(28, 15);
			label2.TabIndex = 2;
			label2.Text = "File:";
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			label3.AutoSize = true;
			label3.Location = new Point(8, 110);
			label3.Name = "label3";
			label3.Size = new Size(55, 15);
			label3.TabIndex = 3;
			label3.Text = "Progress:";
			// 
			// cancelButton
			// 
			cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			cancelButton.Location = new Point(326, 101);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(86, 28);
			cancelButton.TabIndex = 4;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			// 
			// fileName
			// 
			fileName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			fileName.AutoSize = true;
			fileName.Location = new Point(61, 87);
			fileName.Name = "fileName";
			fileName.Size = new Size(58, 15);
			fileName.TabIndex = 5;
			fileName.Text = "File name";
			// 
			// progress
			// 
			progress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			progress.AutoSize = true;
			progress.Location = new Point(61, 110);
			progress.Name = "progress";
			progress.Size = new Size(52, 15);
			progress.TabIndex = 6;
			progress.Text = "Progress";
			// 
			// ArchiveProgressForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = cancelButton;
			ClientSize = new Size(424, 141);
			Controls.Add(progress);
			Controls.Add(fileName);
			Controls.Add(cancelButton);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(progressBar);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			KeyPreview = true;
			MaximizeBox = false;
			Name = "ArchiveProgressForm";
			ShowIcon = false;
			Text = "Saving";
			FormClosing += ArchiveProgressForm_FormClosing;
			Load += ArchiveProgressForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ProgressBar progressBar;
		private Label label2;
		private Label label3;
		private Button cancelButton;
		private Label fileName;
		private Label progress;
	}
}