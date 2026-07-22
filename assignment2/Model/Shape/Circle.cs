namespace Assignment2.Model.Shape
{
    /// <summary>
    /// The Circle class
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// constructor for the circle class
        /// </summary>
        /// <param name="radius"> the radius of the circle </param>
        /// <param name="colour"> the colour of the circle </param>
        public Circle(double radius, string? colour)
        {
            this.Radius = radius;
            this.Colour = colour;
        }

        /// <summary>
        /// Gets or sets and sets radius of the circle.
        /// </summary>
        private double Radius { get; set; }

        private string? Name { get; set; }

        /// <summary>
        /// calculates the area of the circle
        /// </summary>
        /// <returns> the area of the circle </returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        /// <summary>
        /// Printing the details
        /// </summary>
        /// <returns> returns the details</returns>
        public override string? PrintDetails()
        {
            return $"The Shape is : {this.Name} , Area is : {this.Area}, Colour is {this.Colour}\n";
        }
    }
}
