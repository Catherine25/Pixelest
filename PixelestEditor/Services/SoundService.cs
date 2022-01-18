using System.Media;

namespace PixelestEditor.Services
{
    public class SoundService
    {
        private readonly SoundPlayer player;

        public SoundService(string path)
        {
            player = new SoundPlayer(path);
            player.Load();
        }
        
        public void Play() => player.Play();
    }
}