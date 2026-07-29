using InventoryManager.Helper;
using InventoryManager.Models;
using InventoryManager.Persistence;
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
        public static void Main(string[] args)
        {
            InventoryRepository repository = new InventoryRepository();
            InventoryService service = new InventoryService(repository);
            InventoryOperations inventoryOperations = new InventoryOperations(service);
            bool app = true;
            Console.WriteLine("Hey User,");
            Console.WriteLine("Welcome to Inventory Manager");
            while (app)
            {
                try
                {
                    Console.WriteLine("\n====================\n1.Create product\n2.Search, Update and Delete Product.\n3.Sort Product\n4.Display\n5.Exit\n====================\n");
                    int? choice = UserInput.ReadInt("Enter your choice : ", 1, 5);
                    if (choice == null)
                    {
                        throw new NullReferenceException("The choice is null here");
                    }

                    switch ((Choice)choice)
                    {
                        case Choice.CreateProduct: inventoryOperations.CreateProduct(); break;
                        case Choice.ManipulateProduct: inventoryOperations.ManipulateProduct(); break;
                        case Choice.SortProduct: inventoryOperations.SortProduct(); break;
                        case Choice.DisplayProduct: inventoryOperations.DisplayProducts(); break;
                        case Choice.Exit: Output.Success("Exiting..."); app = false; break;
                        default: Output.Error("Enter Valid Input"); break;
                    }
                }
                catch (Exception e)
                {
                    Output.Error(e.Message);
                }
            }
        }
    }
}
