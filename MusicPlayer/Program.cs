namespace MusicPlayer
{
    /// <summary>
    /// Start point of application
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            MusicPlayer musicPlayer = new MusicPlayer();
            musicPlayer.Play();
        }
    }
}