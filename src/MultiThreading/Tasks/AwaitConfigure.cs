namespace MultiThreading.Tasks
{
    /// <summary>
    /// Indicates the use case of ConfigureAwait keyword.
    /// </summary>
    internal class AwaitConfigure
    {
        /// <summary>
        /// Performs asynchronous operation with ConfigureAwait as false.
        /// </summary>
        /// <returns>The task representing the asynchronous operation.</returns>
        public async Task Execute()
        {
            string header = $@"
=====================================
          Await Configure
=====================================";
            Console.WriteLine(header);
            Console.WriteLine($"Main method - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            int squaredValue = await this.AwaiterMethodAsync();
            Console.WriteLine($"Squared result: {squaredValue}");
        }

        private async Task<int> AwaiterMethodAsync()
        {
            Console.WriteLine($"Method B - Before Method A - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            int data = await this.AwaitConfigurerAsync();

            Console.WriteLine($"Method B - After Method A - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return data * 2;
        }

        private async Task<int> AwaitConfigurerAsync()
        {
            Console.WriteLine($"Method A - Before await  - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2000).ConfigureAwait(false);

            Console.WriteLine($"Method A - After await  - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return 1;
        }
    }
}
