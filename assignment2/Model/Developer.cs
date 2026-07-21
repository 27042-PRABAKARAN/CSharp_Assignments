namespace Assignment2.Model
{
    /// <summary>
    /// Developer class inherited from Employee
    /// </summary>
    internal class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name"> the name of the employee </param>
        /// <param name="salary"> the salary of the employee</param>
        public Developer(string? name , double salary)
        {
           this.Name = name;
           this.Salary = salary;
        }

        /// <summary>
        /// Calculates the bonus of the developer
        /// </summary>
        public override void CalculateBonus()
        {
            this.Bonus = this.Salary * 0.2;
        }

        /// <summary>
        /// This prints the details of the Developer
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"Name : {this.Name} , Position :Developer , Salary : {this.Salary} , Bonus {this.Bonus}.");
        }
    }
}
