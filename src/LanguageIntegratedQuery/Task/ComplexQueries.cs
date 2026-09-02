using LanguageIntegratedQuery.Models;

namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Demonstrates complex queries - joining and grouping
    /// </summary>
    internal class ComplexQueries
    {
        /// <summary>
        /// Task 2 - Groups products by category and joins products with suppliers
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of suppliers</param>
        public void ExecuteComplexQueries(List<Product> products, List<Supplier> suppliers)
        {
            Console.Clear();
            Console.WriteLine(@"========================================
TASK 2 - COMPLEX LINQ QUERIES
========================================");

            Console.WriteLine("\nGrouping products by category");

            var groupedProducts = products
                .GroupBy(product => product.Category)
                .Select(group => new
                {
                    Category = group.Key,
                    Count = group.Count(),
                    MostExpensiveProduct = group.MaxBy(product => product.Price),
                });

            Console.WriteLine("\nProducts By Category:");

            foreach (var group in groupedProducts)
            {
                Console.WriteLine(
                    $"{group.Category} - Count: {group.Count} - " +
                    $"Most Expensive: {group.MostExpensiveProduct?.Name} " +
                    $"(${group.MostExpensiveProduct?.Price})");
            }

            Console.WriteLine("\nJoining products with suppliers");

            var joinedProducts = products
                .Join(
                    suppliers,
                    product => product.ProductId,
                    supplier => supplier.ProductId,
                    (product, supplier) => new
                    {
                        product.Name,
                        product.Price,
                        supplier.SupplierName,
                    });

            Console.WriteLine("\nProducts And Suppliers:");

            foreach (var item in joinedProducts)
            {
                Console.WriteLine(
                    $"{item.Name} - ${item.Price} - Supplier: {item.SupplierName}");
            }
        }
    }
}