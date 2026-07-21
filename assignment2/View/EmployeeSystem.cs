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
            Console.WriteLine("Welcome to Employee Management System :  ");
            while (true)
            {
                Console.WriteLine("1. Create A Developer.\n2. Create a Manager.\n3. Exit the app");
                Console.Write("Enter the number: ");
                string? userInput = Console.ReadLine();
                if (!Input.IsNull(userInput))
                {
                    Console.WriteLine("Enter a valid inpu : ");
                    return;
                }
                else
                {
                    int index;
                    int.TryParse(userInput, out index);
                    Operation operation = (Operation)index;
                    switch (operation)
                    {
                        case Operation.CreateDeveloper:
                            {
                                Console.Write("Enter Name of the Developer: ");
                                string? name = Console.ReadLine();
                                if (!Input.IsNull(name))
                                {
                                    Console.WriteLine("Enter a valid input");
                                    break;
                                }

                                Console.Write("Enter Salary of the Developer: ");
                                if (!double.TryParse(Console.ReadLine(), out double salaryDouble) || salaryDouble <= 0)
                                {
                                    Console.WriteLine("Invalid Salary. Please enter a positive number.");
                                    break;
                                }

                                this._employeeServices.CreateDeveloper(name, salaryDouble);
                                break;
                            }

                        case Operation.CreateManager:
                            {
                                Console.Write("Enter Name of the Manager: ");
                                string? name = Console.ReadLine();
                                if (!Input.IsNull(name))
                                {
                                    Console.WriteLine("Enter a valid input");
                                    break;
                                }

                                Console.Write("Enter Salary of the Manager: ");
                                if (!double.TryParse(Console.ReadLine(), out double salaryDouble) || salaryDouble <= 0)
                                {
                                    Console.WriteLine("Invalid Salary. Please enter a positive number.");
                                    break;
                                }

                                this._employeeServices.CreateManager(name, salaryDouble);
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
