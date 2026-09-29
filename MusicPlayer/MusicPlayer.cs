namespace MusicPlayer
{
    /// <summary>
    /// Music player which executes sequence of notes
    /// </summary>
    internal class MusicPlayer
    {
        private const int Duration = 1000;
        private readonly Dictionary<string, int> _frequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            { "C",  261 }, { "C#", 277 }, { "D",  293 }, { "D#", 311 },
            { "E",  329 }, { "F",  349 }, { "F#", 369 }, { "G",  392 },
            { "G#", 415 }, { "A",  440 }, { "A#", 466 }, { "B",  493 },
        };

        /// <summary>
        /// Plays the given Sequence
        /// </summary>
        public void Play()
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine("Available Notes: ");
                foreach (string key in this._frequencies.Keys)
                {
                    Console.Write(key + ",");
                }

                Console.WriteLine("Enter Sequence separated by comma example C,C#,D,D#");
                string? sequence = Console.ReadLine();
                if (sequence == null)
                {
                    Console.WriteLine("Enter valid Sequence");
                    continue;
                }

                string[] scaleSequence = sequence.Split(',');
                foreach (string scale in scaleSequence)
                {
                    bool isAvailable = this._frequencies.TryGetValue(scale, out var frequencies);
                    if (isAvailable)
                    {
                        Console.Beep(frequencies, Duration);
                    }
                    else
                    {
                        Console.WriteLine(scale + " is not available, skipping it");
                    }
                }

                Console.WriteLine("Enter E to exit and any other key to do again");
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.E)
                {
                    state = false;
                }

                Console.Clear();
            }
        }
    }
}
