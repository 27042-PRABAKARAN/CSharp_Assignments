namespace ManagementSystem.Model.Shape
{
    /// <summary>
    /// this is the rectangle class
    /// </summary>
    internal class Rectangle : Shape
    {
        private const string Name = "Rectangle";

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// constructor for the Rectangle class
        /// </summary>
        /// <param name="colour"> colour of the rectangle </param>
        /// <param name="length"> the length of the rectangle </param>
        /// <param name="width"> the width of the rectangle </param>
        public Rectangle(string colour, double length, double width)
        {
            this.Colour = colour;
            this.Length = length;
            this.Width = width;
        }

        private double Length { get; set; }

        private double Width { get; set; }

        /// <summary>
        /// calculates the area of the circle
        /// </summary>
        /// <returns> the area of the circle </returns>
        public override double CalculateArea()
        {
            return this.Length * this.Width;
        }

        /// <summary>
        ///  this is to Print Details
        /// </summary>
        /// <returns> returns the details</returns>
        public override string PrintDetails()
        {
            return $"\nThe Shape is : {Name}\nArea is : {this.CalculateArea()} meter Square.\nColour is : {this.Colour}\n";
        }
    }
}
