namespace SavepointManager.Pages
{
	partial class SaveSelectionPage
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
			label1 = new Label();
			saveList = new ListView();
			columnHeader1 = new ColumnHeader();
			columnHeader2 = new ColumnHeader();
			newSavepoint = new Button();
			button2 = new Button();
			label2 = new Label();
			worldName = new Label();
			button3 = new Button();
			backButton = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 40);
			label1.Name = "label1";
			label1.Size = new Size(104, 15);
			label1.TabIndex = 6;
			label1.Text = "Select a savepoint.";
			// 
			// saveList
			// 
			saveList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			saveList.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
			saveList.FullRowSelect = true;
			saveList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
			saveList.Location = new Point(16, 66);
			saveList.MultiSelect = false;
			saveList.Name = "saveList";
			saveList.Size = new Size(417, 335);
			saveList.TabIndex = 12;
			saveList.UseCompatibleStateImageBehavior = false;
			saveList.View = View.Details;
			// 
			// columnHeader1
			// 
			columnHeader1.Text = "Title";
			columnHeader1.Width = 240;
			// 
			// columnHeader2
			// 
			columnHeader2.Text = "Date";
			columnHeader2.Width = 120;
			// 
			// newSavepoint
			// 
			newSavepoint.Location = new Point(445, 65);
			newSavepoint.Name = "newSavepoint";
			newSavepoint.Size = new Size(175, 28);
			newSavepoint.TabIndex = 13;
			newSavepoint.Text = "&New savepoint...";
			newSavepoint.UseVisualStyleBackColor = true;
			newSavepoint.Click += newSavepoint_Click;
			// 
			// button2
			// 
			button2.Location = new Point(445, 109);
			button2.Name = "button2";
			button2.Size = new Size(175, 28);
			button2.TabIndex = 14;
			button2.Text = "&Restore to selected savepoint";
			button2.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label2.Location = new Point(13, 10);
			label2.Name = "label2";
			label2.Size = new Size(44, 15);
			label2.TabIndex = 15;
			label2.Text = "World:";
			// 
			// worldName
			// 
			worldName.AutoSize = true;
			worldName.Location = new Point(54, 10);
			worldName.Name = "worldName";
			worldName.Size = new Size(133, 15);
			worldName.TabIndex = 16;
			worldName.Text = "How are you even here?";
			// 
			// button3
			// 
			button3.Location = new Point(445, 153);
			button3.Name = "button3";
			button3.Size = new Size(175, 28);
			button3.TabIndex = 17;
			button3.Text = "&Delete";
			button3.UseVisualStyleBackColor = true;
			// 
			// backButton
			// 
			backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			backButton.DialogResult = DialogResult.OK;
			backButton.Location = new Point(15, 417);
			backButton.Name = "backButton";
			backButton.Size = new Size(112, 28);
			backButton.TabIndex = 18;
			backButton.Text = "&Back";
			// 
			// SaveSelectionPage
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(backButton);
			Controls.Add(button3);
			Controls.Add(worldName);
			Controls.Add(label2);
			Controls.Add(button2);
			Controls.Add(newSavepoint);
			Controls.Add(saveList);
			Controls.Add(label1);
			Name = "SaveSelectionPage";
			Size = new Size(634, 461);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ListView saveList;
		private ColumnHeader columnHeader1;
		private ColumnHeader columnHeader2;
		private Button newSavepoint;
		private Button button2;
		private Label label2;
		private Label worldName;
		private Button button3;
		private Button backButton;
	}
}
