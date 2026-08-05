namespace ManagementSystem.Model.Shape
{
    /// <summary>
    /// Shape class
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color"> the color of the shape</param>
        public Shape(string color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets color of the shape
        /// </summary>
        /// <value>
        /// Color of the shape
        /// </value>
        protected string Color { get; set; }

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
            return $"Area is : {this.CalculateArea()}, Color is {this.Color}\n";
        }
    }
}
