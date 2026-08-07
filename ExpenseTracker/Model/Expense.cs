using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// Expense class
    /// </summary>
    internal class Expense
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="amount"> the amount of Expense</param>
        /// <param name="date">date of Expense</param>
        /// <param name="category">category of Expense</param>
        /// <param name="id">id of Expense</param>
        public Expense(string id, decimal amount, DateOnly date, ExpenseType category)
        {
            this.Id = id;
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets transaction Id
        /// </summary>
        /// <value>
        /// Transaction ID
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets transaction amount
        /// </summary>
        /// <value>
        /// Transaction amount
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date of transaction
        /// </summary>
        /// <value>
        /// date of transaction
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets Types of Expense
        /// </summary>
        /// <value>
        /// Type of Expense
        /// </value>
        public ExpenseType Category { get; set; }

        /// <summary>
        /// to clone the object
        /// </summary>
        /// <returns>returns the cloned object</returns>
        public Expense Clone()
        {
            return new Expense(this.Id, this.Amount, this.Date, this.Category);
        }
    }
}
