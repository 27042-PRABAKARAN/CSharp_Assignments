using LanguageIntegratedQuery.Models;

namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Demonstrates basic LINQ operations
    /// </summary>
    internal class BasicLINQ
    {
        /// <summary>
        /// Filters and calculates the average using LINQ
        /// </summary>
        /// <param name="products">List of products</param>
        public void ExecuteFiltering(List<Product> products)
        {
            Console.Clear();
            Console.WriteLine(@"========================================
TASK 1 - BASIC LINQ OPERATIONS
========================================");

            Console.WriteLine("\nFiltering products...");
            Console.WriteLine("Condition: Category = Electronics AND Price > $500");

            var filteredProducts = products
                .Where(product => product.Category == "Electronics" && product.Price > 500)
                .Select(product => new
                {
                    product.Name,
                    product.Price,
                });

            Console.WriteLine("Filtering completed.");
            Console.WriteLine("\nSorting filtered products...");
            Console.WriteLine("Order Price descending");

            var sortedProducts = filteredProducts
                .OrderByDescending(product => product.Price)
                .ToList();

            Console.WriteLine("\nFiltered and Sorted Products:");

            if (sortedProducts.Count == 0)
            {
                Console.WriteLine("No products matched.");
                return;
            }

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"{product.Name} - ${product.Price:N2}");
            }

            Console.WriteLine("\nCalculating average price");

            decimal averagePrice = sortedProducts.Average(product => product.Price);

            Console.WriteLine($"Average Price: ${averagePrice}");
        }
    }
}