namespace LanguageIntegratedQuery.Models
{
    /// <summary>
    /// Supplier model
    /// </summary>
    internal class Supplier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Supplier"/> class.
        /// </summary>
        /// <param name="id"> Id of the supplier </param>
        /// <param name="supplierName"> Name of the supplier</param>
        /// <param name="productId"> Id of the product supplied </param>
        public Supplier(Guid id, string supplierName, Guid productId)
        {
            this.SupplierId = id;
            this.SupplierName = supplierName;
            this.ProductId = productId;
        }

        /// <summary>
        /// Gets or sets id of the supplier
        /// </summary>
        /// <value>
        /// Id of the supplier
        /// </value>
        public Guid SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier
        /// </summary>
        /// <value> name of the supplier </value>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the Id of the product
        /// </summary>
        /// <value>
        /// Id of the product
        /// </value>
        public Guid ProductId { get; set; }
    }
}
