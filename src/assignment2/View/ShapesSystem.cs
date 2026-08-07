using ManagementSystem.Helper;
using ManagementSystem.Model.Shape;
using ManagementSystem.Service;

namespace ManagementSystem.View
{
    /// <summary>
    /// the view class of task - 1 shapes
    /// </summary>
    internal class ShapesSystem
    {
        /// <summary>
        /// instance of the _shapeService
        /// </summary>
        private readonly ShapeService _shapeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapesSystem"/> class.
        /// </summary>
        /// <param name="service"> the service instance</param>
        public ShapesSystem(ShapeService service)
        {
            this._shapeService = service;
        }

        /// <summary>
        /// Function that starts the app
        /// </summary>
        public void ShapeOperations()
        {
            Console.WriteLine("Welcome to Shapes ");
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"========================
1. Create A Rectangle.
2. Create A Circle.
3. Exit the app
========================");
                int? index = UserInput.ReadInt("Enter the choice: ", 1, 3);
                if (index == null)
                {
                    Console.WriteLine("returning to main menu");
                    return;
                }

                Operation operation = (Operation)index;
                switch (operation)
                {
                    case Operation.CreateRectangle: this.CreateRectangle(); break;
                    case Operation.CreateCircle: this.CreateCircle(); break;
                    case Operation.Exit: state = false; return;
                    default: Output.Error("enter valid choice"); break;
                }
            }
        }

        /// <summary>
        /// this calls create rectangle service
        /// </summary>
        public void CreateRectangle()
        {
            double? length = UserInput.ReadMeters("Enter length in meters : ");

            if (length == null)
            {
                return;
            }

            double? width = UserInput.ReadMeters("Enter width in meters : ");

            if (width == null)
            {
                return;
            }

            string? colour = UserInput.GetColor("Enter Color of the Rectangle: ");
            if (colour == null)
            {
                return;
            }

            Console.WriteLine(this._shapeService.CreateRectangle(colour, (double)width, (double)length));
        }

        /// <summary>
        /// this calls create Circle service
        /// </summary>
        public void CreateCircle()
        {
            double? radius = UserInput.ReadMeters("Enter radius in meters : ");

            if (radius == null)
            {
                return;
            }

            string? colour = UserInput.GetColor("Enter Color of the Circle : ");
            if (colour == null)
            {
                return;
            }

            Console.WriteLine(this._shapeService.CreateCircle(colour, (double)radius));
        }
    }
}
