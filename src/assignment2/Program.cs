using ManagementSystem.Helper;
using ManagementSystem.Model;
using ManagementSystem.Service;
using ManagementSystem.View;

namespace ManagementSystem
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"> If there are any terminal arguments</param>
        private static void Main(string[] args)
        {
            Console.WriteLine("Hey User,");
            ShapeService shapeService = new ShapeService();
            EmployeeServices employeeServices = new EmployeeServices();
            BankService bankService = new BankService();
            ShapesSystem shape = new ShapesSystem(shapeService);
            EmployeeSystem employee = new EmployeeSystem(employeeServices);
            BankSystem bankSystem = new BankSystem(bankService);
            while (true)
            {
                Console.WriteLine(@"========================
1. Shape Hierarchy.
2. Employee Hierarchy.
3. BankSystem.
4. Exit.
========================");
                int? choice = UserInput.ReadInt("Enter the choice : ", 1, 4);
                if (choice == null)
                {
                    Console.WriteLine("Exiting App");
                    break;
                }

                Applications app = (Applications)choice;
                switch (app)
                {
                    case Applications.ShapeHierarchy:
                        {
                            shape.ShapeOperations();
                            break;
                        }

                    case Applications.EmployeeHierarchy:
                        {
                            employee.EmployeeOperations();
                            break;
                        }

                    case Applications.BankSystem:
                        {
                            bankSystem.BankOperations();
                            break;
                        }

                    case Applications.Exit:
                        {
                            Console.WriteLine("Exiting");
                            return;
                        }

                    default:
                        {
                            Output.Error("Enter a valid number");
                            break;
                        }
                }
            }
        }
    }
}