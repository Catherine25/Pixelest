using Pixelest.Extension;
using Pixelest.Model;
using static Pixelest.Extension.ColorConstants;

namespace Pixelest.Builder
{
    public class HueSatBoolMap : BoolMap
    {
        public int Hue { get; private set; }
        public int Saturation { get; private set; }

        public HueSatBoolMap(MyBitmap bitmap, int hue, int saturation): base(bitmap.Size)
        {
            Hue = hue;
            Saturation = saturation;

            Values = new bool[bitmap.Size.Width][];

            for (int i = 0; i < bitmap.Size.Width; i++)
            {
                Values[i] = new bool[bitmap.Size.Height];

                for (int j = 0; j < bitmap.Size.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i,j);
                    bool value = hue == pixel.Get(Parameter.Hue)
                        && saturation == pixel.Get(Parameter.Saturation);
                    
                    if(value)
                        IsEmpty = false;
                    
                    Values[i][j] = value;
                }
            }
        }
    }
}