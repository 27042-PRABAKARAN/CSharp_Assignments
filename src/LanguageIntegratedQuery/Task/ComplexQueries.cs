using LanguageIntegratedQuery.Models;

namespace LanguageIntegratedQuery.Task
{
    internal class ComplexQueries
    {
        /// <summary>
        /// Task 2
        /// </summary>
        /// <param name="products"> List of products </param>
        /// <param name="suppliers"> List of Suppliers</param>
        public void Task2(List<Product> products, List<Supplier> suppliers)
        {
            var groupedProducts = products
                .GroupBy(product => product.Category)
                .Select(product => new
                {
                    Category = product.Key,
                    Count = product.Count(),
                    MostExpensiveProduct = product.OrderByDescending(record => record.Price).First(),
                });

            Console.WriteLine("\nProducts By Category:");

            foreach (var group in groupedProducts)
            {
                Console.WriteLine(
                    $"{group.Category} - Count: {group.Count} - " +
                    $"Most Expensive: {group.MostExpensiveProduct.Name} " +
                    $"(${group.MostExpensiveProduct.Price})");
            }

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
                Console.WriteLine($"{item.Name} - ${item.Price} - Supplier: {item.SupplierName}");
            }
        }
    }
}
