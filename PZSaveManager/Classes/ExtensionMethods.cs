using PZSaveManager.Forms;
using System.Diagnostics;

namespace PZSaveManager.Classes
{
	public static class ExtensionMethods
	{
		public static Bitmap CropCenter(this Bitmap source, int width, int height)
		{
			// Ensure the crop size doesn't exceed the source size
			width = Math.Min(width, source.Width);
			height = Math.Min(height, source.Height);

			int x = (source.Width - width) / 2;
			int y = (source.Height - height) / 2;

			var cropRect = new Rectangle(x, y, width, height);
			return source.Clone(cropRect, source.PixelFormat);
		}

		public static async Task DeleteParallelAsync(this DirectoryInfo path)
		{
			await Task.Run(() =>
			{
				Parallel.ForEach(Directory.EnumerateFiles(path.FullName, "*", SearchOption.AllDirectories), filePath =>
				{
					try
					{
						File.Delete(filePath);
					}
					catch (Exception ex)
					{
						Logger.Log($"Could not delete {filePath}", ex);
					}
				});

				Directory.Delete(path.FullName, true);
			});
		}

		public static void ScrollTo(this TextBox box, int index)
		{
            box.Focus();
            box.SelectionStart = index;
            box.ScrollToCaret();
        }

		public static void ScrollToEnd(this TextBox box) => ScrollTo(box, box.TextLength);

		public static void BringToFrontReal(this Form form)
		{
            if (form.WindowState == FormWindowState.Minimized)
                form.WindowState = FormWindowState.Normal;

            form.BringToFront();
            form.Activate();
        }
	}
}
