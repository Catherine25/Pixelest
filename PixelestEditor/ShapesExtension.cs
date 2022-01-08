using System.Windows.Media;
using System.Windows.Shapes;

namespace PixelestEditor
{
    public static class ShapesExtension
    {
        public static Color? GetColor(this Shape shape) => ((SolidColorBrush) shape.Fill)?.Color;
        public static void SetColor(this Shape shape, Color color)
        {
            if (shape.Fill != null)
                ((SolidColorBrush) shape.Fill).Color = color;
            else shape.Fill = null;
        }
    }
}