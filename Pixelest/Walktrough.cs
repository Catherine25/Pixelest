using System.Collections.Generic;
using System.Drawing;

namespace Pixelest
{
    public class Walktrough
    {
        /// <summary>
        /// <see cref="Steps"/>, ordered by lightness.
        /// </summary>
        public List<Step> Steps { get; set; }
    }

    public class Step
    {
        /// <summary>
        /// Describes max lightness of the current step.
        /// </summary>
        public int CurrentMaxLightness { get; set; }

        /// <summary>
        /// <see cref="PixelsToDraw"/> has a collection of hues of the colors that have such max lightness.
        /// </summary>
        public List<Palette> PixelsToDraw { get; set; }
    }

    public class Palette
    {
        public int Hue { get; set; }
        public bool[][] Map { get; set; }
    }
}