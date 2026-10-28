namespace MultiThreading.Tasks
{
    /// <summary>
    /// Simulates deadlock in asynchronous application.
    /// </summary>
    internal class DeadlockSimulator
    {
        private readonly object _lockObject1 = new object();

        private readonly object _lockObject2 = new object();

        /// <summary>
        /// Performs deadlock and displays it to user.
        /// </summary>
        public void Execute()
        {
            string header = $@"
=====================================
            DeadLock
=====================================
[D]eadlock code output
[S]olved Deadlock code output

Enter choice: ";
            Console.Write(header);
            ConsoleKey userChoice = Console.ReadKey().Key;
            if (userChoice == ConsoleKey.D)
            {
                this.SimulateDeadLock();
            }
            else if (userChoice == ConsoleKey.S)
            {
                this.PerformWithoutDeadlock();
            }
            else
            {
                Console.WriteLine("Not a valid choice.");
            }
        }

        private void PerformWithoutDeadlock()
        {
            var result = this.SomeAsyncOperation().Result;
            Console.WriteLine($"\n{result}");
        }

        private void SimulateDeadLock()
        {
            var result = this.SomeAsyncOperation();
            Console.WriteLine($"\n{result}");
        }

        private async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}
