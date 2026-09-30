namespace MultiThreading.Tasks
{
    /// <summary>
    /// Demonstrates exception handling differences between async Task and async void.
    /// </summary>
    internal class TaskException
    {
        /// <summary>
        /// Executes the test calls and attempts to catch their exceptions.
        /// </summary>
        /// <returns>A task representing the operation.</returns>
        public async Task Execute()
        {
            Console.WriteLine("=====Starting Async Exception Testing====\n");

            try
            {
                Console.WriteLine("Calling TaskMethod...");
                await this.TaskMethod();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Caught exception from TaskMethod: '{ex.Message}'");
            }

            try
            {
                Console.WriteLine("Calling VoidMethod...");
                this.VoidMethod();
                await Task.Delay(500);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Caught exception from VoidMethod: '{ex.Message}'");
            }
        }

        /// <summary>
        /// Throws an exception that can be caught because it returns a Task.
        /// </summary>
        /// <returns>A task representing the operation.</returns>
        public async Task TaskMethod()
        {
            await Task.Yield();
            throw new System.InvalidOperationException("Something went wrong inside TaskMethod!");
        }

        /// <summary>
        /// Throws an exception that cannot be caught because it returns void.
        /// </summary>
        public async void VoidMethod()
        {
            await Task.Yield();
            throw new System.InvalidOperationException("Something went wrong inside VoidMethod!");
        }
    }
}
