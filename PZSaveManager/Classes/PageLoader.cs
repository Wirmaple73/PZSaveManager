namespace PZSaveManager.Classes
{
	public static class PageLoader
	{
		public static UserControl? CurrentPage { get; set; } = null;

		public static void Load<T>(Control host, T page) where T : UserControl, IPage
		{
			page.Dock = DockStyle.Fill;

			host.Controls.Clear();
			host.Controls.Add(page);

			CurrentPage = page;
			page.PageLoaded();
		}
	}
}
