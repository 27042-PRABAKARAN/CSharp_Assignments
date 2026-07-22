using System.Globalization;
using Assignment2.Helper;
using Assignment2.Service;

namespace Assignment2.View
{
    /// <summary>
    /// the view class of task - 1 shapes
    /// </summary>
    internal class ShapesSystem
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
            Output.Display("Welcome to Shapes ");
            while (true)
            {
                Output.Display("1. Create A Rectangle.\n2. Create A Circle.\n3. Exit the app");
                string? userInput = UserInput.ReadInput("Enter the number: ");

                int index;
                int.TryParse(userInput, out index);
                Operation operation = (Operation)index;
                switch (operation)
                {
                    case Operation.CreateRectangle: this.CreateRectangle(); break;
                    case Operation.CreateCircle: this.CreateCircle(); break;
                    case Operation.Exit: return;
                    default: Output.Display("enter valid choice"); break;
                }
            }
        }

        /// <summary>
        /// this calls create rectangle service
        /// </summary>
        public void CreateRectangle()
        {
            if (!double.TryParse(UserInput.ReadInput("Enter length in meters: "), out double length) || length <= 0)
            {
                Output.Display("Invalid length. Please enter a positive number.");
            }

            if (!double.TryParse(UserInput.ReadInput("Enter width in meters: "), NumberStyles.Float, CultureInfo.InvariantCulture, out double width) || width <= 0)
            {
                Output.Display("Invalid width. Please enter a positive number.");
            }

            string? colour = UserInput.ReadInput("Enter Colour of the Rectangle");

            Output.Display(this._shapeService.CreateRectangle(colour, width, length));
        }

        /// <summary>
        /// this calls create Circle service
        /// </summary>
        public void CreateCircle()
        {
            Output.Display("Enter radius in meters: ");
            if (!double.TryParse(Console.ReadLine(), out double radius) || radius <= 0)
            {
                Output.Display("Invalid length. Please enter a positive number.");
            }

            Output.Display("Enter Colour of the Circle : ");
            string? colour = Console.ReadLine();

            Output.Display(this._shapeService.CreateCircle(colour, radius));
        }
    }
}
