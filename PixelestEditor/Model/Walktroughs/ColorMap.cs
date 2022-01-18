using System.Collections.Generic;
using System.Drawing;

namespace PixelestEditor.Model.Walktroughs
{
    public class ColorMap
    {
        public ColorData Color { get; set; }
        public HashSet<Point> Map { get; set; }
    }
}