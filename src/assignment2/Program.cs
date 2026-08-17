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
            bool state = true;
            while (state)
            {
                try
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

                    Application app = (Application)choice;
                    switch (app)
                    {
                        case Application.ShapeHierarchy:
                            {
                                shape.ShapeOperations();
                                break;
                            }

                        case Application.EmployeeHierarchy:
                            {
                                employee.EmployeeOperations();
                                break;
                            }

                        case Application.BankSystem:
                            {
                                bankSystem.BankOperations();
                                break;
                            }

                        case Application.Exit:
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
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}