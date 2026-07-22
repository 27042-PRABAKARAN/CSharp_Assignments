using Assignment2.Helper;
using Assignment2.Service;

namespace Assignment2.View
{
    /// <summary>
    /// the View class of Employee
    /// </summary>
    internal class EmployeeSystem
    {
        /// <summary>
        /// instance of the _shapeService
        /// </summary>
        private readonly EmployeeServices _employeeServices = new EmployeeServices();

        /// <summary>
        /// Operation enumerator
        /// </summary>
        internal enum Operation
        {
            /// <summary>
            /// to create a developer
            /// </summary>
            CreateDeveloper = 1,

            /// <summary>
            /// to create a Manager
            /// </summary>
            CreateManager,

            /// <summary>
            /// to exit the app
            /// </summary>
            Exit,
        }

        /// <summary>
        /// Function that starts the app
        /// </summary>
        public void EmployeeOperations()
        {
            Output.Display("Welcome to Employee Management System :  ");
            while (true)
            {
                Output.Display("1. Create A Developer.\n2. Create a Manager.\n3. Exit the app");
                string? userInput = UserInput.ReadInput("Enter the number: ");
                int index;
                int.TryParse(userInput, out index);
                Operation operation = (Operation)index;
                switch (operation)
                {
                    case Operation.CreateDeveloper: this.CreateDeveloper(); break;
                    case Operation.CreateManager: this.CreateManager(); break;

                    case Operation.Exit: return;

                    default: Output.Error("enter valid choice"); break;
                }
            }
        }

        /// <summary>
        /// creates manager
        /// </summary>
        public void CreateManager()
        {
            string? name = UserInput.ReadInput("Enter Name of the Manager: ");
            if (!double.TryParse(UserInput.ReadInput("Enter Name of the Manager: "), out double salaryDouble) || salaryDouble <= 0)
            {
                Output.Error("Invalid Salary. Please enter a positive number.");
            }

            Output.Display(this._employeeServices.CreateManager(name, salaryDouble));
        }

        /// <summary>
        /// creates Developer
        /// </summary>
        public void CreateDeveloper()
        {
            string? name = UserInput.ReadInput("Enter Name of the Developer: ");
            if (!double.TryParse(UserInput.ReadInput("Enter Salary of the Developer: "), out double salaryDouble) || salaryDouble <= 0)
            {
                Output.Display("Invalid Salary. Please enter a positive number.");
            }

            Output.Display(this._employeeServices.CreateDeveloper(name, salaryDouble));
        }
    }
}
