namespace MemoryHandler
{
    /// <summary>
    /// Manages memory without hitting exception
    /// </summary>
    internal class MemoryManager
    {
        private const int _maxItems = 100;
        private readonly List<int[]> _memory = new ();

        /// <summary>
        /// Adds memory while maintaining a fixed maximum
        /// number of retained arrays.
        /// </summary>
        public void AddMemory()
        {
            while (true)
            {
                if (this._memory.Count >= _maxItems)
                {
                    this._memory.RemoveAt(0);
                }

                this._memory.Add(new int[100000]);

                Console.WriteLine(
                    $"Arrays retained: {this._memory.Count}");

                Thread.Sleep(5);
            }
        }
    }
}
