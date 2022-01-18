using SkiaSharp;

namespace PixelestEditor.Model.Walktroughs
{
    public interface IWalkthrough
    {
        public const string Simple = "Simple";
        public const string Acrylic = "Acrylic";

        public string Name { get; }
        
        public void Build(SKBitmap bitmap);
    }
}