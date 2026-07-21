using Assignment2.Model;

namespace Assignment2.Service
{
    /// <summary>
    /// this class does the services for Employee
    /// </summary>
    internal class EmployeeServices
    {
        /// <summary>
        /// creates a developer
        /// </summary>
        /// <param name="name"> the name of the developer </param>
        /// <param name="salary"> the salary of the developer </param>
        public void CreateDeveloper(string? name, double salary)
        {
            Developer newDeveloper = new Developer(name, salary);
            newDeveloper.CalculateBonus();
            newDeveloper.PrintDetails();
        }

        /// <summary>
        /// creates a Manager
        /// </summary>
        /// <param name="name"> the name of the Manager </param>
        /// <param name="salary"> the salary of the Manager </param>
        public void CreateManager(string? name, double salary)
        {
            Manager newManager = new Manager(name, salary);
            newManager.CalculateBonus();
            newManager.PrintDetails();
        }
    }
}
