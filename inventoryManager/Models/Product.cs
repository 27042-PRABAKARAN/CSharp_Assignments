using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    internal class Product
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id"> the id</param>
        /// <param name="name"> name </param>
        /// <param name="price"> price </param>
        /// <param name="quantity"> quantity </param>
        public Product(string id, string name, decimal price, decimal quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Gets unique identifier
        /// </summary>
        /// <value> id of the product </value>
        public string Id { get; init; }

        /// <summary>
        /// gets or sets the name of the product.
        /// </summary>
        /// <value> name of the product </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// gets or sets the price of the product
        /// </summary>
        /// <value> stores the price </value>
        public decimal Price { get; set; } = decimal.Zero;

        /// <summary>
        /// gets or sets the quantity of the product
        /// </summary>
        /// <value> stores the quantity </value>
        public decimal Quantity { get; set; } = decimal.Zero;
    }
}
