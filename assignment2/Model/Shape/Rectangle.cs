namespace Assignment2.Model.Shape
{
    /// <summary>
    /// this is the rectangle class
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// constructor for the Rectangle class
        /// </summary>
        /// <param name="colour"> colour of the rectangle </param>
        /// <param name="length"> the length of the rectangle </param>
        /// <param name="width"> the width of the rectangle </param>
        public Rectangle(string? colour, double? length, double? width)
        {
            this.Colour = colour;
            this.Length = length;
            this.Width = width;
        }

        private double? Length { get; set; }

        private double? Width { get; set; }

        /// <summary>
        /// calculates the area of the circle
        /// </summary>
        /// <returns> the area of the circle </returns>
        public override double? CalculateArea()
        {
            this.Area = this.Length * this.Width;
            return this.Area;
        }

        /// <summary>
        ///  this is Print Details
        /// </summary>
        /// <returns> returns the details</returns>
        public override string? PrintDetails()
        {
            return $"\nThe Shape is : Rectangle\nArea is : {this.Area} meter Square.\nColour is : {this.Colour}\n";
        }
    }
}
