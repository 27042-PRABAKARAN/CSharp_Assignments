using System.Diagnostics;

namespace MultiThreading.Tasks
{
    /// <summary>
    /// Implements an Example of Task parallel library
    /// </summary>
    internal class TaskParallelLibrary
    {
        /// <summary>
        /// Execution of parallel task
        /// </summary>
        public void Execute()
        {
            int[] numbers = Enumerable.Range(1, 10000).ToArray();
            int[] results = new int[numbers.Length];

            Console.WriteLine("Processing array using Parallel.ForEach\n");
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.ForEach(numbers, (number, state, index) =>
            {
                int square = number * number;
                results[index] = square;
                Console.WriteLine($"Number: {number} -> Square: {square} (Thread: {Environment.CurrentManagedThreadId})");
            });
            stopwatch.Stop();
            Console.WriteLine($@"==========================================
Processing completed successfully.
Time elapsed: {stopwatch.ElapsedMilliseconds} ms
==========================================");
            Console.ReadKey();
        }
    }
}
