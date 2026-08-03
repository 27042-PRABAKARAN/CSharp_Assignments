using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Service;

namespace InventoryManager.View
{
    /// <summary>
    /// the view operations
    /// </summary>
    internal class InventoryOperations
    {
        private readonly InventoryService _inventoryServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryOperations"/> class.
        /// Constructor injection
        /// </summary>
        /// <param name="inventoryServices"> the object of inventory Service </param>
        public InventoryOperations(InventoryService inventoryServices)
        {
            this._inventoryServices = inventoryServices;
        }

        /// <summary>
        /// to create a product
        /// </summary>
        public void CreateProduct()
        {
            string? name = UserInput.ReadInput("Enter name of the product : ");
            if (name == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            string? id = UserInput.ReadId("Enter Id of the product ( ABCD-0001 ): ");
            if (id == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            decimal? price = UserInput.ReadDecimal("Enter the price of the product: ");
            if (price == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            decimal? quantity = UserInput.ReadDecimal("Enter the Quantity of the product: ");
            if (quantity == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            this._inventoryServices.CreateProduct(name, id, (decimal)price, (decimal)quantity);
            Output.Success("Created product successfully");
        }

        /// <summary>
        /// to Manipulate products.
        /// </summary>
        public void SearchProduct()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                Output.Error("Empty Inventory. First Add a product.");
                return;
            }

            string? name = UserInput.ReadInput("Enter the name or ID of the product: ");
            if (name == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            List<Product> products = this._inventoryServices.SearchProducts(name);

            if (products.Count() == 0)
            {
                Output.Error(" Not Found .");
                return;
            }

            Display.PrintTable(products);
        }

        /// <summary>
        /// to update the product
        /// </summary>
        public void UpdateProduct()
        {
            this.DisplayProducts();
            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            int? index = UserInput.ReadInt("Enter the S.No of the product: ", 1, products.Count());
            if (index == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            index = index - 1;
            Console.WriteLine("\n====================\n1.Update Name\n2.Update Price\n3.Update Quantity\n4.Exit\n====================");
            int? choice = UserInput.ReadInt("Enter the choice : ", 1, 4);
            if (choice == null)
            {
                return;
            }

            UpdateChoice operation = (UpdateChoice)choice;
            switch (operation)
            {
                case UpdateChoice.Name:
                    {
                        string? name = UserInput.ReadInput("Enter Name: ");
                        if (name == null)
                        {
                            throw new ArgumentNullException("Invalid entry entered more than 3 times");
                        }

                        if (this._inventoryServices.UpdateProduct(products.ElementAt((int)index).Id, name))
                        {
                            Output.Success("updated successfully. ");
                        }
                        else
                        {
                            Output.Error("Item not updated");
                        }

                        break;
                    }

                case UpdateChoice.Quantity:
                    {
                        decimal? quantity = UserInput.ReadDecimal("Enter Quantity: ");
                        if (quantity == null)
                        {
                            throw new ArgumentNullException("Invalid entry entered more than 3 times");
                        }

                        if (this._inventoryServices.UpdateProduct(UpdateChoice.Quantity, products.ElementAt((int)index).Id, (decimal)quantity))
                        {
                            Output.Success("updated successfully. ");
                        }
                        else
                        {
                            Output.Error("Item not updated");
                        }

                        break;
                    }

                case UpdateChoice.Price:
                    {
                        decimal? price = UserInput.ReadDecimal("Enter Price: ");
                        if (price == null)
                        {
                            throw new ArgumentNullException("Invalid entry entered more than 3 times");
                        }

                        if (this._inventoryServices.UpdateProduct(UpdateChoice.Price, products.ElementAt((int)index).Id, (decimal)price))
                        {
                            Output.Success("updated successfully. ");
                        }
                        else
                        {
                            Output.Error("Item not updated");
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// to Delete product
        /// </summary>
        public void DeleteProduct()
        {
            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            this.DisplayProducts();
            int? index = UserInput.ReadInt("Enter the S.No of the product: ", 1, products.Count());
            if (index == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            index = index - 1;
            string id = products.ElementAt((int)index).Id;
            if (this._inventoryServices.DeleteProduct(id))
            {
                Output.Success("deleted Successfully");
            }
            else
            {
                Output.Error("Item not deleted");
            }
        }

        /// <summary>
        /// to display products.
        /// </summary>
        public void DisplayProducts()
        {
            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            if (products.Count() == 0)
            {
                Output.Error("No Product Available");
                return;
            }

            Display.PrintTable(products);
        }

        /// <summary>
        /// to sort products
        /// </summary>
        public void SortProducts()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                Output.Error("Empty Inventory Add Products first");
                return;
            }

            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            Console.WriteLine("\n1.Sort by Name\n2.Sort by Price\n3.Sort by Quantity\n4.Exit");
            int? choice = UserInput.ReadInt("Enter the choice : ", 1, 4);
            if (choice == null)
            {
                throw new ArgumentNullException("Invalid entry entered more than 3 times");
            }

            switch ((UpdateChoice)choice)
            {
                case UpdateChoice.Name:
                    {
                        products = products.OrderBy(p => p.Name).ToList();
                        Display.PrintTable(products);
                        break;
                    }

                case UpdateChoice.Quantity:
                    {
                        products = products.OrderBy(p => p.Quantity).ToList();
                        Display.PrintTable(products);
                        break;
                    }

                case UpdateChoice.Price:
                    {
                        products = products.OrderBy(p => p.Price).ToList();
                        Display.PrintTable(products);
                        break;
                    }
            }
        }
    }
}