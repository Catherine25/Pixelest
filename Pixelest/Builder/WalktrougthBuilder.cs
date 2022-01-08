using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Pixelest.Extension;
using SkiaSharp;
using static Pixelest.Extension.ColorConstants;

namespace Pixelest.Builder
{
    public static class WalktrougthBuilder
    {
        // todo
        // public static Walktrough Build(SKBitmap bitmap, Size size)
        // {
        //     var pixMap = GetPixMap(bitmap, size);
        //     var w = new Walktrough();

        //     List<int> availableLightnesses = pixMap.GetLightnesses();

        //     foreach (var lightness in availableLightnesses)
        //     {
        //         w.Steps.Add(CreateNewStep(pixMap, lightness));
                
        //     }
            

        //     // var hues = pixMap.GetHues();

        //     // pixMap.GetLightestColorCoordinate(pixMap.Map[0][0].Lightness);

        //     // pixMap[0][0].Lightness

        //     // w.Steps = new List<Step>();

        //     // Step step1 = new Step();
        //     // step1.Palettes = new HashSet<Palette>();

        //     // Palette p = new Palette();
        //     // p.Color = ;
        //     // step1.Palettes.Add(p);
        // }

        // private static Step CreateNewStep(PixMap pixMap, Size size, int lightness)
        // {
        //     Step step = new Step();
        //     step.CurrentMaxLightness = lightness;
        //     step.Palettes;
        //     Boolmap b = new Boolmap(pixMap, size, , lightness);
        //     throw new NotImplementedException();
        // }

        // static IOrderedEnumerable<HuesByLightness> OrderByMaxLightness(List<HuesByLightness> huesByLightnesses, bool lightestFirst = false) =>
        // lightestFirst ? huesByLightnesses.OrderByDescending(h => h.Lightness) : huesByLightnesses.OrderBy(h => h.Lightness);

        static PixMap GetPixMap(SkiaSharp.SKBitmap bitmap, Size size)
        {
            PixMap pixMap = new PixMap
            {
                Map = new HueLightness[size.Width][]
            };

            for (int i = 0; i < size.Width; i++)
            {
                pixMap.Map[i] = new HueLightness[size.Height];
                for (int j = 0; j < size.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i,j);
                    pixMap.Map[i][j] = new HueLightness
                    {
                        Hue = pixel.Get(Parameter.Hue),
                        Lightness = pixel.Get(Parameter.Lightness)
                    };
                }
            }

            return pixMap;
        }
    }

    public class HueLightness
    {
        public int Hue { get; set; }
        public int Lightness { get; set; }
    }

    public class PixMap
    {
        public HueLightness[][] Map { get; set; }
        public Size Size { get; set; }

        public int GetLightestColorCoordinate(int? startLightness = 0)
        {
            int lightestValue = startLightness ?? Map[0][0].Lightness;

            for (int i = 0; i < Size.Width; i++)
            for (int j = 0; j < Size.Height; j++)
                lightestValue = Math.Max(lightestValue, Map[i][j].Lightness);

            return lightestValue;
        }

        public List<int> GetHues()
        {
            List<int> hues = new List<int>();

            for (int i = 0; i < Size.Width; i++)
            for (int j = 0; j < Size.Height; j++)
                hues.Add(this.Map[i][j].Hue);

            return hues.OrderBy(h=>h).ToList();
        }

        public List<int> GetLightnesses()
        {
            List<int> lightnesses = new List<int>();

            for (int i = 0; i < Size.Width; i++)
            for (int j = 0; j < Size.Height; j++)
                lightnesses.Add(this.Map[i][j].Lightness);

            return lightnesses.OrderBy(l=>l).ToList();
        }
    }
}