namespace ManagementSystem.Model.Employee
{
    /// <summary>
    /// Employee class
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name"> name of the employee</param>
        /// <param name="salary">salary of the employee</param>
        public Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Gets or sets the name of the employee
        /// </summary>
        /// <value>
        /// he name of the employee
        /// </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the salary of the Employee
        /// </summary>
        /// <value>
        /// holds the amount of salary the employee gets
        /// </value>
        public decimal Salary { get; set; } = decimal.Zero;

        /// <summary>
        /// Gets or sets the bonus of the employee
        /// </summary>
        /// <value>
        /// holds the amount of bonus the employee gets
        /// </value>
        public decimal Bonus { get; set; } = decimal.Zero;

        /// <summary>
        /// This calculates the bonus
        /// </summary>
        public abstract void CalculateBonus();

        /// <summary>
        /// this function prints the details of the Employee
        /// </summary>
        /// <returns> returns the details of class</returns>
        public virtual string? PrintDetails()
        {
            return $"Name : {this.Name} , Salary : {this.Salary} Rupees, Bonus : {this.Bonus} Rupees.";
        }
    }
}
