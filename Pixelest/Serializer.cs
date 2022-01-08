using System.IO;
using Newtonsoft.Json;

namespace Pixelest
{
    public static class Serializer
    {
        public static T DeserializeFromFile<T>(string path) =>
            JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
    }
}