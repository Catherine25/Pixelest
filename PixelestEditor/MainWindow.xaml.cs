using Pixelest;
using Pixelest.Json;
using Pixelest.Model;
using PixelestEditor.Extension;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DPoint = System.Drawing.Point;

namespace PixelestEditor
{
    public partial class MainWindow : Window
    {
        int cellsToColor = 0;
        ImageInfoData info;
        ColoringScenarioData scenario;
        ColorBoolMapData map;
        SoundPlayer player;

        public MainWindow()
        {
            InitializeComponent();
            player = new SoundPlayer(@"C:\Users\Xiaomi\Music\demo-2.wav");
            player.Load();

            info = Serializer.DeserializeFromFile<ImageInfoData>(@"C:\Users\Xiaomi\Pictures\demo-sprites\demo-5.txt");

            // init pixels
            for (int i = 0; i < info.Bitmap.Size.Width; i++)
                for (int j = 0; j < info.Bitmap.Size.Height; j++)
                {
                    var pixel = new PixelView(new DPoint(i * Constants.PixelSize.Width, j * Constants.PixelSize.Height));
                    pixel.Activated += PixelActivated;
                    Canvas.Children.Add(pixel);
                }

            scenario = info.Scenarios.First(s => s.Name == "Simple");
            map = scenario.BoolMaps.Dequeue();
            cellsToColor = PrepareForColoring(map);
            Debug.WriteLine($"Prepared {cellsToColor} cells.");
            
            this.Content = Canvas;
        }

        private void PixelActivated(PixelView view, DPoint point)
        {
            view.Color = new Color().FromDColor(map.Color);

            player.Play();

            cellsToColor--;

            if (cellsToColor == 0)
            {
                // todo handle win
                map = scenario.BoolMaps.Dequeue();
                cellsToColor = PrepareForColoring(map);
            }

            Debug.WriteLine("cellsToColor:" + cellsToColor);
            Debug.WriteLine(scenario.BoolMaps.Count);
        }

        private int PrepareForColoring(ColorBoolMapData boolMap)
        {
            int count = 0;

            foreach (var item in Canvas.Children)
            {
                PixelView pixel = item as PixelView;

                int x = pixel.Point.X / Constants.PixelSize.Width;
                int y = pixel.Point.Y / Constants.PixelSize.Height;
                if (boolMap.Values[x][y])
                {
                    Debug.WriteLine($"{x},{y}");
                    Debug.WriteLine("active");
                    pixel.IsActive = true;
                    count++;
                }
            }

            return count;
        }
    }
}
