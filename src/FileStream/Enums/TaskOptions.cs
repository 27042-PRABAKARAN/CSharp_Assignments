namespace FileHandling.Enums
{
    /// <summary>
    /// Options to choose the task
    /// </summary>
    internal enum TaskOptions
    {
        /// <summary>
        /// Processing File Data
        /// </summary>
        FileDataProcessor = 1,

        /// <summary>
        /// Asynchronous Processing of File Data
        /// </summary>
        AsyncFileDataProcessor,

        /// <summary>
        /// Basic File operations
        /// </summary>
        BasicFileOperations,

        /// <summary>
        /// Logger
        /// </summary>
        Logger,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
