namespace AdvancedConcepts.Tasks
{
    internal class Delegates
    {
        public delegate int SortDelegate(Product firstProduct,  Product secondProduct);

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
            SortDelegate nameSorter = SortByName;
            SortDelegate categorySorter = SortByCategory;
            SortDelegate priceSorter = SortByPrice;

            Console.WriteLine("SORT BY NAME");
            SortAndDisplay(nameSorter, new List<Product>(products));

            Console.WriteLine("SORT BY CATEGORY");
            SortAndDisplay(categorySorter, new List<Product>(products));

            Console.WriteLine("SORT BY PRICE");
            SortAndDisplay(priceSorter, new List<Product>(products));

        }

        public static int SortByName(Product firstProduct, Product secondProduct)
        {
            return string.Compare(firstProduct.Name, secondProduct.Name, StringComparison.OrdinalIgnoreCase);
        }

        public static int SortByCategory(Product firstProduct, Product secondProduct)
        {
            return string.Compare(firstProduct.Category, secondProduct.Category, StringComparison.OrdinalIgnoreCase);
        }

        public static int SortByPrice(Product firstProduct, Product secondProduct)
        {
            return firstProduct.Price.CompareTo(secondProduct.Price);
        }

        public static void SortAndDisplay(SortDelegate sorter, List<Product> productList)
        {
            productList.Sort((firstProduct, secondProduct) => sorter(firstProduct, secondProduct));

            foreach (var product in productList)
            {
                Console.WriteLine(product);
            }
        }
    }
}
