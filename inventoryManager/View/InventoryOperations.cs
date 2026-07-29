using System.Diagnostics;
using System.Xml.Linq;
using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Service;
using static System.Net.Mime.MediaTypeNames;

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
                throw new ArgumentNullException("Exception : Invalid entry entered more than 3 times");
            }

            decimal? price = UserInput.ReadDecimal("Enter the price of the product: ");
            if (price == null)
            {
                throw new ArgumentNullException("Exception : Invalid entry entered more than 3 times");
            }

            decimal? quantity = UserInput.ReadDecimal("Enter the Quantity of the product: ");
            if (quantity == null)
            {
                throw new ArgumentNullException("Exception : Invalid entry entered more than 3 times");
            }

            try
            {
                this._inventoryServices.CreateProduct(name, price, quantity);
                Output.Success("Created product successfully");
            }
            catch (Exception ex)
            {
                Output.Error(ex.Message);
                Output.Error("Product not created");
                return;
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
            if (name == null)
            {
                throw new ArgumentNullException("Exception : Invalid entry entered more than 3 times");
            }

            try
            {
                List<Product> products = this._inventoryServices.SearchProducts(name);

                if (products.Count() == 0)
                {
                    Output.Error(" Not Found .");
                    return;
                }

                Display.PrintTable(products);
                Console.WriteLine("\n====================\n1.Update product\n2.Delete product\n3.Exit\n====================");
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
            catch (Exception ex)
            {
                Output.Error(ex.Message);
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
                throw new ArgumentNullException("Exception : Invalid entry entered more than 3 times");
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
                        if (this._inventoryServices.Update(UpdateChoice.Price, products[(int)index].Id, price))
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
                throw new ArgumentNullException("Exception : Invalid entry entered more than 3 times");
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
            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            if (products.Count() == 0)
            {
                Output.Error("Nothing to display");
                return;
            }

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

            IEnumerable<Product> products = this._inventoryServices.GetAllProducts();
            Console.WriteLine("\n1.Sort by Name\n2.Sort by Price\n3.Sort by Quantity\n4.Exit");
            int? choice = UserInput.ReadInt("Enter the choice : ", 1, 4);
            if (choice == null)
            {
                throw new ArgumentNullException("Exception : Invalid entry entered more than 3 times");
            }

            switch ((UpdateChoice)choice)
            {
                case UpdateChoice.Name: products = products.OrderBy(p => p.Name).ToList(); Display.PrintTable(products); break;
                case UpdateChoice.Quantity: products = products.OrderBy(p => p.Quantity).ToList(); Display.PrintTable(products); break;
                case UpdateChoice.Price: products = products.OrderBy(p => p.Price).ToList(); Display.PrintTable(products); break;
            }
        }
    }
}