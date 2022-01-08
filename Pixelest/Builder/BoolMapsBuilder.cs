using System;
using System.Collections.Generic;
using System.Drawing;
using Pixelest.Extension;
using Pixelest.Model;
using SkiaSharp;

namespace Pixelest.Builder
{
    public class BoolMapsBuilder
    {
        // TODO refactor
        public List<LightnessBoolMap> BuildLightnessBoolmaps(MyBitmap bitmap)
        {
            List<LightnessBoolMap> boolMaps = new();

            List<int> lightnesses = bitmap.GetParameterValues(ColorConstants.Parameter.Lightness);

            foreach (var lightness in lightnesses)
            {
                LightnessBoolMap bm = new(bitmap, lightness);

                if(!bm.IsEmpty)
                    boolMaps.Add(bm);
            }
            
            Console.WriteLine($"{boolMaps.Count} boolMaps have been built");
            return boolMaps;
        }

        public List<ColorBoolMap> BuildColorBoolmaps(MyBitmap bitmap)
        {
            List<ColorBoolMap> boolMaps = new();

            List<Color> colors = bitmap.GetAllColors();
            foreach (var color in colors)
            {
                ColorBoolMap bm = new(bitmap, color);

                if(!bm.IsEmpty)
                    boolMaps.Add(bm);
            }
            
            Console.WriteLine($"{boolMaps.Count} boolMaps have been built");
            return boolMaps;
        }

        public static List<ColorBoolMap> CombineBoolmaps(List<ColorBoolMap> colorMap, List<LightnessBoolMap> lightnessMap)
        {
            List<ColorBoolMap> colorMaps = new List<ColorBoolMap>();

            for (int i = 0; i < lightnessMap.Count; i++)
            for (int j = 0; j < colorMap.Count; j++)
            {
                LightnessBoolMap lMap = lightnessMap[i];
                ColorBoolMap cMap = colorMap[j];

                cMap.Values = BoolMap.And(cMap, lMap, out bool isEmpty);
                
                if(!isEmpty)
                    colorMaps.Add(cMap);

            }

            Console.WriteLine($"{colorMaps.Count} boolMaps have been combined");

            colorMaps.Sort((x,y) => (int)y.Color.GetBrightness() - (int)x.Color.GetBrightness());
            return colorMaps;
        }
    }
}