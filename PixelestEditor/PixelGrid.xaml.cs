using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PixelestEditor.Model.Walktroughs;
using PixelestEditor.Services;
using DPoint = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace PixelestEditor
{
    public partial class PixelGrid
    {
        private IWalkthrough walkthrough;
        private SoundService soundService;
        
        public PixelGrid() => InitializeComponent();

        public void Init(Size size, IWalkthrough walkthrough, SoundService soundService)
        {
            this.walkthrough = walkthrough;
            this.soundService = soundService;

            InitMatrix(size);
            InitPixels(size);
            
            Grid.SizeChanged += GridOnSizeChanged;
        }

        private void GridOnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var width = Grid.ActualWidth;
            var height = Grid.ActualHeight;

            var size = Math.Min(width, height);

            Grid.Width = size;
            Grid.Height = size;
        }

        private void InitMatrix(Size size)
        {
            for (int i = 0; i < size.Width; i++)
                Grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < size.Height; i++)
                Grid.RowDefinitions.Add(new RowDefinition());
        }

        private void InitPixels(Size size)
        {
            Grid.Children.Clear();

            for (int i = 0; i < size.Width; i++)
            for (int j = 0; j < size.Height; j++)
            {
                var pixel = new PixelView(new DPoint(i, j));
                pixel.Activated += PixelActivated;
                Grid.Children.Add(pixel);
            }
        }
        
        private void PixelActivated(PixelView view, DPoint point)
        {
            var simpleWalkthrough = (SimpleWalkthrough) walkthrough;
            var map = simpleWalkthrough.ColorMap;

            var color = map.FirstOrDefault(x => x.Map.Any(x => x.X == point.X && x.Y == point.Y));
            if(color == null)
                return;

            view.Color = color.Color.WColor;
            
            soundService.Play();
        }

        public int HighlightPixelsByColor(ColorData color)
        {
            var map = ((SimpleWalkthrough) walkthrough).ColorMap.First(x => x.Color == color).Map;
            int counter = 0;
            
            foreach (object item in Grid.Children)
            {
                var pixel = (PixelView)item;
                
                if(pixel.Colored)
                    pixel.IsActive = false;
                else if (map.Any(x => x.X == pixel.Point.X && x.Y == pixel.Point.Y))
                {
                    pixel.IsActive = true;
                    counter++;
                }
                else
                    pixel.IsActive = false;
            }
            
            soundService.Play();

            return counter;
        }
    }
}