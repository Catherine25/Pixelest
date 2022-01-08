using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Pixelest
{
    public class ColorMap
    {
        public ColorMap()
        {
            Lightnesses = new List<HuesByLightness>();
        }

        public List<HuesByLightness> Lightnesses { get; set; }

        public void AddPoint(Point point, int lightness, int hue)
        {
            var curLightness = Lightnesses.FirstOrDefault(l=>l.Lightness == lightness);
            if(curLightness != null)
            {
                var curHue = Lightnesses
                    .FirstOrDefault(l=>l.Lightness == lightness)
                    .Hues
                    .FirstOrDefault(h=>h.Hue == hue);

                if(curHue != null)
                    Lightnesses
                        .First(l=>l.Lightness == lightness)
                        .Hues.First(h=>h.Hue == hue)
                        .Points.Add(point);
                else
                    Lightnesses
                        .First(l=>l.Lightness == lightness)
                        .Hues.Add(new PointsByHue(hue, point));
            }
            else
                Lightnesses.Add(new HuesByLightness(lightness, hue, point));
        }
    }

    public class HuesByLightness
    {
        public HuesByLightness(int lightness, int hue, Point point)
        {
            Lightness = lightness;
            Hues = new List<PointsByHue>();
            Hues.Add(new PointsByHue(hue, point));
        }

        public int Lightness { get; set; }
        public List<PointsByHue> Hues { get; set; }
    }

    public class PointsByHue
    {
        public PointsByHue(int hue, Point point)
        {
            Hue = hue;
            Points = new List<Point>();
            Points.Add(point);
        }

        public int Hue { get; set; }
        public List<Point> Points { get; set; }
    }
}