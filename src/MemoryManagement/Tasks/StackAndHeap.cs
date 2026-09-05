using System.Runtime;

namespace MemoryManagement.Tasks
{
    /// <summary>
    /// Stack and heap memory allocations
    /// </summary>
    internal class StackAndHeap
    {
        /// <summary>
        /// Executes the Stack memory allocation and heap memory allocation
        /// </summary>
        public void ExecuteStackAndHeap()
        {
            Console.WriteLine(@"==================================================
  Managing memory on stack and heap
==================================================");

            Console.WriteLine("Heap Accumulation(List of Arrays)");
            this.CreateHeapMemory();
            Console.WriteLine("\nStack Allocation(Value Types Calculation)");
            this.CalculateValueTypes();
            UserInput.WaitAndClear();
        }

        /// <summary>
        /// Creates a list of large arrays
        /// </summary>
        public void CreateHeapMemory()
        {
            List<int[]> heapList = new List<int[]>();

            for (int i = 1; i <= 10; i++)
            {
                int[] array = new int[5_000_000];
                heapList.Add(array);
                Console.WriteLine($"Added Array {i} to the List.");
                Thread.Sleep(1000);
            }

            Console.WriteLine("Heap accumulation finished");
        }

        /// <summary>
        /// increases stack memory
        /// </summary>
        public void CalculateValueTypes()
        {
            int[] integerArray = { 100, 200, 300, 400, 500 };
            double[] doubleArray = { 10.50, 20.75, 30.12, 40.88, 50.34 };
            decimal[] decimalArray = { 1000.50m, 2000.75m, 3000.25m };
            double result = integerArray.Sum() * doubleArray.Sum();
            decimal total = (decimal)result + decimalArray.Sum();
            Console.WriteLine($"Final Value Type Output: {total}");
        }
    }
}