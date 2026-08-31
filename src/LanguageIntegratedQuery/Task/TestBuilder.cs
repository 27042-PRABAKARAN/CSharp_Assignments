using LanguageIntegratedQuery.Models;

namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Query Builder fluent API
    /// </summary>
    internal class TestBuilder
    {
        /// <summary>
        /// Filtering Sorting and joining using Query Builder
        /// </summary>
        /// <param name="products"> List of products </param>
        /// <param name="suppliers"> List of Suppliers </param>
        public void Task5(List<Product> products, List<Supplier> suppliers)
        {
            var filteredProducts = new QueryBuilder<Product>(products)
                .Filter(p => p.Category == "Electronics")
                .Filter(p => p.Price >= 500)
                .SortBy(p => p.Price)
                .ThenBy(p => p.Name)
                .Execute();

            Console.WriteLine("Filtered and Sorted Products:");

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.Name} {product.Category} {product.Price} ");
            }

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

            Console.WriteLine("\nProducts with Suppliers:");

            foreach (var product in joinedProducts)
            {
                Console.WriteLine($"{product.Name} {product.SupplierName} {product.Price} ");
            }
        }
    }
}
