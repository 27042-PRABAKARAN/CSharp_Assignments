using LanguageIntegratedQuery.Models;
using LanguageIntegratedQuery.Task;

namespace LanguageIntegratedQuery
{
    /// <summary>
    /// Tasks Executions
    /// </summary>
    internal class Tasks
    {
        private readonly BasicLINQ _basicLINQ;
        private readonly ComplexQueries _complex;
        private readonly ObjectQueries _objectQueries;
        private readonly Optimization _optimization;
        private readonly TestBuilder _testBuilder;
        private List<Product> _products = new ();
        private List<Supplier> _suppliers = new ();
        private int[] _numbers = new[] { 10, 20, 30, 20, 40, 50, 10, 60 };

        /// <summary>
        /// Initializes a new instance of the <see cref="Tasks"/> class.
        /// </summary>
        /// <param name="basicLINQ">The basic LINQ filter and selection functions.</param>
        /// <param name="complex">The complex LINQ query operations and groupings.</param>
        /// <param name="objectQueries">The query handlers for complex data objects.</param>
        /// <param name="optimization">The performance optimization techniques for LINQ.</param>
        /// <param name="testBuilder">The builder used to generate testing scenarios.</param>
        public Tasks(BasicLINQ basicLINQ, ComplexQueries complex, ObjectQueries objectQueries, Optimization optimization, TestBuilder testBuilder)
        {
            this._basicLINQ = basicLINQ;
            this._complex = complex;
            this._objectQueries = objectQueries;
            this._optimization = optimization;
            this._testBuilder = testBuilder;
        }

        /// <summary>
        /// Task Operations
        /// </summary>
        public void ExecuteTasks()
        {
            bool state = true;
            this.PopulateProducts();
            this.PopulateSuppliers();
            while (state)
            {
                Console.WriteLine(@"Select a task to execute:
1. Task 1 (Basic LINQ)
2. Task 2 (Complex Queries)
3. Task 3 (Object Queries)
4. Task 4 (Optimization)
5. Task 5 (Test Builder)
");

                int? task = UserInput.ReadInt("Enter choice: ", 1, 5);

                switch (task)
                {
                    case 1:
                        {
                            this._basicLINQ.Task1(this._products);
                            break;
                        }

                    case 2:
                        {
                            this._complex.Task2(this._products, this._suppliers);
                            break;
                        }

                    case 3:
                        {
                            this._objectQueries.Task3(this._numbers);
                            break;
                        }

                    case 4:
                        {
                            this._optimization.Task4(this._products);
                            break;
                        }

                    case 5:
                        {
                            this._testBuilder.Task5(this._products, this._suppliers);
                            break;
                        }

                    case 6:
                        {
                            state = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid task.");
                            break;
                        }
                }

                UserInput.WaitAndClear();
            }
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
    }
}