using System.Globalization;
using Assignment2.Helper;
using Assignment2.Service;

namespace Assignment2.View
{
    /// <summary>
    /// the view class of task -1 shapes
    /// </summary>
    internal class Shapes
    {
        /// <summary>
        /// instance of the _shapeService
        /// </summary>
        private readonly ShapeService _shapeService = new ShapeService();

        /// <summary>
        /// Operation enumerator
        /// </summary>
        internal enum Operation
        {
            /// <summary>
            /// to create a rectangle
            /// </summary>
            CreateRectangle = 1,

            /// <summary>
            /// to create a circle
            /// </summary>
            CreateCircle,

            /// <summary>
            /// to exit the app
            /// </summary>
            Exit,
        }

        /// <summary>
        /// Function that starts the app
        /// </summary>
        public void ShapeOperations()
        {
            Console.WriteLine("Welcome to Shapes ");
            while (true)
            {
                Console.WriteLine("1. Create A Rectangle.\n2. Create A Circle.\n3. Exit the app");
                Console.Write("Enter the number: ");
                string? userInput = Console.ReadLine();
                if (!Input.IsNull(userInput))
                {
                    return;
                }
                else
                {
                    int index;
                    int.TryParse(userInput, out index);
                    Operation operation = (Operation)index;
                    switch (operation)
                    {
                        case Operation.CreateRectangle:
                            {
                                Console.Write("Enter length in meters: ");
                                if (!double.TryParse(Console.ReadLine(), out double length) || length <= 0)
                                {
                                    Console.WriteLine("Invalid length. Please enter a positive number.");
                                    break;
                                }

                                Console.Write("Enter width in meters: ");
                                if (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double width) || width <= 0)
                                {
                                    Console.WriteLine("Invalid width. Please enter a positive number.");
                                    break;
                                }

                                Console.Write("Enter Colour of the Rectangle");
                                string? colour = Console.ReadLine();

                                this._shapeService.CreateCircle(colour, width, length);
                                break;
                            }

                        case Operation.CreateCircle:
                            {
                                Console.Write("Enter radius in meters: ");
                                if (!double.TryParse(Console.ReadLine(), out double radius) || radius <= 0)
                                {
                                    Console.WriteLine("Invalid length. Please enter a positive number.");
                                    break;
                                }

                                Console.Write("Enter Colour of the Circle : ");
                                string? colour = Console.ReadLine();

                                this._shapeService.CreateCircle(colour, radius);
                                break;
                            }

                        case Operation.Exit: return;

                        default: Console.WriteLine("enter valid choice"); break;
                    }
                }
            }
        }
    }
}
