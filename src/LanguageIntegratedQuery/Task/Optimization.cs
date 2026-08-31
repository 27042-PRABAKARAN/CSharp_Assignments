using System.Diagnostics;
using LanguageIntegratedQuery.Models;

namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Demonstrates performance optimization using LINQ
    /// </summary>
    internal class Optimization
    {
        /// <summary>
        /// FIltering and Ordering using LINQ queries
        /// </summary>
        /// <param name="products"> List of products </param>
        public void Task4(List<Product> products)
        {
            Stopwatch watch = new Stopwatch();
            Console.WriteLine(" Selecting the Books category and Sorting it in normal way : ");
            watch.Start();
            var queriedProducts = products.OrderBy(product => product.Price).Where(product => product.Category == "Books").ToList();
            watch.Stop();
            Console.WriteLine("\nProducts:");

            foreach (var product in queriedProducts)
            {
                Console.WriteLine($"{product.Name}");
            }

            Console.WriteLine($"Time Taken : {watch.ElapsedMilliseconds} ms");

            Console.WriteLine(" Selecting the Books category and Sorting it in optimized way : ");
            watch.Restart();
            var filteredProducts = products.Where(product => product.Category == "Books").OrderBy(product => product.Price).ToList();
            watch.Stop();
            Console.WriteLine("\nProducts:");

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.Name}");
            }

            Console.WriteLine($"Time Taken : {watch.ElapsedMilliseconds} ms");
        }
    }
}
