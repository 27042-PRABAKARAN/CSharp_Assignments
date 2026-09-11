namespace InventoryManager.Models.Enums
{
    /// <summary>
    /// Choice enum
    /// </summary>
    internal enum Choice
    {
        /// <summary>
        /// CreateProduct
        /// </summary>
        CreateProduct = 1,

        /// <summary>
        /// ManipulateProduct
        /// </summary>
        UpdateProduct,

        /// <summary>
        /// SearchProduct
        /// </summary>
        SearchProduct,

        /// <summary>
        /// DeleteProduct
        /// </summary>
        DeleteProduct,

        /// <summary>
        /// Sort Product
        /// </summary>
        SortProduct,

        /// <summary>
        /// to display products
        /// </summary>
        DisplayProduct,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
