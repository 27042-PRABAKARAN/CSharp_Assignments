using ManagementSystem.Model.Shape;

namespace ManagementSystem.Service
{
    /// <summary>
    /// Services for shape
    /// </summary>
    internal class ShapeService
    {
        /// <summary>
        /// Creating the rectangle
        /// </summary>
        /// <param name="color"> the color of the rectangle </param>
        /// <param name="width"> the width of the rectangle </param>
        /// <param name="length"> the length of the rectangle </param>
        /// <returns> returns the details</returns>
        public string CreateRectangle(string color, double width, double length)
        {
            Rectangle newRectangle = new Rectangle(color, length, width);
            return newRectangle.PrintDetails();
        }

        /// <summary>
        /// Creating the circle
        /// </summary>
        /// <param name="color"> The color of the circle  </param>
        /// <param name="radius"> the radius of the circle </param>
        /// <returns> returns the details if created </returns>
        public string CreateCircle(string color, double radius)
        {
            Circle newCircle = new Circle(radius, color);
            return newCircle.PrintDetails();
        }
    }
}
