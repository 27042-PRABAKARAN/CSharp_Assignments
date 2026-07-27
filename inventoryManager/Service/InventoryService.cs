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

        /// <summary>
        /// the search operation
        /// </summary>
        /// <param name="name"> the name to be searched </param>
        /// <returns> the list of searched product</returns>
        public List<Product> Search(string? name)
        {
            return this._repository.Search(name);
        }

        /// <summary>
        /// to update
        /// </summary>
        /// <param name="choice"> which parameter is updated</param>
        /// <param name="id"> on which product the upadte takes place</param>
        /// <param name="value"> new value to be updated</param>
        /// <returns> status of the updation</returns>
        public bool Update(string? choice, Guid id, decimal? value)
        {
            Product? product = this.GetProduct(id);
            if (product == null)
            {
                return false;
            }

            switch (choice)
            {
                case "p": product.Price = value; return this._repository.Update(product);
                case "q": product.Quantity = value; return this._repository.Update(product);
                default: return false;
            }
        }

        private Product? GetProduct(Guid id)
        {
            return this._repository.GetAll().FirstOrDefault(p => p.Id == id);
        }
    }
}
