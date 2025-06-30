namespace SavepointManager.Forms
{
	partial class NewSaveForm
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
			saveTitle = new TextBox();
			okButton = new Button();
			label2 = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 12);
			label1.Name = "label1";
			label1.Size = new Size(57, 15);
			label1.TabIndex = 0;
			label1.Text = "Save title:";
			// 
			// saveTitle
			// 
			saveTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			saveTitle.Location = new Point(12, 33);
			saveTitle.MaxLength = 200;
			saveTitle.Name = "saveTitle";
			saveTitle.Size = new Size(360, 23);
			saveTitle.TabIndex = 1;
			// 
			// okButton
			// 
			okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			okButton.Location = new Point(286, 101);
			okButton.Name = "okButton";
			okButton.Size = new Size(86, 28);
			okButton.TabIndex = 2;
			okButton.Text = "&OK";
			okButton.UseVisualStyleBackColor = true;
			okButton.Click += okButton_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(9, 69);
			label2.Name = "label2";
			label2.Size = new Size(159, 15);
			label2.TabIndex = 3;
			label2.Text = "Example: \"After the loot run\"";
			// 
			// NewSavepointForm
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(384, 141);
			Controls.Add(label2);
			Controls.Add(okButton);
			Controls.Add(saveTitle);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			KeyPreview = true;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new Size(190, 180);
			Name = "NewSavepointForm";
			ShowIcon = false;
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "New Savepoint";
			KeyDown += NewSavepointForm_KeyDown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox saveTitle;
		private Button okButton;
		private Label label2;
	}
}