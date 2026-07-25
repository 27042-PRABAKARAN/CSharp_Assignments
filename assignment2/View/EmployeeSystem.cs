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
        /// Function that starts the app
        /// </summary>
        public void EmployeeOperations()
        {
            Output.Display("Welcome to Employee Management System :  ");
            while (true)
            {
                Output.Display("========================\n1. Create A Developer.\n2. Create a Manager.\n3. Exit the app.\n========================\n");
                int? index = UserInput.ReadInt("Enter the choice: ", 1, 3);
                if (index == null)
                {
                    Output.Display("reteurning to mainmenu");
                    return;
                }

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
            double? salary = UserInput.ReadSalary("Enter the Salary of the Manager in Rupees : ");
            if (salary == null)
            {
                return;
            }

            Output.Display(this._employeeServices.CreateManager(name, salary));
        }

        /// <summary>
        /// creates Developer.
        /// </summary>
        public void CreateDeveloper()
        {
            string? name = UserInput.ReadInput("Enter Name of the Developer: ");
            double? salary = UserInput.ReadSalary("Enter the Salary of the Developer in Rupees : ");
            if (salary == null)
            {
                return;
            }

            Output.Display(this._employeeServices.CreateDeveloper(name, salary));
        }
    }
}
