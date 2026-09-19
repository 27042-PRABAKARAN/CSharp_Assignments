using AdvancedConcepts.Models;

namespace AdvancedConcepts.Tasks
{
    /// <summary>
    /// Demonstrates the usage of type pattern matching within a switch statement to process different shape types.
    /// </summary>
    internal class PatternMatching
    {
        /// <summary>
        /// Executes the pattern matching demonstration by creating a collection of shapes and iterating through them to display details.
        /// </summary>
        public void ExecutePatternMatching()
        {
            Console.WriteLine("Task 7 - Calculate Shape Area");
            List<Shape> shapes = new List<Shape>
            {
                new Circle("Red", 12),
                new Rectangle("Red", 12, 3),
                new Triangle("Green", 12, 5),
            };

            foreach (var shape in shapes)
            {
                this.DisplayShapeDetails(shape);
            }
        }

        /// <summary>
        /// Identifies the specific shape type using pattern matching and prints its unique properties and calculated area to the console.
        /// </summary>
        /// <param name="shape">The base shape object to inspect and display.</param>
        private void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    Console.WriteLine("\nShape: Circle");
                    Console.WriteLine($"Color: {circle.Color}");
                    Console.WriteLine($"Radius: {circle.Radius}");
                    Console.WriteLine($"Area: {circle.CalculateArea()}\n");
                    break;

                case Rectangle rectangle:
                    Console.WriteLine("\nShape: Rectangle");
                    Console.WriteLine($"Color: {rectangle.Color}");
                    Console.WriteLine($"Length: {rectangle.Length}");
                    Console.WriteLine($"Width: {rectangle.Width}");
                    Console.WriteLine($"Area: {rectangle.CalculateArea()}\n");
                    break;

                case Triangle triangle:
                    Console.WriteLine("\nShape: Rectangle");
                    Console.WriteLine($"Color: {triangle.Color}");
                    Console.WriteLine($"Height: {triangle.Height}");
                    Console.WriteLine($"Width: {triangle.Base}");
                    Console.WriteLine($"Area: {triangle.CalculateArea()}\n");
                    break;
            }
        }
    }
}
