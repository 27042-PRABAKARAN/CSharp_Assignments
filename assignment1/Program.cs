using Assignment1.Helper;

namespace Assignment1
{
    /// <summary>
    /// Enum Operations created
    /// </summary>
    /// <value>
    /// Converts user choice to meaningful operations
    /// </value>
    internal enum Operation
    {
        /// <summary>
        /// Add operation
        /// </summary>
        Add = 1,

        /// <summary>
        /// View Operation
        /// </summary>
        View,

        /// <summary>
        /// Search Operation
        /// </summary>
        Search,

        /// <summary>
        /// Edit operation
        /// </summary>
        Edit,

        /// <summary>
        /// Delete operation
        /// </summary>
        Delete,

        /// <summary>
        /// Exiting
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Service object for service class
        /// </summary>
        private static readonly UserOperation _userOperation = new UserOperation();

        private static void Main(string[] args)
        {
            bool endApp = false;
            Output.Display("Welcome to contact manager");
            while (!endApp)
            {
                _userOperation.PrintOperationsAvailable();
                Output.Display("Enter a Number of the choice : ");
                string? choice = UserInput.ReadInput();
                if (choice == null)
                {
                    Output.PrintRed("Enter a valid choice");
                    continue;
                }

                int.TryParse(choice, out int index);
                Operation operation = (Operation)index;
                switch (operation)
                {
                    case Operation.Add: _userOperation.AddContacts(); break;
                    case Operation.View: _userOperation.ViewContacts(); break;
                    case Operation.Search: _userOperation.SearchContact(); break;
                    case Operation.Edit: _userOperation.EditContact(); break;
                    case Operation.Delete: _userOperation.DeleteContact(); break;
                    case Operation.Exit: endApp = true; break;
                    default:
                    {
                        Output.PrintRed("Enter a valid choice");
                        break;
                    }
                }
            }
        }
    }
}