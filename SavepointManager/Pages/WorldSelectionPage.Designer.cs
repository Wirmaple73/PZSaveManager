namespace SavepointManager.Forms
{
	partial class WorldSelectionPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			nextButton = new Button();
			worldPreview = new PictureBox();
			label2 = new Label();
			label1 = new Label();
			worldList = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			columnHeader3 = new ColumnHeader();
			errorLabel = new Label();
			errorLabelIcon = new PictureBox();
			((System.ComponentModel.ISupportInitialize)worldPreview).BeginInit();
			((System.ComponentModel.ISupportInitialize)errorLabelIcon).BeginInit();
			SuspendLayout();
			// 
			// nextButton
			// 
			nextButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			nextButton.DialogResult = DialogResult.OK;
			nextButton.Location = new Point(15, 417);
			nextButton.Name = "nextButton";
			nextButton.Size = new Size(112, 28);
			nextButton.TabIndex = 9;
			nextButton.Text = "&Next";
			// 
			// worldPreview
			// 
			worldPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			worldPreview.BorderStyle = BorderStyle.FixedSingle;
			worldPreview.Location = new Point(417, 36);
			worldPreview.Name = "worldPreview";
			worldPreview.Size = new Size(200, 200);
			worldPreview.SizeMode = PictureBoxSizeMode.Zoom;
			worldPreview.TabIndex = 8;
			worldPreview.TabStop = false;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label2.Location = new Point(417, 241);
			label2.Name = "label2";
			label2.Size = new Size(200, 15);
			label2.TabIndex = 7;
			label2.Text = "World preview";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 10);
			label1.Name = "label1";
			label1.Size = new Size(156, 15);
			label1.TabIndex = 5;
			label1.Text = "Select a world to begin with.";
			// 
			// worldList
			// 
			worldList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			worldList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
			worldList.FullRowSelect = true;
			worldList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			worldList.Location = new Point(16, 36);
			worldList.MultiSelect = false;
			worldList.Name = "worldList";
			worldList.Size = new Size(382, 364);
			worldList.TabIndex = 11;
			worldList.UseCompatibleStateImageBehavior = false;
			worldList.View = View.Details;
			worldList.SelectedIndexChanged += saveList_SelectedIndexChanged;
			worldList.DoubleClick += worldList_DoubleClick;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Title";
			columnHeader1.Width = 220;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Gamemode";
			columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			columnHeader3.Text = "Active";
			columnHeader3.Width = 50;
			// 
			// errorLabel
			// 
			errorLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			errorLabel.AutoEllipsis = true;
			errorLabel.Location = new Point(175, 417);
			errorLabel.Name = "errorLabel";
			errorLabel.Size = new Size(442, 40);
			errorLabel.TabIndex = 12;
			errorLabel.Visible = false;
			errorLabel.TextChanged += errorLabel_TextChanged;
			// 
			// errorLabelIcon
			// 
			errorLabelIcon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			errorLabelIcon.Location = new Point(141, 417);
			errorLabelIcon.Name = "errorLabelIcon";
			errorLabelIcon.Size = new Size(28, 28);
			errorLabelIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			errorLabelIcon.TabIndex = 13;
			errorLabelIcon.TabStop = false;
			errorLabelIcon.Visible = false;
			// 
			// WorldSelectionPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(errorLabelIcon);
			Controls.Add(errorLabel);
			Controls.Add(worldList);
			Controls.Add(nextButton);
			Controls.Add(worldPreview);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "WorldSelectionPage";
			Size = new Size(634, 461);
			((System.ComponentModel.ISupportInitialize)worldPreview).EndInit();
			((System.ComponentModel.ISupportInitialize)errorLabelIcon).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label label2;
		private Label label1;
		private PictureBox worldPreview;
		private ListView worldList;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private ColumnHeader columnHeader3;
		private Button nextButton;
		private Label errorLabel;
		private PictureBox errorLabelIcon;
	}
}
