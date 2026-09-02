using LanguageIntegratedQuery.Models;
using LanguageIntegratedQuery.Models.Enums;

namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Query Builder fluent API
    /// </summary>
    internal class TestBuilder
    {
        /// <summary>
        /// Filtering, sorting and joining using Query Builder
        /// </summary>
        /// <param name="products">List of products</param>
        /// <param name="suppliers">List of suppliers</param>
        public void ExecuteQueryBuilder(List<Product> products, List<Supplier> suppliers)
        {
            Console.Clear();
            Console.WriteLine(@"========================================
TASK 5 - QUERY BUILDER
========================================");

            Console.WriteLine("\nBuilding product query");
            Console.WriteLine("Applying category filter: Electronics");
            Console.WriteLine("Applying price filter: >= $500");
            Console.WriteLine("Sorting by price and then by name");

            var filteredProducts = new QueryBuilder<Product>(products)
                .Filter(p => p.Category == "Electronics")
                .Filter(p => p.Price >= 500)
                .SortBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Execute();

            Console.WriteLine("Query executed successfully.");

            Console.WriteLine("\nFiltered and Sorted Products:");

            foreach (var product in filteredProducts)
            {
                Console.WriteLine(
                    $"{product.Name} - {product.Category} - ${product.Price:N2}");
            }

            Console.WriteLine("\nBuilding product-supplier join query");
            Console.WriteLine("Joining products with suppliers using ProductId");

            var joinedProducts = new QueryBuilder<Product>(products)
                .Join(
                    suppliers,
                    p => p.ProductId,
                    s => s.ProductId,
                    (p, s) => new
                    {
                        p.Name,
                        p.Price,
                        s.SupplierName,
                    })
                .Execute();

            Console.WriteLine("Join query executed successfully.");

            Console.WriteLine("\nProducts with Suppliers:");

            foreach (var product in joinedProducts)
            {
                Console.WriteLine(
                    $"{product.Name} - {product.SupplierName} - ${product.Price:N2}");
            }
        }
    }
}
