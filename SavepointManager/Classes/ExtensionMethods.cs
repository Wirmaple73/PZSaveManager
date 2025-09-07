namespace SavepointManager.Classes
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
	}
}
