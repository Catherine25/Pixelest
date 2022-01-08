using System.Collections.Generic;
using System.Drawing;
using Pixelest.Extension;
using SkiaSharp;
using static Pixelest.Extension.ColorConstants;

namespace Pixelest.Model
{
    public class MyBitmap
    {
        public MyBitmap(string bitmapPath)
        {
            Bitmap = new SKBitmap().FromFile(bitmapPath);
            Size = Settings.GetMaxAllowedSize(Bitmap.GetSize());
        }

        /// <summary>
        /// Handled size of the <see cref="Bitmap"/>.
        /// </summary>
        /// <value></value>
        public Size Size;
        private SKBitmap Bitmap;

        public SKColor GetPixel(int x, int y) => Bitmap.GetPixel(x, y);
        public SKColor GetPixel(Point p) => Bitmap.GetPixel(p.X, p.Y);

        // Func<MyBitmap, Parameter, int> curSelector = (bitmap, param) => {
        //     int value = 0;
            
        //     for (int i = 0; i < bitmap.Size.Width; i++)
        //     for (int j = 0; j < bitmap.Size.Height; j++)
        //     {
        //         int current = bitmap.GetPixel(i,j).Get(param);
        //         if(current > value)
        //             value = current;
        //     }

        //     return value;
        // };

        public int GetMaxParameterValue(Parameter parameter)
        {
            int value = 0;
            
            for (int i = 0; i < Size.Width; i++)
            for (int j = 0; j < Size.Height; j++)
            {
                int current = Bitmap.GetPixel(i,j).Get(parameter);
                if(current > value)
                    value = current;
            }

            return value;
        }

        public List<Color> GetAllColors()
        {
            List<Color> colors = new List<Color>();
            
            for (int i = 0; i < Size.Width; i++)
            for (int j = 0; j < Size.Height; j++)
            {
                Color current = new Color().FromSKColor(Bitmap.GetPixel(i,j));
                if (!colors.Contains(current))
                    colors.Add(current);
            }

            return colors;
        }

        public List<int> GetParameterValues(Parameter parameter)
        {
            List<int> values = new List<int>();
            
            for (int i = 0; i < Size.Width; i++)
            for (int j = 0; j < Size.Height; j++)
            {
                int current =  Bitmap.GetPixel(i,j).Get(parameter);
                if (!values.Contains(current))
                    values.Add(current);
            }

            return values;
        }

        // public void IterateThroughPixels(Func<bool> action)
        // {
        //     for (int i = 0; i < Size.Width; i++)
        //     for (int j = 0; j < Size.Height; j++)
        //     {
        //     }
        // }
    }
}