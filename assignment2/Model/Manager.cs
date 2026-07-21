namespace Assignment2.Model
{
    /// <summary>
    /// Developer class inherited from Employee
    /// </summary>
    internal class Manager : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Manager"/> class.
        /// </summary>
        /// <param name="name"> the name of the employee </param>
        /// <param name="salary"> the salary of the employee</param>
        public Manager(string? name, double salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Calculates the bonus of the developer
        /// </summary>
        public override void CalculateBonus()
        {
            this.Bonus = this.Salary * 0.3;
        }

        /// <summary>
        /// This prints the details of the manager
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"Name : {this.Name} , Position : Manager , Salary : {this.Salary} , Bonus {this.Bonus} .");
        }
    }
}
