using Assignment2.View;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"> if there are any terminal arguents</param>
        private static void Main(string[] args)
        {
            Shapes shape = new Shapes();
            shape.ShapeOperations();
        }
    }
}