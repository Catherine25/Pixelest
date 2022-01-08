using System.Drawing;

namespace Pixelest.Json
{
    public class ColorBoolMapData
    {
        public bool[][] Values;
        public Size Size;
        public bool IsEmpty = true;
        public Color Color { get; set; }
    }
}