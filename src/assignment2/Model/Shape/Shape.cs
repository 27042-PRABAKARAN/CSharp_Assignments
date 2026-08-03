namespace ManagementSystem.Model.Shape
{
    /// <summary>
    /// Shape class
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or sets colour of the shape
        /// </summary>
        /// <value>
        /// Colour of the shape
        /// </value>
        protected string Colour { get; set; } = string.Empty;

        /// <summary>
        /// Calculating area
        /// </summary>
        /// <returns> return the calculated area </returns>
        public abstract double CalculateArea();

        /// <summary>
        /// this prints the details
        /// </summary>
        /// <returns> returns the details </returns>
        public virtual string PrintDetails()
        {
            return $"Area is : {this.CalculateArea()}, Colour is {this.Colour}\n";
        }
    }
}
