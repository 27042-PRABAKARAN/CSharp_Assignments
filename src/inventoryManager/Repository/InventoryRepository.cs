using InventoryManager.Models;

namespace InventoryManager.Repository
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
            this._products.Add(product);
            return true;
        }

        /// <summary>
        /// to remove a product.
        /// </summary>
        /// <param name="id"> the product to be removed </param>
        /// <returns> the status of deletion </returns>
        public bool RemoveProduct(string id)
        {
            Product? product = this._products.FirstOrDefault(product => product.Id == id);
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
        /// <returns> enumerable list of found elements </returns>
        public List<Product> SearchProducts(string name)
        {
            return this._products.Where(record => record.Name != null && (record.Name.Contains(name, StringComparison.OrdinalIgnoreCase) || record.Id.Contains(name, StringComparison.OrdinalIgnoreCase))).Select(product => product.Clone()).ToList();
        }

        /// <summary>
        /// to get all the details in repository
        /// </summary>
        /// <returns> returns enumerable list of products available </returns>
        public IEnumerable<Product> GetAll()
        {
            return this._products.Select(product => product.Clone());
        }

        /// <summary>
        /// to update the product details
        /// </summary>
        /// <param name="updateProduct"> the updated product </param>
        /// <returns> the status of the product update </returns>
        public bool UpdateProduct(Product updateProduct)
        {
            Product? product = this._products.FirstOrDefault(product => product.Id == updateProduct.Id);
            if (product != null)
            {
                product.Name = updateProduct.Name;
                product.Quantity = updateProduct.Quantity;
                product.Price = updateProduct.Price;
                return true;
            }

            return false;
        }

        /// <summary>
        /// To create a cloned copy of found product
        /// </summary>
        /// <param name="id"> Id of the product to be found</param>
        /// <returns>A cloned copy of found product</returns>
        public Product? GetProductById(string id)
        {
            return this._products.FirstOrDefault(product => product.Id == id)?.Clone();
        }
    }
}
