using Assignment2.Model.Shape;

namespace Assignment2.Service
{
    /// <summary>
    /// Services for shape
    /// </summary>
    internal class ShapeService
    {
        /// <summary>
        /// Creating the rectangle
        /// </summary>
        /// <param name="colour"> the colour of the rectangle </param>
        /// <param name="width"> the width of the rectangle </param>
        /// <param name="length"> the length of the rectangle </param>
        /// <returns> returns the details</returns>
        public string? CreateRectangle(string? colour, double? width, double? length)
        {
            Rectangle newRectangle = new Rectangle(colour, length, width);
            newRectangle.CalculateArea();
            return newRectangle.PrintDetails();
        }

        /// <summary>
        /// Creating the circle
        /// </summary>
        /// <param name="colour"> The colour of the circle  </param>
        /// <param name="radius"> the radius of the circle </param>
        /// <returns> returns the details if created </returns>
        public string? CreateCircle(string? colour, double? radius)
        {
            Circle newCircle = new Circle(radius, colour);
            newCircle.CalculateArea();
            return newCircle.PrintDetails();
        }
    }
}
