using System;
using System.Collections.Generic;
using PixelestEditor.Extensions;
using System.Linq;
using System.Windows.Controls;
using Pixelest.Extension;
using PixelestEditor.Model.Walktroughs;
using PixelestEditor.Services;
using SkiaSharp;
using DPoint = System.Drawing.Point;

namespace PixelestEditor
{
    public partial class MainWindow
    {
        private readonly SoundService soundService;
        private readonly ImageService imageService;

        private SKBitmap bitmap;

        private IWalkthrough walkthrough;
        private int cellsToColor;

        public MainWindow()
        {
            InitializeComponent();
            
            this.Log(Environment.CurrentDirectory);
            
            imageService = new ImageService();
            soundService = new SoundService(Environment.CurrentDirectory + "/Assets/demo-2.wav");
            
            ScenariosCombobox.Items.Add(IWalkthrough.Simple);
            ScenariosCombobox.SelectedIndex = 0;

            LoadImageButton.Click += (_, _) => LoadImage();
            RestartButton.Click += (_, _) =>  StartScenario();
        }

        private void LoadImage()
        {
            bitmap = imageService.LoadBitmap(Environment.CurrentDirectory + "/Assets/demo-1.png");

            string value = ScenariosCombobox.SelectedValue.ToString();
            walkthrough = imageService.BuildWalkthrough(value, bitmap);
        }

        private void StartScenario()
        {
            PixelGrid.Init(bitmap.GetSize(), walkthrough,  soundService);
            
            if (walkthrough.Name != IWalkthrough.Simple)
                return;
            
            var simple = (SimpleWalkthrough) walkthrough;
            var map = simple.ColorMap;
            var colors = map.Select(x => x.Color);

            PreparePalette(colors.ToList());
            
            // cellsToColor = PrepareForColoring(colorMap);
            this.Log($"Prepared {colors.Count()} cells.");
        }

        private void PreparePalette(IReadOnlyList<ColorData> colors)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                var color = colors[i];

                var paletteColor = new PaletteView
                {
                    Color = color
                };
                
                paletteColor.Activated += PaletteColorOnActivated;
                
                Grid.SetColumn(paletteColor, i);

                Palette.Children.Add(paletteColor);
                Palette.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void PaletteColorOnActivated(ColorData color)
        {
            cellsToColor = PixelGrid.HighlightPixelsByColor(color);
        }
    }
}
