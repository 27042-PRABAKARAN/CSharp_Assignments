using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using InventoryManager.Models;
using InventoryManager.Persistence;

namespace InventoryManager.Service
{
    /// <summary>
    /// the service layer.
    /// </summary>
    internal class InventoryService
    {
        private readonly InventoryRepository _repository = new InventoryRepository();

        /// <summary>
        /// to create a new product.
        /// </summary>
        /// <param name="name"> the name of the product </param>
        /// <param name="price"> the price of the product </param>
        /// <param name="quantity"> the quantity of the product</param>
        /// <returns> returns status</returns>
        public bool Create(string? name, decimal price, decimal quantity)
        {
            Guid id = Guid.NewGuid();
            Product newProduct = new Product(id, name, price, quantity);
            this._repository.Add(newProduct);
            return true;
        }

        /// <summary>
        /// the delete operation takes place.
        /// </summary>
        /// <param name="id"> the GUID of the Product</param>
        /// <returns> returns the status of the deletion process</returns>
        public bool Delete(Guid id)
        {
            return this._repository.Remove(id);
        }

        /// <summary>
        /// to get all the items.
        /// </summary>
        /// <returns> the list of products </returns>
        public List<Product> GetAll()
        {
            return this._repository.GetAll();
        }

        public List<Product> Search(string? name)
        {
            this._repository.Search(name);
        }
    }
}
