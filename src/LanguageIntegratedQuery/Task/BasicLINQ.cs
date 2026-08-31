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
        /// <param name="products">List of products </param>
        public void Task1(List<Product> products)
        {
            var filteredProducts = products
                .Where(product => product.Category == "Electronics" && product.Price > 500)
                .Select(product => new
                {
                    product.Name,
                    product.Price,
                });

            var sortedProducts = filteredProducts
                .OrderByDescending(product => product.Price)
                .ToList();

            Console.WriteLine("\nProducts:");

            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"{product.Name} - ${product.Price}");
            }

            decimal averagePrice = sortedProducts
                .Average(product => product.Price);

            Console.WriteLine($"\nAverage Price: ${averagePrice:N2}");
        }
    }
}
