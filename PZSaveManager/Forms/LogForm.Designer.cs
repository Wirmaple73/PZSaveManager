namespace PZSaveManager.Forms
{
    partial class LogForm
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
            logBox = new TextBox();
            logFileName = new LinkLabel();
            autoscrollCheckBox = new CheckBox();
            clearButton = new Button();
            wordWrapCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Log file:";
            // 
            // logBox
            // 
            logBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logBox.BackColor = SystemColors.Window;
            logBox.Location = new Point(12, 32);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.ScrollBars = ScrollBars.Vertical;
            logBox.Size = new Size(510, 327);
            logBox.TabIndex = 1;
            // 
            // logFileName
            // 
            logFileName.AutoSize = true;
            logFileName.Location = new Point(58, 9);
            logFileName.Name = "logFileName";
            logFileName.Size = new Size(62, 15);
            logFileName.TabIndex = 3;
            logFileName.TabStop = true;
            logFileName.Text = "Fetching...";
            logFileName.LinkClicked += logFileName_LinkClicked;
            // 
            // autoscrollCheckBox
            // 
            autoscrollCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            autoscrollCheckBox.AutoSize = true;
            autoscrollCheckBox.Checked = true;
            autoscrollCheckBox.CheckState = CheckState.Checked;
            autoscrollCheckBox.Location = new Point(337, 377);
            autoscrollCheckBox.Name = "autoscrollCheckBox";
            autoscrollCheckBox.Size = new Size(85, 19);
            autoscrollCheckBox.TabIndex = 4;
            autoscrollCheckBox.Text = "&Auto-scroll";
            autoscrollCheckBox.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            clearButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            clearButton.FlatStyle = FlatStyle.System;
            clearButton.Location = new Point(12, 371);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(86, 28);
            clearButton.TabIndex = 5;
            clearButton.Text = "&Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // wordWrapCheckBox
            // 
            wordWrapCheckBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            wordWrapCheckBox.AutoSize = true;
            wordWrapCheckBox.Checked = true;
            wordWrapCheckBox.CheckState = CheckState.Checked;
            wordWrapCheckBox.Location = new Point(438, 377);
            wordWrapCheckBox.Name = "wordWrapCheckBox";
            wordWrapCheckBox.Size = new Size(84, 19);
            wordWrapCheckBox.TabIndex = 6;
            wordWrapCheckBox.Text = "&Word wrap";
            wordWrapCheckBox.UseVisualStyleBackColor = true;
            wordWrapCheckBox.CheckedChanged += wordWrapCheckBox_CheckedChanged;
            // 
            // LogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(534, 411);
            Controls.Add(wordWrapCheckBox);
            Controls.Add(clearButton);
            Controls.Add(autoscrollCheckBox);
            Controls.Add(logFileName);
            Controls.Add(logBox);
            Controls.Add(label1);
            MinimumSize = new Size(345, 190);
            Name = "LogForm";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Logs";
            FormClosed += LogForm_FormClosed;
            Shown += LogForm_Shown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox logBox;
        private LinkLabel logFileName;
        private CheckBox autoscrollCheckBox;
        private Button clearButton;
        private CheckBox wordWrapCheckBox;
    }
}