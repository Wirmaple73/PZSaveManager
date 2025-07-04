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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewSaveForm));
			label1 = new Label();
			saveDescription = new TextBox();
			okButton = new Button();
			label2 = new Label();
			useCompression = new CheckBox();
			compressToolTip = new ToolTip(components);
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 12);
			label1.Name = "label1";
			label1.Size = new Size(96, 15);
			label1.TabIndex = 0;
			label1.Text = "Save description:";
			// 
			// saveDescription
			// 
			saveDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			saveDescription.Location = new Point(12, 33);
			saveDescription.MaxLength = 200;
			saveDescription.Name = "saveDescription";
			saveDescription.Size = new Size(360, 23);
			saveDescription.TabIndex = 1;
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
			label2.Size = new Size(233, 15);
			label2.TabIndex = 3;
			label2.Text = "Example: \"Before testing my new shotgun\"";
			// 
			// useCompression
			// 
			useCompression.AutoSize = true;
			useCompression.Location = new Point(12, 107);
			useCompression.Name = "useCompression";
			useCompression.Size = new Size(131, 19);
			useCompression.TabIndex = 4;
			useCompression.Text = "Compress save data";
			compressToolTip.SetToolTip(useCompression, resources.GetString("useCompression.ToolTip"));
			useCompression.UseVisualStyleBackColor = true;
			// 
			// compressToolTip
			// 
			compressToolTip.AutoPopDelay = 30000;
			compressToolTip.InitialDelay = 500;
			compressToolTip.ReshowDelay = 100;
			compressToolTip.ToolTipIcon = ToolTipIcon.Info;
			compressToolTip.ToolTipTitle = "Compress save data";
			// 
			// NewSaveForm
			// 
			AcceptButton = okButton;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(384, 141);
			Controls.Add(useCompression);
			Controls.Add(label2);
			Controls.Add(okButton);
			Controls.Add(saveDescription);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			KeyPreview = true;
			MaximizeBox = false;
			MinimizeBox = false;
			MinimumSize = new Size(190, 180);
			Name = "NewSaveForm";
			ShowIcon = false;
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "New Save";
			KeyDown += NewSavepointForm_KeyDown;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox saveDescription;
		private Button okButton;
		private Label label2;
		private CheckBox useCompression;
		private ToolTip compressToolTip;
	}
}