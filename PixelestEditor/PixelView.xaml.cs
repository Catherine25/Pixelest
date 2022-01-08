using System;
using System.Windows.Controls;
using System.Windows.Media;
using DPoint = System.Drawing.Point;

namespace PixelestEditor
{
    public partial class PixelView
    {
        private readonly Color defaultColor = Colors.White;

        public Action<PixelView, DPoint> Activated;
        public DPoint Point;

        public PixelView() => InitializeComponent();

        public PixelView(DPoint position)
        {
            InitializeComponent();

            Rect.Fill = new SolidColorBrush(defaultColor);

            Point = position;

            Canvas.SetLeft(this, Point.X);
            Canvas.SetTop(this, Point.Y);
            Width = Constants.PixelSize.Width;
            Height = Constants.PixelSize.Height;

            TextBox.MouseEnter += (_, _) => Activate();
        }

        private void Activate()
        {
            if (!IsActive)
                return;
            
            Activated(this, Point);
            IsActive = false;
        }

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                TextBox.Content = isActive ? "X" : "";
            }
        }
        private bool isActive;

        public Color Color
        {
            get => Rect.GetColor() ?? defaultColor;
            set
            {
                Rect.SetColor(value);
                IsActive = false;
            }
        }
    }
}
