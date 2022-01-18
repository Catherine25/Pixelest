// using System.Drawing;
// using System.Windows.Controls;
// using System.Windows.Media;
// using SkiaSharp;
// using Rect = System.Windows.Shapes.Rectangle;
//
// namespace PixelestEditor
// {
//     public static class RectangleBuilder
//     {
//         public static Rect FromBitmapPixel(Point point, SKBitmap bitmap)
//         {
//             var pixel = bitmap.GetPixel(point.X, point.Y);
//             
//             Rect rectangle = new Rect();
//             rectangle.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(pixel.Red, pixel.Green, pixel.Blue));
//             
//             Grid.SetColumn(rectangle, point.X);
//             Grid.SetRow(rectangle, point.Y);
//
//             return rectangle;
//         }
//
//         public static Rect FromPointAndColor(Point point, SKColor color)
//         {
//             Rect rectangle = new Rect();
//             rectangle.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(color.Red, color.Green, color.Blue));
//             
//             Grid.SetColumn(rectangle, point.X);
//             Grid.SetRow(rectangle, point.Y);
//
//             return rectangle;
//         }
//     }
// }