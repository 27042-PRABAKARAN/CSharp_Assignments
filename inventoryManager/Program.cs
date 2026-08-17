using InventoryManager.Helper;
using InventoryManager.Models.Enums;
using InventoryManager.Repository;
using InventoryManager.Service;
using InventoryManager.View;

namespace InventoryManager
{
    /// <summary>
    /// program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main function.
        /// </summary>
        /// <param name="args"> terminal arguments </param>
        public static void Main()
        {
            InventoryRepository repository = new ();
            InventoryService service = new (repository);
            InventoryOperations inventoryOperations = new (service);
            bool app = true;
            Console.WriteLine("Hey User,");
            Console.WriteLine("Welcome to Inventory Manager");
            while (app)
            {
                try
                {
                    Console.WriteLine("\n====================\n1.Create product\n2.Update product\n3.Search \n4.Delete Product\n5.Sort Product\n6.Display\n7.Exit\n====================\n");
                    int? choice = UserInput.ReadChoice("Enter your choice : ");
                    if (choice == null)
                    {
                        throw new InvalidOperationException("Enter Valid Input between 1-7");
                    }

                    switch ((Choice)choice)
                    {
                        case Choice.CreateProduct:
                            {
                                inventoryOperations.CreateProduct();
                                break;
                            }

                        case Choice.UpdateProduct:
                            {
                                inventoryOperations.UpdateProduct();
                                break;
                            }

                        case Choice.SearchProduct:
                            {
                                inventoryOperations.SearchProduct();
                                break;
                            }

                        case Choice.DeleteProduct:
                            {
                                inventoryOperations.DeleteProduct();
                                break;
                            }

                        case Choice.SortProduct:
                            {
                                inventoryOperations.SortProducts();
                                break;
                            }

                        case Choice.DisplayProduct:
                            {
                                inventoryOperations.DisplayProducts();
                                break;
                            }

                        case Choice.Exit:
                            {
                                ConsolePrinter.Success("Exiting...");
                                app = false;
                                break;
                            }

                        default: ConsolePrinter.Error("Enter Valid Input between 1-7"); break;
                    }
                }
                catch (Exception e)
                {
                    ConsolePrinter.Error(e.Message);
                }
            }
        }
    }
}
