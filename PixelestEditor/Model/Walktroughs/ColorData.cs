using System;
using DColor = System.Drawing.Color;
using WColor = System.Windows.Media.Color;
using SkiaSharp;

namespace PixelestEditor.Model.Walktroughs
{
    public class ColorData
    {
        public const int MaxColorValue = 255;
        
        public ColorData(string hex)
        {
            hex = hex.Replace("#", "");
            
            if (hex.Length > 6)
                hex = hex.Substring(2);
            
            SetRGB(Convert.ToByte(hex[..2], 16),
                Convert.ToByte(hex.Substring(2, 2), 16),
                Convert.ToByte(hex.Substring(4, 2), 16));
        }

        public DColor DColor { get; private set; }
        public WColor WColor { get; private set; }
        public SKColor SkColor { get; private set; }

        public byte R { get; private set; }
        public byte G { get; private set; }
        public byte B { get; private set; }

        public double H { get; private set; }
        public double L { get; private set; }
        public double S { get; private set; }

        public const double StepH = 10;
        public const double StepL = 0.1;
        public const double StepS = 0.1;

        public void SetRGB(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;

            RgbToHls(r, g, b, out double h, out double l, out double s);

            H = h;
            L = l;
            S = s;

            DColor = DColor.FromArgb(r, g, b);
            SkColor = new SKColor(r, g, b);
            WColor = WColor.FromRgb(r, g, b);
        }

        public void SetHsl(double h, double l, double s)
        {
            H = h;
            L = l;
            S = s;

            HlsToRgb(h, l, s, out int r, out int g, out int b);

            R = (byte)r;
            G = (byte)g;
            B = (byte)b;

            DColor = DColor.FromArgb(R, G, B);
            SkColor = new SKColor(R, G, B);
            WColor = WColor.FromRgb(R, G, B);
        }

        public void MakeLighter(bool lighter)
        {
            if (lighter)
            {
                //yellower => 60
                double h = MoveToNumber(H, 60, StepH);
                double l = MoveToNumber(L, 1, StepL);
                double s = MoveToNumber(S, 0, StepS);

                SetHsl(h, l, s);
            }
            else
            {
                //bluer => 240
                double h = MoveToNumber(H, 240, StepH);
                double l = MoveToNumber(L, 0, StepL);
                double s = MoveToNumber(S, 1, StepS);

                SetHsl(h, l, s);
            }
        }

        public override string ToString() => $"\n{(int)R} {(int)G} {(int)B}\n\n{(int)H} {(int)S} {(int)L}";

        private double MoveToNumber(double value, double needed, double step)
        {
            // copy value
            if (value == needed)
                return needed;
            else if(value > needed)
            {
                value -= step;
                if (value < needed)
                    return needed;
            }
            else
            {
                value += step;
                if (value > needed)
                    return needed;
            }

            return value;
        }

        public void RgbToHls(int r, int g, int b, out double h, out double l, out double s)
        {
            // Convert RGB to a 0.0 to 1.0 range.
            double doubleR = r / 255.0;
            double doubleG = g / 255.0;
            double doubleB = b / 255.0;

            // Get the maximum and minimum RGB components.
            double max = doubleR;
            if (max < doubleG) max = doubleG;
            if (max < doubleB) max = doubleB;

            double min = doubleR;
            if (min > doubleG) min = doubleG;
            if (min > doubleB) min = doubleB;

            double diff = max - min;
            l = (max + min) / 2;
            if (Math.Abs(diff) < 0.00001)
            {
                s = 0;
                h = 0;  // H is really undefined.
            }
            else
            {
                if (l <= 0.5) s = diff / (max + min);
                else s = diff / (2 - max - min);

                double rDist = (max - doubleR) / diff;
                double gDist = (max - doubleG) / diff;
                double bDist = (max - doubleB) / diff;

                if (doubleR == max)
                    h = bDist - gDist;
                else if (doubleG == max)
                    h = 2 + rDist - bDist;
                else
                    h = 4 + gDist - rDist;

                h *= 60;
                if (h < 0)
                    h += 360;
            }
        }

        // Convert an HLS value into an RGB value.
        public static void HlsToRgb(double h, double l, double s, out int r, out int g, out int b)
        {
            double p2 = l <= 0.5
                ? l * (1 + s)
                : l + s - l * s;

            double p1 = 2 * l - p2;
            double doubleR, doubleG, doubleB;
            if (s == 0)
            {
                doubleR = l;
                doubleG = l;
                doubleB = l;
            }
            else
            {
                doubleR = QqhToRgb(p1, p2, h + 120);
                doubleG = QqhToRgb(p1, p2, h);
                doubleB = QqhToRgb(p1, p2, h - 120);
            }

            // Convert RGB to the 0 to 255 range.
            r = (int)(doubleR * 255.0);
            g = (int)(doubleG * 255.0);
            b = (int)(doubleB * 255.0);
        }

        private static double QqhToRgb(double q1, double q2, double hue)
        {
            if (hue > 360)
                hue -= 360;
            else if (hue < 0)
                hue += 360;

            if (hue < 60)
                return q1 + (q2 - q1) * hue / 60;
            if (hue < 180)
                return q2;
            if (hue < 240)
                return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }
    }
}
