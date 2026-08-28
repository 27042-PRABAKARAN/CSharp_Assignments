using LanguageIntegratedQuery.Models;

namespace LanguageIntegratedQuery.Task
{
    internal class BasicLINQ
    {
        /// <summary>
        /// Task 1
        /// </summary>
        /// <param name="products"> List of products </param>
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

            double averagePrice = sortedProducts
                .Average(product => (double)product.Price);

            Console.WriteLine($"\nAverage Price: ${averagePrice:N2}");
        }
    }
}
