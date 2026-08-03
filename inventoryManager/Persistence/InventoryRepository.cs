using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Models;

namespace InventoryManager.Persistence
{
    /// <summary>
    /// repository layer of inventory management system.
    /// </summary>
    internal class InventoryRepository
    {
        private readonly List<Product> _products = new List<Product>();

        /// <summary>
        /// to add a product
        /// </summary>
        /// <param name="product"> the product to be added</param>
        /// <returns> status of addition </returns>
        public bool AddProduct(Product product)
        {
            if (product == null)
            {
                throw new NullReferenceException("The product is not Added");
            }

            this._products.Add(product);
            return true;
        }

        /// <summary>
        /// to remove a product.
        /// </summary>
        /// <param name="id"> the product to be removed </param>
        /// <returns> the status of deletion </returns>
        public bool RemoveProduct(Guid id)
        {
            Product? product = this.GetProduct(id);
            if (product != null)
            {
                this._products.Remove(product);
                return true;
            }

            return false;
        }

        /// <summary>
        /// to search by name
        /// </summary>
        /// <param name="name"> the name of the product to be searched </param>
        /// <returns> enumberable list of found elements </returns>
        public List<Product> SearchProducts(string? name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("The name is not entered");
            }

            return this._products.Where(e => e.Name != null && e.Name.Contains(name)).Select(p => new Product(
                p.Id,
                p.Name,
                p.Price,
                p.Quantity)).ToList();
        }

        /// <summary>
        /// to get all the details in repository
        /// </summary>
        /// <returns> returns enumarable list of products available </returns>
        public IEnumerable<Product> GetAll()
        {
            return this._products.Select(p => new Product(
                p.Id,
                p.Name,
                p.Price,
                p.Quantity)).ToList();
        }

        /// <summary>
        /// to udate the product details
        /// </summary>
        /// <param name="updateProduct"> the updated product </param>
        /// <returns> the status of the product updation </returns>
        public bool UpdateProduct(Product updateProduct)
        {
            if (updateProduct == null)
            {
                throw new NullReferenceException("The product is not Updated");
            }

            Product? product = this.GetProductById(updateProduct.Id);
            if (product != null)
            {
                product.Name = updateProduct.Name;
                product.Quantity = updateProduct.Quantity;
                product.Price = updateProduct.Price;
                return true;
            }

            return false;
        }

        private Product? GetProductById(Guid id)
        {
            return this._products.FirstOrDefault(product => product.Id == id);
        }
    }
}
