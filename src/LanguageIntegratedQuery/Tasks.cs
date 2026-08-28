using System.Diagnostics;
using LanguageIntegratedQuery.Models;

namespace LanguageIntegratedQuery
{
    /// <summary>
    /// Tasks Executions
    /// </summary>
    internal class Tasks
    {
        private List<Product> _products = new ();
        private List<Supplier> _suppliers = new ();
        private int[] _numbers = new[] { 10, 20, 30, 20, 40, 50, 10, 60 };

        /// <summary>
        /// Task Operations
        /// </summary>
        public void TaskOperations()
        {
            this.PopulateProducts();
            this.PopulateSuppliers();

            int? task = UserInput.ReadInt("Enter choice: ", 1, 5);

            switch (task)
            {
                case 1:
                    this.Task1();
                    break;

                case 2:
                    this.Task2();
                    break;

                case 3:
                    this.Task3();
                    break;

                case 4:
                    this.Task4();
                    break;

                case 5:
                    this.Task5();
                    break;

                default:
                    Console.WriteLine("Invalid task.");
                    break;
            }

            UserInput.WaitAndClear();
        }

        /// <summary>
        /// To populate the products
        /// </summary>
        public void PopulateProducts()
        {
            this._products.Add(new Product(Guid.NewGuid(), "Laptop", 1200, "Electronics"));
            this._products.Add(new Product(Guid.NewGuid(), "Laptop", 1200, "Electronics"));
            this._products.Add(new Product(Guid.NewGuid(), "Phone", 800, "Electronics"));
            this._products.Add(new Product(Guid.NewGuid(), "Headphones", 300, "Electronics"));
            this._products.Add(new Product(Guid.NewGuid(), "C# Book", 600, "Books"));
            this._products.Add(new Product(Guid.NewGuid(), "LINQ Book", 750, "Books"));
            this._products.Add(new Product(Guid.NewGuid(), "Keyboard", 150, "Electronics"));
            this._products.Add(new Product(Guid.NewGuid(), "Monitor", 900, "Electronics"));
        }

        /// <summary>
        /// To populate the suppliers
        /// </summary>
        public void PopulateSuppliers()
        {
            this._suppliers.Add(new Supplier(Guid.NewGuid(), "Tech Supplier", this._products[0].ProductId));
            this._suppliers.Add(new Supplier(Guid.NewGuid(), "Mobile Supplier", this._products[2].ProductId));
            this._suppliers.Add(new Supplier(Guid.NewGuid(), "Book Supplier", this._products[1].ProductId));
            this._suppliers.Add(new Supplier(Guid.NewGuid(), "Display Supplier", this._products[3].ProductId));
        }

        /// <summary>
        /// Task 1
        /// </summary>
        public void Task1()
        {
            var filteredProducts = this._products
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

        /// <summary>
        /// Task 2
        /// </summary>
        public void Task2()
        {
            var groupedProducts = this._products
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

            var joinedProducts = this._products
                .Join(
                    this._suppliers,
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

        /// <summary>
        /// Task 3
        /// </summary>
        public void Task3()
        {
            var secondHighest = this._numbers
                .Distinct()
                .OrderByDescending(product => product)
                .Skip(1)
                .FirstOrDefault();

            Console.WriteLine($"\nSecond Highest Number: {secondHighest}");

            int target = 70;

            var pairs = this._numbers
                .SelectMany(
                    (first, index) => this._numbers
                        .Skip(index + 1)
                        .Where(second => first + second == target)
                        .Select(second => new
                        {
                            First = Math.Min(first, second),
                            Second = Math.Max(first, second),
                        }))
                .Distinct()
                .ToList();

            Console.WriteLine($"\nPairs That Add Up To {target}:");

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.First} + {pair.Second} = {target}");
            }
        }

        /// <summary>
        /// Task 4
        /// </summary>
        public void Task4()
        {
            Stopwatch watch = new Stopwatch();
            Console.WriteLine(" Selecting the Books category and Sorting it in normal way : ");
            watch.Start();
            var queriedProducts = this._products.OrderBy(product => product.Price).Where(product => product.Category == "Books");
            watch.Stop();
            Console.WriteLine("\nProducts:");

            foreach (var product in queriedProducts)
            {
                Console.WriteLine($"{product.Name}");
            }

            Console.WriteLine($"Time Taken : {watch.ElapsedMilliseconds} ms");

            Console.WriteLine(" Selecting the Books category and Sorting it in optimized way : ");
            watch.Start();
            var filteredProducts = this._products.Where(product => product.Category == "Books").OrderBy(product => product.Price);
            watch.Stop();
            Console.WriteLine("\nProducts:");

            foreach (var product in filteredProducts)
            {
                Console.WriteLine($"{product.Name}");
            }

            Console.WriteLine($"Time Taken : {watch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Task 5
        /// </summary>
        public void Task5()
        {
            var filteredProducts = new QueryBuilder<Product>(this._products)
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

            var joinedProducts = new QueryBuilder<Product>(this._products)
                .Join(
                    this._suppliers,
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