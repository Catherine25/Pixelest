using System.Collections.Generic;
using Pixelest.Builder;

namespace Pixelest.Model
{
    public class ColoringScenario
    {
        public string Name { get; set; }
        public List<ColorBoolMap> BoolMaps { get; set; }
    }
}