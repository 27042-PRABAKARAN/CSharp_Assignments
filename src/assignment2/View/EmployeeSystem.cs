using ManagementSystem.Helper;
using ManagementSystem.Model.Employee;
using ManagementSystem.Service;

namespace ManagementSystem.View
{
    /// <summary>
    /// the View class of Employee
    /// </summary>
    internal class EmployeeSystem
    {
        /// <summary>
        /// instance of the _shapeService
        /// </summary>
        private readonly EmployeeServices _employeeServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeSystem"/> class.
        /// </summary>
        /// <param name="employeeServices"> employee services object</param>
        public EmployeeSystem(EmployeeServices employeeServices)
        {
            this._employeeServices = employeeServices;
        }

        /// <summary>
        /// Function that starts the app
        /// </summary>
        public void EmployeeOperations()
        {
            Console.WriteLine("Welcome to Employee Management System :  ");
            while (true)
            {
                Console.WriteLine("========================\n1. Create A Developer.\n2. Create a Manager.\n3. Exit the app.\n========================\n");
                int? index = UserInput.ReadInt("Enter the choice: ", 1, 3);
                if (index == null)
                {
                    Console.WriteLine("returning to main menu");
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
            if (name == null)
            {
                return;
            }

            decimal? salary = UserInput.ReadSalary("Enter the Salary of the Manager in Rupees : ");
            if (salary == null)
            {
                return;
            }

            Console.WriteLine(this._employeeServices.CreateManager(name, (decimal)salary));
        }

        /// <summary>
        /// creates Developer.
        /// </summary>
        public void CreateDeveloper()
        {
            string? name = UserInput.ReadInput("Enter Name of the Developer: ");
            if (name == null)
            {
                return;
            }

            decimal? salary = UserInput.ReadSalary("Enter the Salary of the Developer in Rupees : ");
            if (salary == null)
            {
                return;
            }

            Console.WriteLine(this._employeeServices.CreateDeveloper(name, (decimal)salary));
        }
    }
}
