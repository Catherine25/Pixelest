using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using SkiaSharp;

namespace PixelestEditor.Model.Walktroughs
{
    public class SimpleWalkthrough : IWalkthrough
    {
        public string Name => IWalkthrough.Simple;
        
        public HashSet<ColorMap> ColorMap { get; set; }
        
        public void Build(SKBitmap bitmap)
        {
            ColorMap = new HashSet<ColorMap>();
            
            for (int x = 0; x < bitmap.Width; x++)
            for (int y = 0; y < bitmap.Height; y++)
            {
                var pixel = bitmap.GetPixel(x,y);
                var processed = ColorMap.FirstOrDefault(map => map.Color.SkColor == pixel);

                if (processed == null)
                    ColorMap.Add(new ColorMap { Color = new ColorData(pixel.ToString()), Map = new HashSet<Point>{ new(x, y)}});
                else
                    processed.Map.Add(new Point(x, y));
            }
        }
    }
}