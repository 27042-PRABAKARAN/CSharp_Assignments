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
        /// Function that starts the app
        /// </summary>
        public void ShapeOperations()
        {
            Output.Display("Welcome to Shapes ");
            while (true)
            {
                Output.Display("========================\n1. Create A Rectangle.\n2. Create A Circle.\n3. Exit the app\n========================");
                int? index = UserInput.ReadInt("Enter the choice: ", 1, 3);
                if (index == null)
                {
                    Output.Display("reteurning to mainmenu");
                    return;
                }

                Operation operation = (Operation)index;
                switch (operation)
                {
                    case Operation.CreateRectangle: this.CreateRectangle(); break;
                    case Operation.CreateCircle: this.CreateCircle(); break;
                    case Operation.Exit: return;
                    default: Output.Error("enter valid choice"); break;
                }
            }
        }

        /// <summary>
        /// this calls create rectangle service
        /// </summary>
        public void CreateRectangle()
        {
            double? length = UserInput.ReadMetres("Enter length in meters : ");

            if (length == null)
            {
                return;
            }

            double? width = UserInput.ReadMetres("Enter width in meters : ");

            if (width == null)
            {
                return;
            }

            string? colour = UserInput.GetColour("Enter Colour of the Rectangle: ");
            if (colour == null)
            {
                return;
            }

            Output.Display(this._shapeService.CreateRectangle(colour, width, length));
        }

        /// <summary>
        /// this calls create Circle service
        /// </summary>
        public void CreateCircle()
        {
            double? radius = UserInput.ReadMetres("Enter radius in meters : ");

            if (radius == null)
            {
                return;
            }

            string? colour = UserInput.GetColour("Enter Colour of the Circle : ");
            if (colour == null)
            {
                return;
            }

            Output.Display(this._shapeService.CreateCircle(colour, radius));
        }
    }
}
