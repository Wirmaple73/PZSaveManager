using PZSaveManager.Classes;

namespace PZSaveManager.Forms
{
    public partial class LogForm : Form
    {
        public LogForm() => InitializeComponent();

        private void LogForm_Shown(object sender, EventArgs e)
        {
            UpdateLogFileName();

            try
            {
                using var fs = new FileStream(Logger.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                using var sr = new StreamReader(fs);

                logBox.Text = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowDetailedError($"Could not read {Logger.FilePath}.", ex);
            }

            logBox.ScrollToEnd();
            Logger.Logged += Logger_Logged;
        }

        private void logFileName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => FileExplorer.Browse(Logger.FilePath, true);

        private void clearButton_Click(object sender, EventArgs e) => logBox.Clear();

        private void LogForm_FormClosed(object sender, FormClosedEventArgs e) => Logger.Logged -= Logger_Logged;

        private void Logger_Logged(object? sender, LogEventArgs e)
        {
            this.Invoke(() =>
            {
                int lastCaretPosition = logBox.SelectionStart;

                logBox.Text += e.Message + "\r\n";
                UpdateLogFileName();

                if (WindowHelper.IsInForeground(this.Handle))
                {
                    if (autoscrollCheckBox.Checked)
                        logBox.ScrollToEnd();
                    else
                        logBox.ScrollTo(lastCaretPosition);
                }
            });
        }

        private void UpdateLogFileName() => logFileName.Text = Logger.FileName + " (click to browse)";

        private void wordWrapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            logBox.WordWrap = wordWrapCheckBox.Checked;
            logBox.ScrollBars = logBox.WordWrap ? ScrollBars.Vertical : ScrollBars.Both;
        }
    }
}
