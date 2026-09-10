namespace MemoryHandler
{
    /// <summary>
    /// The main Entry point
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            ExplodeMemory explodeMemory = new ExplodeMemory();
            MemoryManager memoryManager = new MemoryManager();
            MemoryHandler memoryHandler = new MemoryHandler(explodeMemory, memoryManager);
            memoryHandler.ExecuteMemoryOperations();
        }
    }
}