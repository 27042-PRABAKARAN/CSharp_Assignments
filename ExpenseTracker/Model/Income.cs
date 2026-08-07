using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// Income class
    /// </summary>
    internal class Income : ITransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="amount"> the amount of income</param>
        /// <param name="date">date of income</param>
        /// <param name="category">category of income</param>
        /// <param name="id">id of the income</param>
        public Income(string id, decimal amount, DateOnly date, Source category)
        {
            this.Amount = amount;
            this.Date = date;
            this.Category = category;
            this.Id = id;
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
        /// Gets or sets source of income
        /// </summary>
        /// <value>
        /// Source of income
        /// </value>
        public Source Category { get; set; }

        /// <summary>
        /// to clone the object
        /// </summary>
        /// <returns>returns the cloned object</returns>
        public Income Clone()
        {
            return new Income(this.Id, this.Amount, this.Date, this.Category);
        }
    }
}
