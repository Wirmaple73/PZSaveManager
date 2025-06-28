namespace SavepointManager.Classes
{
	public static class MessageBoxManager
	{
		public static DialogResult Show(string text, MessageBoxIcon icon = MessageBoxIcon.None, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1)
			=> MessageBox.Show(text, "Project Zomboid Savepoint Manager", buttons, icon, defaultButton);

		public static DialogResult ShowError(string text) => Show(text, MessageBoxIcon.Error);
		public static DialogResult ShowPrompt(string text, bool isYesDefault = true)
			=> Show(text, MessageBoxIcon.Asterisk, MessageBoxButtons.YesNo, isYesDefault ? MessageBoxDefaultButton.Button1 : MessageBoxDefaultButton.Button2);
	}
}
