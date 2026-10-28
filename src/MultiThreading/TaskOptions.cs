namespace MultiThreading
{
    /// <summary>
    /// Supported multi-threading and asynchronous code demonstration tasks.
    /// </summary>
    internal enum TaskOptions
    {
        /// <summary>
        /// Downloads web or mock content asynchronously.
        /// </summary>
        DownloadContent = 1,

        /// <summary>
        /// Demonstrates how exceptions behave and are caught inside an async Task.
        /// </summary>
        TaskException,

        /// <summary>
        /// Runs operations using traditional manual Thread creation.
        /// </summary>
        MultiThread,

        /// <summary>
        /// Uses Parallel.ForEach or Parallel.Invoke from the Task Parallel Library (TPL).
        /// </summary>
        TaskParallelLibrary,

        /// <summary>
        /// Chains multiple asynchronous steps sequentially using ContinueWith or await.
        /// </summary>
        ChainOperator,

        /// <summary>
        /// Simulates an intentional deadlock scenario to show how code freezes.
        /// </summary>
        DeadlockSimulator,

        /// <summary>
        /// Demonstrates the difference between using ConfigureAwait(true) and ConfigureAwait(false).
        /// </summary>
        AwaitConfigure,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
