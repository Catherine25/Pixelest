using Pixelest.Model;
using System.Collections.Generic;

namespace Pixelest.Json
{
    public class ImageInfoData
    {
        public MyBitmapData Bitmap { get; set; }
        public string Name { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public List<ColoringScenarioData> Scenarios { get; set; }
    }
}