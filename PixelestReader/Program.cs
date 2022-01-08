using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Pixelest.Model;
using Pixelest.Builder;

namespace Pixelest
{
    class Program
    {        
        static void Main(string[] args)
        {
            ImageInfo imageInfo = new();
            imageInfo.Name = "demo-2.png";
            imageInfo.SourcePath = $@"C:\Users\Xiaomi\Pictures\demo-sprites\{imageInfo.Name}";
            imageInfo.DestinationPath = imageInfo.SourcePath.Replace(".png", ".txt");
            imageInfo.Bitmap = new MyBitmap(imageInfo.SourcePath);
            imageInfo.Scenarios = new List<ColoringScenario> {
                new ColoringScenario {
                    Name = "Simple",
                    BoolMaps = CreateBoolMapsForSimpleMode(imageInfo)
                }
            };

            string jsonString = JsonConvert.SerializeObject(imageInfo);

            using (FileStream stream = File.Create(imageInfo.DestinationPath))
                AddText(stream, jsonString);
        }

        private static List<ColorBoolMap> CreateBoolMapsForSimpleMode(ImageInfo imageInfo)
        {
            var builder = new BoolMapsBuilder();
            // var lb = builder.BuildLightnessBoolmaps(imageInfo.Bitmap);
            // lb.ForEach(b=>Console.WriteLine(b));
            var cb = builder.BuildColorBoolmaps(imageInfo.Bitmap);
            cb.ForEach(b=>Console.WriteLine(b));
            cb.ForEach(b=>Console.WriteLine(b.Color));
            // cb = BoolMapsBuilder.CombineBoolmaps(cb, lb);
            
            // cb.ForEach(b=>Console.WriteLine(b));
            return cb;
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
