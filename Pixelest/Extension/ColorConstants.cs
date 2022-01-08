namespace Pixelest.Extension
{
    public static class ColorConstants
    {
        public const int MaxHue = 360;
        public const int MaxLightness = 100;
        public const int MaxSaturation = 100;
        
        public enum Parameter
        {
            Alpha,
            Red,
            Green,
            Blue,
            Hue,
            Saturation,
            Lightness
        }
    }
}