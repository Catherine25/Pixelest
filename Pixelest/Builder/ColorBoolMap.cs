using System.Drawing;
using Pixelest.Model;
using Pixelest.Extension;

namespace Pixelest.Builder
{
    public class ColorBoolMap : BoolMap
    {
        public Color Color { get; private set; }

        public ColorBoolMap(MyBitmap bitmap, Color color): base(bitmap.Size)
        {
            Color = color;

            for (int i = 0; i < Size.Width; i++)
            for (int j = 0; j < Size.Height; j++)
            {
                var currentColor = Color.FromSKColor(bitmap.GetPixel(i,j));
                bool value = Color == currentColor;

                if(value)
                    IsEmpty = false;

                Values[i][j] = value;
            }
        }
    }
}