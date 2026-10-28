namespace MultiThreading.Tasks
{
    /// <summary>
    /// Manages multi-threaded calculations using raw Thread instances.
    /// </summary>
    public class MultiThread
    {
        private int _sumResult = 0;
        private int _maxResult = 0;

        /// <summary>
        /// Executes the concurrent sum and maximum calculations on different threads.
        /// </summary>
        public void Execute()
        {
            int[] numbers = { 15, 22, 8, 43, 5, 91, 14, 62 };

            Console.WriteLine("Main thread: Creating and starting separate worker threads...\n");
            Thread sumThread = new Thread(() => this.CalculateSum(numbers));
            Thread maxThread = new Thread(() => this.FindMax(numbers));
            sumThread.Start();
            maxThread.Start();
            sumThread.Join();
            maxThread.Join();
            Console.WriteLine("\nMain thread: All threads completed. Combining results...");
            Console.WriteLine("==================================================");
            Console.WriteLine($"Sum of array elements:        {this._sumResult}");
            Console.WriteLine($"Maximum value in array:       {this._maxResult}");
            Console.WriteLine($"Combined value (Sum + Max):    {this._sumResult + this._maxResult}");
            Console.WriteLine("==================================================");
        }

        /// <summary>
        /// Thread Operation 1: Calculates the sum of all integers in the array.
        /// </summary>
        private void CalculateSum(int[] data)
        {
            Console.WriteLine($"[Thread {Environment.CurrentManagedThreadId}] Calculating sum...");
            int total = 0;
            foreach (int num in data)
            {
                total += num;
            }

            this._sumResult = total;
        }

        /// <summary>
        /// Thread Operation 2: Finds the highest integer value inside the array.
        /// </summary>
        private void FindMax(int[] data)
        {
            Console.WriteLine($"[Thread {Environment.CurrentManagedThreadId}] Finding max value...");
            int highest = data[0];
            foreach (int num in data)
            {
                if (num > highest)
                {
                    highest = num;
                }
            }

            this._maxResult = highest;
        }
    }
}
