using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    /// <summary>
    /// Stack and heap memory allocations
    /// </summary>
    internal class StackAndHeap
    {
        /// <summary>
        /// Executing the memory allocation in stack and heap
        /// </summary>
        public void ExecuteStackAndHeap()
        {
            Console.WriteLine(@"===========================================
Stack And Heap
===========================================");
            Console.WriteLine("Creating Large Array");
            this.CreateArray();
            Console.WriteLine("Performing Value Calculations");
            this.PerformCalculations();
        }

        /// <summary>
        /// This creates a large array
        /// </summary>
        public void CreateArray()
        {
            int[] numbers = new int[10_000_000];
            for (int i = 1; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            Console.WriteLine($"First number: {numbers[0]}");
            Console.WriteLine($"Last number: {numbers[^1]}");
        }

        /// <summary>
        /// Performs value calculations
        /// </summary>
        public void PerformCalculations()
        {
            int value1 = 1;
            int value2 = 2;
            int value3 = 3;
            int value4 = 4;
            int value5 = 5;
            int value6 = 6;
            int value7 = 7;
            int value8 = 8;
            int value9 = 9;
            int value10 = 10;

            int result = value1 + value2 + value3 + value4 + value5 + value6 + value7 + value8 + value9 + value10;

            Console.WriteLine($"The result of the values is {result}");
        }
    }
}
