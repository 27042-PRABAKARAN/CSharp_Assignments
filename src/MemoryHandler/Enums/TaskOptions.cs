namespace MemoryHandler.Enums
{
    /// <summary>
    /// Options to choose the task
    /// </summary>
    internal enum TaskOptions
    {
        /// <summary>
        /// Memory out of bound
        /// </summary>
        ExplodeMemory = 1,

        /// <summary>
        /// handles memory out of bound exception
        /// </summary>
        ManageMemory,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
