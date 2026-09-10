namespace MemoryHandler
{
    /// <summary>
    /// Manages memory without hitting exception
    /// </summary>
    internal class MemoryManager
    {
        private readonly int _max;
        private List<int[]> _memory = new List<int[]>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryManager"/> class.
        /// </summary>
        /// <param name="maxData">Maximum Limit to be stored in the list.</param>
        public MemoryManager(int maxData)
        {
            this._max = maxData;
        }

        /// <summary>
        /// Adds on memory and adds it to a list.
        /// </summary>
        public void AddMemory()
        {
            while (this._memory.Count <= this._max)
            {
                this._memory.Add(new int[1000]);
                Console.WriteLine($"Current Memory Usage: {GC.GetAllocatedBytesForCurrentThread() / 1024 / 1024}Mb");
                Thread.Sleep(10);
            }
        }
    }
}
