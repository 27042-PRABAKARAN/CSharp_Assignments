using ConsoleTables;
using InventoryManager.Models;

namespace InventoryManager.View
{
    /// <summary>
    /// to display as table.
    /// </summary>
    internal class TablePrinter
    {
        /// <summary>
        /// to display as tables.
        /// </summary>
        /// <param name="products"> the list to be printed as tables </param>
        public static void PrintTable(IEnumerable<Product> products)
        {
            var table = new ConsoleTable("S.no", "ProductId", "ProductName", "Price", "Quantity");
            int i = 0;
            foreach (Product product in products)
            {
                table.AddRow(++i, product.Id, product.Name, product.Price, product.Quantity);
            }

            table.Write(Format.Alternative);
        }
    }
}
