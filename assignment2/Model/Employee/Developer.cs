namespace Assignment2.Model.Employee
{
    /// <summary>
    /// Developer class inherited from Employee
    /// </summary>
    internal class Developer : Employee
    {
        private double _bonusPercentage = 0.2;

        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name"> the name of the employee </param>
        /// <param name="salary"> the salary of the employee</param>
        public Developer(string? name, double? salary)
        {
           this.Name = name;
           this.Salary = salary;
        }

        /// <summary>
        /// Calculates the bonus of the developer
        /// </summary>
        public override void CalculateBonus()
        {
            this.Bonus = this.Salary * this._bonusPercentage;
        }

        /// <summary>
        /// This prints the details of the Developer
        /// </summary>
        /// <returns> returns the string </returns>
        public override string? PrintDetails()
        {
            return $"\nName : {this.Name}\nPosition :Developer\nSalary : {this.Salary} Rupees\nBonus : {this.Bonus} Rupees.\n";
        }
    }
}
