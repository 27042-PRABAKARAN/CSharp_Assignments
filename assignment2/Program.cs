using Assignment2.View;

namespace Assignments
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
            //ShapesSystem shape = new ShapesSystem();
            //shape.ShapeOperations();

            //EmployeeSystem operations = new EmployeeSystem();
            //operations.EmployeeOperations();

            BankSystem bank = new BankSystem();
            bank.BankOperations();
        }
    }
}