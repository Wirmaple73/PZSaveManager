namespace SavepointManager.Classes
{
	public static class MessageBoxManager
	{
		public static DialogResult Show(string text, string title, MessageBoxIcon icon = MessageBoxIcon.None, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
			=> MessageBox.Show(text, title, buttons, icon, defaultButton);

		public static DialogResult ShowInfo(string text, string title) => Show(text, title, MessageBoxIcon.Asterisk);
		public static DialogResult ShowError(string text) => Show(text, "Error", MessageBoxIcon.Error);
		public static bool ShowConfirmation(string text, string title, MessageBoxIcon icon = MessageBoxIcon.Warning, bool isYesDefault = false)
			=> Show(text, title, icon, MessageBoxButtons.YesNo, isYesDefault ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2) == DialogResult.Yes;
	}
}
