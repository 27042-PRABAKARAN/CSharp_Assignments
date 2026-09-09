namespace MemoryHandler
{
    /// <summary>
    /// This allocates memory until we ge memory out bound exception
    /// </summary>
    internal class ExplodeMemory
    {
        private List<int[]> _memory = new List<int[]>();

        /// <summary>
        /// memory gets added until we get memory out of bound exception
        /// </summary>
        public void AddMemory()
        {
            while (true)
            {
                Console.WriteLine("Memory usage level is rising and visible in diagnostic tool for memory check");
                this._memory.Add(new int[10000]);
                Thread.Sleep(100);
            }
        }
    }
}
