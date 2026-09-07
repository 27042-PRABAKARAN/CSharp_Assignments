namespace MemoryManagement.Models.Enums
{
    /// <summary>
    /// Options in Task
    /// </summary>
    internal enum TaskOptions
    {
        /// <summary>
        /// Value type and Reference Type
        /// </summary>
        ValueAndReferenceType = 1,

        /// <summary>
        /// Stack Memory and Heap Memory
        /// </summary>
        StackAndHeapMemory,

        /// <summary>
        /// Manual Garbage Collection
        /// </summary>
        GarbageCollection,

        /// <summary>
        /// Using Key Word
        /// </summary>
        UsingKeyWord,

        /// <summary>
        /// Exiting the application
        /// </summary>
        Exit,
    }
}
