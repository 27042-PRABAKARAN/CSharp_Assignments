using System;
using System.Collections.Generic;

namespace Collections.Enumerable
{
    /// <summary>
    /// Demonstrates the usage of IEnumerable and IReadOnlyDictionary.
    /// </summary>
    internal class EnumerableDemo
    {
        /// <summary>
        /// Executes the demonstration of IEnumerable and IReadOnlyDictionary
        /// </summary>
        public void ExecuteIEnumerable()
        {
            List<int> listCollection = new List<int> { 10, 20, 30 };
            int[] arrayCollection = new int[] { 5, 15, 25 };
            Queue<int> queueCollection = new Queue<int>(new[] { 1, 2, 3 });

            Console.WriteLine($"Sum of List: {this.SumOfElements(listCollection)}");
            Console.WriteLine($"Sum of Array: {this.SumOfElements(arrayCollection)}");
            Console.WriteLine($"Sum of Queue: {this.SumOfElements(queueCollection)}");

            IReadOnlyDictionary<string, int> dictionary = this.GenerateDictionary();

            Console.WriteLine("Printing read-only dictionary:");
            this.PrintDictionary(dictionary);
        }

        /// <summary>
        /// Computes the sum of all integers inside any given collection.
        /// </summary>
        /// <param name="numbers">A collection of integers that can be iterated over.</param>
        /// <returns>The total sum of all integers in the collection.</returns>
        public int SumOfElements(IEnumerable<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        /// <summary>
        /// Creates a dictionary populated with initial key-value pairs.
        /// </summary>
        /// <returns>A dictionary exposed under a read-only interface wrapper.</returns>
        public IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> fruitBasket = new Dictionary<string, int>()
            {
                { "Apple", 5 },
                { "Banana", 2 },
                { "Orange", 8 },
            };

            return fruitBasket;
        }

        /// <summary>
        /// prints all key-value pairs from a read-only dictionary.
        /// </summary>
        /// <param name="dictionary">The read-only dictionary to display.</param>
        public void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}
