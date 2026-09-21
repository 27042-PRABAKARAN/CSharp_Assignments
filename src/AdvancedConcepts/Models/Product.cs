namespace AdvancedConcepts.Models
{
    /// <summary>
    /// Represents a commercial product with a name, category, and price.
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified details.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="category">The category group the product belongs to.</param>
        /// <param name="price">The retail cost of the product.</param>
        public Product(string name, string category, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> containing the descriptive name of the product.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category classification of the product.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> indicating the marketplace or organizational category of the product.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the monetary value or price of the product.
        /// </summary>
        /// <value>
        /// A <see cref="double"/> representing the numeric commercial value or retail cost of the product.
        /// </value>
        public double Price { get; set; }

        /// <summary>
        /// Returns a formatted string representation of the product's attributes.
        /// </summary>
        /// <returns>A string containing the product name, category, and price details.</returns>
        public override string ToString()
        {
            return $"Name: {this.Name} | Category: {this.Category} | Price: ${this.Price}";
        }
    }
}
