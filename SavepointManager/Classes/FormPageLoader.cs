namespace SavepointManager.Classes
{
	public static class FormPageLoader
	{
		public static void Load(Panel host, UserControl page)
		{
			page.Dock = DockStyle.Fill;

			host.Controls.Clear();
			host.Controls.Add(page);
		}
	}
}
