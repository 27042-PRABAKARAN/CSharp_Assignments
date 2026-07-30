using Assignment1.Helper;
using Assignment1.Model;

namespace Assignment1
{
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
                    Output.Error("Enter a valid choice");
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
                            Output.Error("Enter a valid choice");
                            break;
                        }
                }
            }
        }
    }
}