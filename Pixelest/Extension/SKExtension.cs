using System.Drawing;
using System.IO;
using SkiaSharp;
using static Pixelest.Extension.ColorConstants;

namespace Pixelest.Extension
{
    public static class SKExtension
    {
        public static Size GetSize(this SKBitmap bitmap) => new Size(bitmap.Width, bitmap.Height);

        public static SKBitmap FromFile(this SKBitmap bitmap, string path)
        {
            bitmap = new SKBitmap();

            using (FileStream stream = File.OpenRead(path))
                bitmap = SKBitmap.Decode(stream);

            return bitmap;
        }

        public static int MaxParameterValue(this SKBitmap bitmap, Parameter parameter) => MaxParameterValue(bitmap, bitmap.GetSize(), parameter);

        public static int MaxParameterValue(this SKBitmap bitmap, Size bitmapSizeToCheck, Parameter parameter)
        {
            int value = 0;

            for (int i = 0; i < bitmapSizeToCheck.Width; i++)
            for (int j = 0; j < bitmapSizeToCheck.Height; j++)
            {
                int current = bitmap.GetPixel(i,j).Get(parameter);
                if(value < current)
                    value = current;
            }

            return value;
        }
    }
}