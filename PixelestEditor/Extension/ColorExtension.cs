using System.Windows.Media;
using SkiaSharp;
using DColor = System.Drawing.Color;

namespace PixelestEditor.Extension
{
    public static class ColorExtension
    {
        public static Color FromSKColor(this Color color, SKColor SKColor) => Color.FromRgb(SKColor.Red, SKColor.Green, SKColor.Blue);
        public static Color FromDColor(this Color color, DColor DColor) => Color.FromRgb(DColor.R, DColor.G, DColor.B);
    }
}