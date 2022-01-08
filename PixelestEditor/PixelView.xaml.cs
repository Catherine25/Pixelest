using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DPoint = System.Drawing.Point;

namespace PixelestEditor
{
    public partial class PixelView : UserControl
    {
        public readonly Color DefaultColor = Colors.White;

        public Action<PixelView, DPoint> Activated;
        public DPoint Point;

        public PixelView() => InitializeComponent();

        public PixelView(DPoint position)
        {
            InitializeComponent();

            Rect.Fill = new SolidColorBrush(DefaultColor);

            Point = position;

            Canvas.SetLeft(this, Point.X);
            Canvas.SetTop(this, Point.Y);
            Width = Constants.PixelSize.Width;
            Height = Constants.PixelSize.Height;

            Rect.MouseDown += Rect_MouseDown;
            TextBox.MouseDown += Rect_MouseDown;
        }

        private void Rect_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(IsActive)
            {
                Activated(this, Point);
                IsActive = false;
            }
        }

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;

                if(isActive)
                {
                    //BorderBrush = new SolidColorBrush(Colors.Black);
                    //BorderThickness = new System.Windows.Thickness(1);
                    TextBox.Content = "X";
                }
                else
                {
                    //BorderBrush = null;
                    //BorderThickness = new System.Windows.Thickness(0);
                    TextBox.Content = "";
                }
            }
        }
        private bool isActive;

        public Color Color
        {
            get => Rect.GetColor() ?? DefaultColor;
            set
            {
                //TextBox.Background = new SolidColorBrush(value);
                Rect.SetColor(value);
                IsActive = false;
            }
        }
    }
}
