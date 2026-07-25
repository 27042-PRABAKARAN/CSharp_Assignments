using Assignment2.Helper;
using Assignment2.Model;
using Assignment2.View;

namespace Assignment2
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"> if there are any terminal arguents</param>
        private static void Main(string[] args)
        {
            Output.Display("Hey User,");
            while (true)
            {
                Output.Display("========================\n1. Shape Hirearchy.\n2. Employee Hirearchy.\n3. BankSystem.\n4. Exit.\n========================");
                int? choice = UserInput.ReadInt("Enter the choice : ", 1, 4);
                if (choice == null)
                {
                    Output.Display("Exiting App");
                    break;
                }

                Applications app = (Applications)choice;
                switch (app)
                {
                    case Applications.ShapeHirearchy: ShapesSystem shape = new ShapesSystem(); shape.ShapeOperations(); break;
                    case Applications.EmployeeHirearchy: EmployeeSystem employee = new EmployeeSystem(); employee.EmployeeOperations(); break;
                    case Applications.BankSystem: BankSystem bankSystem = new BankSystem(); bankSystem.BankOperations(); break;
                    case Applications.Exit: Output.Display("Exiting"); return;
                    default: Output.Error("Enter a valid number"); break;
                }
            }
        }
    }
}