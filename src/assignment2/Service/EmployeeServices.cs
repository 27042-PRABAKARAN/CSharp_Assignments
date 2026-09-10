using ManagementSystem.Model.Employee;

namespace ManagementSystem.Service
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
        /// <returns> returns details after creating </returns>
        public string CreateDeveloper(string name, decimal salary)
        {
            Developer newDeveloper = new Developer(name, salary);
            newDeveloper.CalculateBonus();
            return newDeveloper.PrintDetails();
        }

        /// <summary>
        /// creates a Manager
        /// </summary>
        /// <param name="name"> the name of the Manager </param>
        /// <param name="salary"> the salary of the Manager </param>
        /// <returns> returns details after creating </returns>
        public string CreateManager(string name, decimal salary)
        {
            Manager newManager = new Manager(name, salary);
            newManager.CalculateBonus();
            return newManager.PrintDetails();
        }
    }
}
