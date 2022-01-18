using System;
using Pixelest.Extension;
using PixelestEditor.Model.Walktroughs;
using SkiaSharp;

namespace PixelestEditor.Services
{
    public class ImageService
    {
        public SKBitmap LoadBitmap(string path) => new SKBitmap().FromFile(path);

        public IWalkthrough BuildWalkthrough(string walkthroughName, SKBitmap bitmap)
        {
            IWalkthrough walkthrough;
                
            if (walkthroughName == IWalkthrough.Simple)
                walkthrough = new SimpleWalkthrough();
            else
                throw new NotImplementedException();
            
            walkthrough.Build(bitmap);
            
            return walkthrough;
        }
    }
}