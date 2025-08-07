using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public static class PageLoader
	{
		public static event EventHandler<EventArgs>? OnPageLoaded;

		public static void Load(Control host, UserControl page)
		{
			page.Dock = DockStyle.Fill;

			host.Controls.Clear();
			host.Controls.Add(page);

			OnPageLoaded?.Invoke(null, EventArgs.Empty);
		}
	}
}
