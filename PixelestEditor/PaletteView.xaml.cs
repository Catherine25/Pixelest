using System;
using System.Windows.Media;
using PixelestEditor.Model.Walktroughs;

namespace PixelestEditor
{
    public partial class PaletteView
    {
        public event Action<ColorData> Activated;
        public PaletteView()
        {
            InitializeComponent();

            Button.Click += (_, _) => Activated(colorData);
        }

        public ColorData Color
        {
            set
            {
                colorData = value;
                Background = new SolidColorBrush(colorData.WColor);
            }
        }

        private ColorData colorData;
    }
}