namespace PZSaveManager.Classes
{
	public static class MessageBoxManager
	{
		public static DialogResult Show(string text, string title, MessageBoxIcon icon = MessageBoxIcon.None, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
			=> MessageBox.Show(text, title, buttons, icon, defaultButton);

		public static DialogResult ShowInfo(string text, string title) => Show(text, title, MessageBoxIcon.Asterisk);

		public static DialogResult ShowError(string text) => Show(text, "Error", MessageBoxIcon.Error);

        public static DialogResult ShowDetailedError(string abstractMessage, string errorMessage) => ShowError($"{abstractMessage}\n\nError message: {errorMessage}\n\nInspecting the logs may reveal more details (Logs > View Logs or Ctrl+L).");
		public static DialogResult ShowDetailedError(string abstractMessage, Exception ex) => ShowDetailedError(abstractMessage, $"{ex.Message}\n\nStack trace:\n{ex.StackTrace}");

        public static DialogResult ShowWarning(string text) => Show(text, "Warning", MessageBoxIcon.Warning);

		public static bool ShowConfirmation(string text, string title, MessageBoxIcon icon = MessageBoxIcon.Warning, bool isYesDefault = false)
			=> Show(text, title, icon, MessageBoxButtons.YesNo, isYesDefault ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes;
	}
}
