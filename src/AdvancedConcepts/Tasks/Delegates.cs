using AdvancedConcepts.Models;

namespace AdvancedConcepts.Tasks
{
    /// <summary>
    /// Demonstrates the usage of custom delegates to implement flexible sorting strategies for a list of products.
    /// </summary>
    internal class Delegates
    {
        /// <summary>
        /// Defines a delegate structure for comparing two product objects.
        /// </summary>
        /// <param name="firstProduct">The first product to compare.</param>
        /// <param name="secondProduct">The second product to compare.</param>
        /// <returns>A signed integer indicating the relative values of the products in the sort order.</returns>
        public delegate int SortDelegate(Product firstProduct, Product secondProduct);

        /// <summary>
        /// Executes the delegate demonstration by initializing a product list and sorting it using different criteria.
        /// </summary>
        public void ExecuteDelegates()
        {
            List<Product> products = new List<Product>
            {
                new Product("Laptop", "Electronics", 1200.50),
                new Product("washing machine", "Appliances", 89.99),
                new Product("mobile", "Electronics", 799.00),
                new Product("Toaster", "Appliances", 45.50),
                new Product("Table", "Furniture", 150.00),
            };
            SortDelegate nameSorter = this.SortByName;
            SortDelegate categorySorter = this.SortByCategory;
            SortDelegate priceSorter = this.SortByPrice;

            Console.WriteLine("SORT BY NAME");
            this.SortAndDisplay(nameSorter, new List<Product>(products));

            Console.WriteLine("SORT BY CATEGORY");
            this.SortAndDisplay(categorySorter, new List<Product>(products));

            Console.WriteLine("SORT BY PRICE");
            this.SortAndDisplay(priceSorter, new List<Product>(products));
        }

        /// <summary>
        /// Compares two products by their name alphabetically, ignoring case differences.
        /// </summary>
        /// <param name="firstProduct">The first product to compare.</param>
        /// <param name="secondProduct">The second product to compare.</param>
        /// <returns>Less than zero if first is less than second; zero if equal; greater than zero if first is greater.</returns>
        public int SortByName(Product firstProduct, Product secondProduct)
        {
            return string.Compare(firstProduct.Name, secondProduct.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compares two products by their category alphabetically, ignoring case differences.
        /// </summary>
        /// <param name="firstProduct">The first product to compare.</param>
        /// <param name="secondProduct">The second product to compare.</param>
        /// <returns>Less than zero if first is less than second; zero if equal; greater than zero if first is greater.</returns>
        public int SortByCategory(Product firstProduct, Product secondProduct)
        {
            return string.Compare(firstProduct.Category, secondProduct.Category, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Compares two products by their numerical price value.
        /// </summary>
        /// <param name="firstProduct">The first product to compare.</param>
        /// <param name="secondProduct">The second product to compare.</param>
        /// <returns>Less than zero if first price is lower; zero if equal; greater than zero if first price is higher.</returns>
        public int SortByPrice(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Price.CompareTo(secondProduct.Price);
        }

        /// <summary>
        /// Sorts the provided product list using the specified evaluation delegate and prints the results to the console.
        /// </summary>
        /// <param name="sorter">The sorting delegate strategy to apply.</param>
        /// <param name="productList">The collection of products to sort and print.</param>
        public void SortAndDisplay(SortDelegate sorter, List<Product> productList)
        {
            productList.Sort((firstProduct, secondProduct) => sorter(firstProduct, secondProduct));

            foreach (var product in productList)
            {
                Console.WriteLine(product);
            }
        }
    }
}
