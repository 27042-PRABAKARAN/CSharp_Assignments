using ExpenseTracker.Model.Enums;

namespace ExpenseTracker.Model
{
    /// <summary>
    /// Income class
    /// </summary>
    internal class Income : TransactionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="amount"> the amount of income</param>
        /// <param name="date">date of income</param>
        /// <param name="category">category of income</param>
        /// <param name="id">id of the income</param>
        public Income(string id, decimal amount, DateOnly date, string category)
            : base(amount, id, date, category)
        {
        }

        /// <summary>
        /// To clone the object
        /// </summary>
        /// <returns>returns the cloned object</returns>
        public Income Clone()
        {
            return new Income(this.Id, this.Amount, this.Date, this.Category);
        }
    }
}
