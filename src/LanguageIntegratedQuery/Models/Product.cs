namespace LanguageIntegratedQuery.Models
{
    /// <summary>
    /// Product model
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId"> Id of the product</param>
        /// <param name="name"> name of the product</param>
        /// <param name="price"> price of the product</param>
        /// <param name="category">category of the product</param>
        public Product(Guid productId, string name, decimal price, string category)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets id of the product
        /// </summary>
        /// <value>
        /// Id of the product
        /// </value>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product
        /// </summary>
        /// <value>
        /// Name of the product
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the product
        /// </summary>
        /// <value>
        /// Price of the product
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the category
        /// </summary>
        /// <value>
        /// Category of the product
        /// </value>
        public string Category { get; set; }
    }
}
