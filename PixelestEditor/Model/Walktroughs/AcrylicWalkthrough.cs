using System;
using System.Collections.Generic;
using SkiaSharp;

namespace PixelestEditor.Model.Walktroughs
{
    public class AcrylicWalkthrough : IWalkthrough
    {
        public string Name => IWalkthrough.Acrylic;
        
        /// <summary>
        /// <see cref="Steps"/>, ordered by lightness.
        /// </summary>
        public Queue<(int lightness, ColorMap map)> Steps { get; set; }

        public void Build(SKBitmap bitmap)
        {
            throw new NotImplementedException();
        }
    }
}