using InventoryManager.Helper;
using InventoryManager.View;

namespace InventoryManager
{
    /// <summary>
    /// program class
    /// </summary>
    internal class Program
    {
        private static readonly InventoryOperations _inventoryOperation = new InventoryOperations();

        /// <summary>
        /// Choice enum
        /// </summary>
        public enum Choice
        {
            /// <summary>
            /// CreateProduct
            /// </summary>
            CreateProduct = 1,

            /// <summary>
            /// RemoveProduct
            /// </summary>
            RemoveProduct = 2,

            /// <summary>
            /// SearchProduct
            /// </summary>
            SearchProduct = 3,

            /// <summary>
            /// UpdateProduct
            /// </summary>
            UpdateProduct,

            /// <summary>
            /// Sort Product
            /// </summary>
            SortProduct,

            /// <summary>
            /// to display products
            /// </summary>
            DisplayProduct,

            /// <summary>
            /// Exit
            /// </summary>
            Exit,
        }

        /// <summary>
        /// main function.
        /// </summary>
        /// <param name="args"> terminal arguments </param>
        public static void Main(string[] args)
        {
            bool app = true;
            while (app)
            {
                Console.WriteLine("\n1.Create product\n2.Remove Product\n3.Search Product\n4.Update product\n5.Sort Product\n6.Display\n8.Exit");
                int? choice = UserInput.ReadInt("Enter your choice : ", 1, 7);
                if (choice == null)
                {
                    return;
                }

                switch ((Choice)choice)
                {
                    case Choice.CreateProduct: _inventoryOperation.CreateProduct(); break;
                    case Choice.RemoveProduct: _inventoryOperation.ManipulateProduct(); break;
                    case Choice.SearchProduct: _inventoryOperation.ManipulateProduct(); break;
                    case Choice.UpdateProduct: _inventoryOperation.ManipulateProduct(); break;
                    case Choice.SortProduct: _inventoryOperation.ManipulateProduct(); break;
                    case Choice.DisplayProduct: _inventoryOperation.DisplayProducts(); break;
                    case Choice.Exit: Output.Success("Exiting..."); app = false; break;
                    default: Output.Error("Enter Valid Input");break;
                }
            }
        }
    }
}
