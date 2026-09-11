using InventoryManager.Models;
using InventoryManager.Models.Enums;
using InventoryManager.Repository;

namespace InventoryManager.Service
{
    /// <summary>
    /// the service layer.
    /// </summary>
    internal class InventoryService
    {
        private readonly InventoryRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// constructor injection
        /// </summary>
        /// <param name="repository"> repository </param>
        public InventoryService(InventoryRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// to create a new product.
        /// </summary>
        /// <param name="name"> the name of the product </param>
        /// <param name="id"> the id of the product </param>
        /// <param name="price"> the price of the product </param>
        /// <param name="quantity"> the quantity of the product</param>
        /// <returns> returns status </returns>
        public bool CreateProduct(string name, string id, decimal price, long quantity)
        {
            Product newProduct = new (id, name, price, quantity);
            return this._repository.AddProduct(newProduct);
        }

        /// <summary>
        /// the delete operation takes place.
        /// </summary>
        /// <param name="id"> the ID of the Product</param>
        /// <returns> returns the status of the deletion process</returns>
        public bool DeleteProduct(string id)
        {
            return this._repository.RemoveProduct(id);
        }

        /// <summary>
        /// to get all the items.
        /// </summary>
        /// <returns> the list of products </returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// the search operation
        /// </summary>
        /// <param name="name"> the name to be searched </param>
        /// <returns> the list of searched product</returns>
        public List<Product> SearchProducts(string name)
        {
            return this._repository.SearchProducts(name);
        }

        /// <summary>
        /// to update
        /// </summary>
        /// <param name="id"> on which product the update takes place</param>
        /// <param name="value"> new value to be updated</param>
        /// <returns> status of the update</returns>
        public bool UpdateProduct(string id, long value)
        {
            Product? product = this._repository.GetProductById(id);
            if (product == null)
            {
                return false;
            }

            product.Quantity = value;
            return this._repository.UpdateProduct(product);
        }

        /// <summary>
        /// to update
        /// </summary>
        /// <param name="id"> on which product the update takes place</param>
        /// <param name="value"> new value to be updated</param>
        /// <returns> status of the update</returns>
        public bool UpdateProduct(string id, decimal value)
        {
            Product? product = this._repository.GetProductById(id);
            if (product == null)
            {
                return false;
            }

            product.Price = value;
            return this._repository.UpdateProduct(product);
        }

        /// <summary>
        /// to update
        /// </summary>
        /// <param name="id"> on which product the update takes place</param>
        /// <param name="value"> new value to be updated</param>
        /// <returns> status of the update</returns>
        public bool UpdateProduct(string id, string value)
        {
            Product? product = this._repository.GetProductById(id);
            if (product == null)
            {
                return false;
            }

            product.Name = value;
            return this._repository.UpdateProduct(product);
        }

        /// <summary>
        /// to check if the database is empty or not
        /// </summary>
        /// <returns> the status of the repo</returns>
        public bool IsEmptyDatabase()
        {
            IEnumerable<Product> list = this.GetAllProducts();
            if (list.Any())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a product with the specified ID already exists.
        /// </summary>
        /// <param name="id">The product ID.</param>
        /// <returns>True if a product with the same ID exists; otherwise, false.</returns>
        public bool IsIdExists(string id)
        {
            return this._repository.GetProductById(id) != null;
        }
    }
}
