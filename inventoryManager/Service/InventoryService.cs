using InventoryManager.Models;
using InventoryManager.Persistence;

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
        /// <param name="price"> the price of the product </param>
        /// <param name="quantity"> the quantity of the product</param>
        /// <returns> returns status</returns>
        public bool CreateProduct(string? name, decimal? price, decimal? quantity)
        {
            Guid id = Guid.NewGuid();
            Product newProduct = new Product(id, name, price, quantity);
            try
            {
                return this._repository.AddProduct(newProduct);
            }
            catch (Exception)
            {
                throw new NullReferenceException("The product is null here");
            }
        }

        /// <summary>
        /// the delete operation takes place.
        /// </summary>
        /// <param name="id"> the GUID of the Product</param>
        /// <returns> returns the status of the deletion process</returns>
        public bool DeleteProduct(Guid id)
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
        /// <param name="choice"> which parameter is updated</param>
        /// <param name="id"> on which product the upadte takes place</param>
        /// <param name="value"> new value to be updated</param>
        /// <returns> status of the updation</returns>
        public bool UpdateProduct(UpdateChoice choice, Guid id, decimal? value)
        {
            Product? product = this.GetProduct(id);
            if (product == null)
            {
                return false;
            }

            try
            {
                switch (choice)
                {
                    case UpdateChoice.Price: product.Price = value; return this._repository.UpdateProduct(product);
                    case UpdateChoice.Quantity: product.Quantity = value; return this._repository.UpdateProduct(product);
                    default: return false;
                }
            }
            catch (Exception)
            {
                throw new NullReferenceException("The product is not Updated");
            }
        }

        /// <summary>
        /// to update
        /// </summary>
        /// <param name="id"> on which product the upadte takes place</param>
        /// <param name="value"> new value to be updated</param>
        /// <returns> status of the updation</returns>
        public bool UpdateProduct(Guid id, string? value)
        {
            Product? product = this.GetProduct(id);
            if (product == null)
            {
                return false;
            }

            product.Name = value;
            try
            {
                return this._repository.UpdateProduct(product);
            }
            catch (Exception)
            {
                throw new NullReferenceException("The product is not Updated");
            }
        }

        /// <summary>
        /// to check if the database is enmpty or not
        /// </summary>
        /// <returns> the status of the repo</returns>
        public bool IsEmptyDatabase()
        {
            IEnumerable<Product> list = this.GetAllProducts();
            if (list.Count() == 0)
            {
                return true;
            }

            return false;
        }

        private Product? GetProduct(Guid id)
        {
            return this._repository.GetAll().FirstOrDefault(product => product.Id == id);
        }
    }
}
