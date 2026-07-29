using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
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
}
