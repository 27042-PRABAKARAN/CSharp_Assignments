using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Models.Enums;
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
            string? name = UserInput.ReadName("Enter name of the product : ");
            if (name == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            string? id = UserInput.ReadId("Enter Id of the product ( ABCD-0001 ): ", this._inventoryServices.IsIdExists);
            if (id == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            decimal? price = UserInput.ReadPrice("Enter the price of the product: ");
            if (price == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            long? quantity = UserInput.ReadQuantity("Enter the Quantity of the product: ");
            if (quantity == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            this._inventoryServices.CreateProduct(name, id, (decimal)price, (long)quantity);
            ConsolePrinter.Success("Created product successfully");
        }

        /// <summary>
        /// to Search products.
        /// </summary>
        public void SearchProduct()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                ConsolePrinter.Error("Empty Inventory. First Add a product.");
                return;
            }

            string? name = UserInput.ReadInput("Enter the name or ID of the product: ");
            if (name == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            List<Product> products = this._inventoryServices.SearchProducts(name);

            if (products.Count() == 0)
            {
                ConsolePrinter.Error(" Not Found .");
                return;
            }

            TablePrinter.PrintTable(products);
        }

        /// <summary>
        /// to update the product
        /// </summary>
        public void UpdateProduct()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                ConsolePrinter.Error("Empty Inventory. First Add a product.");
                return;
            }

            this.DisplayProducts();
            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            int? index = UserInput.ReadInt("Enter the S.No of the product: ", 1, products.Count());
            if (index == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            index = index - 1;
            Console.WriteLine(@"====================
1.Update Name
2.Update Price
3.Update Quantity
4.Exit
====================");
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
                            throw new InvalidOperationException("Invalid entry entered more than 3 times");
                        }

                        if (this._inventoryServices.UpdateProduct(products.ElementAt((int)index).Id, name))
                        {
                            ConsolePrinter.Success("updated successfully. ");
                        }
                        else
                        {
                            ConsolePrinter.Error("Item not updated");
                        }

                        break;
                    }

                case UpdateChoice.Quantity:
                    {
                        decimal? quantity = UserInput.ReadQuantity("Enter Quantity: ");
                        if (quantity == null)
                        {
                            throw new InvalidOperationException("Invalid entry entered more than 3 times");
                        }

                        if (this._inventoryServices.UpdateProduct(products.ElementAt((int)index).Id, (long)quantity))
                        {
                            ConsolePrinter.Success("updated successfully. ");
                        }
                        else
                        {
                            ConsolePrinter.Error("Item not updated");
                        }

                        break;
                    }

                case UpdateChoice.Price:
                    {
                        decimal? price = UserInput.ReadPrice("Enter Price: ");
                        if (price == null)
                        {
                            throw new InvalidOperationException("Invalid entry entered more than 3 times");
                        }

                        if (this._inventoryServices.UpdateProduct(products.ElementAt((int)index).Id, (decimal)price))
                        {
                            ConsolePrinter.Success("updated successfully. ");
                        }
                        else
                        {
                            ConsolePrinter.Error("Item not updated");
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
            if (this._inventoryServices.IsEmptyDatabase())
            {
                ConsolePrinter.Error("Empty Inventory. First Add a product.");
                return;
            }

            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            this.DisplayProducts();
            int? index = UserInput.ReadInt("Enter the S.No of the product: ", 1, products.Count());
            if (index == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            index = index - 1;
            string id = products.ElementAt((int)index).Id;
            if (this._inventoryServices.DeleteProduct(id))
            {
                ConsolePrinter.Success("deleted Successfully");
            }
            else
            {
                ConsolePrinter.Error("Item not deleted");
            }
        }

        /// <summary>
        /// to display products.
        /// </summary>
        public void DisplayProducts()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                ConsolePrinter.Error("Empty Inventory. First Add a product.");
                return;
            }

            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            TablePrinter.PrintTable(products);
        }

        /// <summary>
        /// to sort products
        /// </summary>
        public void SortProducts()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                ConsolePrinter.Error("Empty Inventory. First Add a product.");
                return;
            }

            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            Console.WriteLine("\n1.Sort by Name\n2.Sort by Price\n3.Sort by Quantity\n4.Exit");
            int? choice = UserInput.ReadInt("Enter the choice : ", 1, 4);
            if (choice == null)
            {
                throw new InvalidOperationException("Invalid entry entered more than 3 times");
            }

            switch ((UpdateChoice)choice)
            {
                case UpdateChoice.Name:
                    {
                        products = products.OrderBy(p => p.Name).ToList();
                        TablePrinter.PrintTable(products);
                        break;
                    }

                case UpdateChoice.Quantity:
                    {
                        products = products.OrderBy(p => p.Quantity).ToList();
                        TablePrinter.PrintTable(products);
                        break;
                    }

                case UpdateChoice.Price:
                    {
                        products = products.OrderBy(p => p.Price).ToList();
                        TablePrinter.PrintTable(products);
                        break;
                    }
            }
        }
    }
}