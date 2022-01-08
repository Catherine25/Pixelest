using System;
using System.Drawing;

namespace Pixelest
{
    public static class Settings
    {
        public const int MaxResolution = 64;

        public static Size GetMaxAllowedSize(Size size)
        {
            int width = Math.Min(size.Width, MaxResolution);
            int height = Math.Min(size.Height, MaxResolution);

            return new Size(width, height);
        }
    }
}