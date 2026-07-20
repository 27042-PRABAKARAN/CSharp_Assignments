using Assignment2.Model;

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
        /// <param name="colour"> the clour of the rectangle </param>
        /// <param name="width"> the widht of the rectangle </param>
        /// <param name="length"> the length of the rectangle </param>
        public void CreateCircle(string? colour, double width, double length)
        {
            Rectangle newRectangle = new Rectangle(colour, length, width);
            newRectangle.CalculateArea();
            newRectangle.PrintDetails();
        }

        /// <summary>
        /// Creating the circle
        /// </summary>
        /// <param name="colour"> The colour of the circle  </param>
        /// <param name="radius"> the radius of the circle </param>
        public void CreateCircle(string? colour, double radius)
        {
            Circle newCircle = new Circle(radius, colour);
            newCircle.CalculateArea();
            newCircle.PrintDetails();
        }
    }
}
