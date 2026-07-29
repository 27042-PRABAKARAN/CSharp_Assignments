using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    /// <summary>
    /// enum for updation
    /// </summary>
    public enum UpdateChoice
    {
        /// <summary>
        /// to update the name of the product.
        /// </summary>
        Name = 1,

        /// <summary>
        /// to update the Price.
        /// </summary>
        Price,

        /// <summary>
        /// to update the Quantity.
        /// </summary>
        Quantity,

        /// <summary>
        /// to exit
        /// </summary>
        Exit,
    }
}
