using System.Diagnostics;
using System.Xml.Linq;
using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Service;
using static System.Net.Mime.MediaTypeNames;

namespace InventoryManager.View
{
    /// <summary>
    /// enum for manipulating operation
    /// </summary>
    public enum Operation
    {
        /// <summary>
        /// to update the product.
        /// </summary>
        Update = 1,

        /// <summary>
        /// to delete the product.
        /// </summary>
        Delete,

        /// <summary>
        /// to exit
        /// </summary>
        Exit,
    }

    /// <summary>
    /// the view operations
    /// </summary>
    internal class InventoryOperations
    {
        private readonly InventoryService _inventoryServices = new InventoryService();

        /// <summary>
        /// to create a product
        /// </summary>
        public void CreateProduct()
        {
            string? name = UserInput.ReadInput("Enter name of the product : ");
            if (name == null)
            {
                return;
            }

            decimal? price = UserInput.ReadDecimal("Enter the price of the product: ");
            if (price == null)
            {
                return;
            }

            decimal? quantity = UserInput.ReadDecimal("Enter the Quantity of the product: ");
            if (quantity == null)
            {
                return;
            }

            if (this._inventoryServices.CreateProduct(name, price, quantity))
            {
                Output.Success("Created product successfully");
            }
            else
            {
                Output.Error("Product not created");
            }
        }

        /// <summary>
        /// to Manipulate products.
        /// </summary>
        public void ManipulateProduct()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                Output.Error("Empty database");
                return;
            }

            string? name = UserInput.ReadInput("Enter the name of the product: ");
            List<Product> products = this._inventoryServices.SearchProducts(name);

            if (products.Count() == 0)
            {
                Output.Error(" Not Found .");
                return;
            }

            Display.PrintTable(products);
            Console.WriteLine("\n1.Update product\n2.Delete product\n3.Exit");
            int? choice = UserInput.ReadInt("Enter choice : ", 1, 3);
            if (choice == null)
            {
                return;
            }

            Operation operation = (Operation)choice;
            switch (operation)
            {
                case Operation.Update: this.Update(products); break;
                case Operation.Delete: this.Delete(products); break;
                case Operation.Exit: return;
            }
        }

        /// <summary>
        /// to update the product
        /// </summary>
        /// <param name="products"> list of searched product </param>
        public void Update(List<Product> products)
        {
            int? index = UserInput.ReadInt("Enter the S.No of the product: ", 1, products.Count());
            if (index == null)
            {
                return;
            }

            index = index - 1;
            Console.WriteLine("\n1.Update Name\n2.Update Price\n3.Update Quantity\nExit");
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
                        if (this._inventoryServices.Update(products[(int)index].Id, name))
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
                        if (this._inventoryServices.Update(UpdateChoice.Quantity, products[(int)index].Id, quantity))
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
                        if (this._inventoryServices.Update(UpdateChoice.Quantity, products[(int)index].Id, price))
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
        /// <param name="products"> list of searched product </param>
        public void Delete(List<Product> products)
        {
            int? index = UserInput.ReadInt("Enter the S.No of the product: ", 1, products.Count());
            if (index == null)
            {
                return;
            }

            index = index - 1;
            Guid id = products[(int)index].Id;
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
            List<Product> products = this._inventoryServices.GetAllProducts();
            Display.PrintTable(products);
        }

        /// <summary>
        /// to sort products
        /// </summary>
        public void SortProduct()
        {
            if (this._inventoryServices.IsEmptyDatabase())
            {
                Output.Error("Empty database");
                return;
            }

            List<Product> products = this._inventoryServices.GetAllProducts();
            Console.WriteLine("\n1.Sort by Name\n2.Sort by Price\n3.Sort by Quantity\nExit");
            int? choice = UserInput.ReadInt("Enter the choice : ", 1, 4);
            if (choice == null)
            {
                return;
            }

            switch ((UpdateChoice)choice)
            {
                case UpdateChoice.Name: products.Sort((p1, p2) => string.Compare(p2.Name, p1.Name, StringComparison.OrdinalIgnoreCase)); Display.PrintTable(products); break;
                case UpdateChoice.Quantity: products.Sort((p1, p2) => string.Compare(p2.Name, p1.Name, StringComparison.OrdinalIgnoreCase)); Display.PrintTable(products); break;
                case UpdateChoice.Price: products.Sort((p1, p2) => string.Compare(p2.Name, p1.Name, StringComparison.OrdinalIgnoreCase)); Display.PrintTable(products); break;
            }
        }
    }
}