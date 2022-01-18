using System.Diagnostics;
namespace PixelestEditor.Extensions
{
    public static class LogExtension
    {
        public static void Log<T>(this T classToLog, string message) => Debug.WriteLine("\t" + message, typeof(T).Name);
    }
}