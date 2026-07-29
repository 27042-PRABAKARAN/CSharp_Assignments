using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
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
        /// ManipulateProduct
        /// </summary>
        ManipulateProduct = 2,

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
}
