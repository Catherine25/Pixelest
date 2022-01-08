using System.Collections.Generic;
using Pixelest.Json;

namespace Pixelest.Model
{
    public class ColoringScenarioData
    {
        public string Name { get; set; }
        public Queue<ColorBoolMapData> BoolMaps { get; set; }
    }
}