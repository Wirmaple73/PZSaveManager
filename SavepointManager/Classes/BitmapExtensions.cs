using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavepointManager.Classes
{
	public static class BitmapExtensions
	{
		public static Bitmap CropCenterAndResize(this Bitmap source, int targetSize)
		{
			float srcAspect = source.Width / (float)source.Height;
			int cropWidth, cropHeight;

			if (srcAspect > 1)
			{
				// Wider than tall – crop horizontally
				cropHeight = source.Height;
				cropWidth = (int)(cropHeight * 1.0f); // Make square based on height
			}
			else
			{
				// Taller than wide or square – crop vertically
				cropWidth = source.Width;
				cropHeight = (int)(cropWidth * 1.0f); // Make square based on width
			}

			int x = (source.Width - cropWidth) / 2;
			int y = (source.Height - cropHeight) / 2;

			var cropRect = new Rectangle(x, y, cropWidth, cropHeight);
			using Bitmap cropped = source.Clone(cropRect, source.PixelFormat);

			var resized = new Bitmap(targetSize, targetSize);

			using (Graphics g = Graphics.FromImage(resized))
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				g.DrawImage(cropped, 0, 0, targetSize, targetSize);
			}

			return resized;
		}
	}

}
