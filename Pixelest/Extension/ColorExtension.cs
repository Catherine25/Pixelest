using System.Drawing;
using SkiaSharp;
using static Pixelest.Extension.ColorConstants;

namespace Pixelest.Extension
{
    public static class ColorExtension
    {
        public static Color FromSKColor(this Color color, SKColor SKColor) => Color.FromArgb(SKColor.Red, SKColor.Green, SKColor.Blue);

        public static int Get(this SKColor color, Parameter param)
        {
            switch (param)
            {
                case Parameter.Alpha:
                    return color.Alpha;
                case Parameter.Red:
                    return color.Red;
                case Parameter.Green:
                    return color.Green;
                case Parameter.Blue:
                    return color.Blue;
                case Parameter.Hue:
                    return (int)color.Hue;
                case Parameter.Saturation:
                    {
                        color.ToHsl(out float hue, out float saturation, out float lightness);
                        return (int)saturation;
                    }
                case Parameter.Lightness:
                    {
                        color.ToHsl(out float hue, out float saturation, out float lightness);
                        return (int)lightness;
                    }
                default:
                    throw new System.Exception();
            }
        }
    }
}