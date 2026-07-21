using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    /// <summary>
    /// Employee class
    /// </summary>
    internal abstract class Employee
    {
        /// <summary>
        /// Gets or sets the name of the employee
        /// </summary>
        /// <value>
        /// he name of the employee
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the salary of the Employee
        /// </summary>
        /// <value>
        /// holds the amount of salary the employee gets
        /// </value>
        public double Salary { get; set; }

        /// <summary>
        /// Gets or sets the bonus of the employee
        /// </summary>
        /// /// <value>
        /// holds the amount of bonus the employee gets
        /// </value>
        public double Bonus { get; set; }

        /// <summary>
        /// This calculates the bonus
        /// </summary>
        public abstract void CalculateBonus();

        /// <summary>
        /// this function prints the details of the Employee
        /// </summary>
        public virtual void PrintDetails()
        {
            Console.WriteLine($"Name : {this.Name} , Salary : {this.Salary} , Bonus {this.Bonus} .");
        }
    }
}
