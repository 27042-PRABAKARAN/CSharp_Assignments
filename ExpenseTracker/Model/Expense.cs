namespace ExpenseTracker.Model
{
    /// <summary>
    /// Expense class
    /// </summary>
    internal class Expense : TransactionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="amount"> the amount of Expense</param>
        /// <param name="date">date of Expense</param>
        /// <param name="category">category of Expense</param>
        /// <param name="id">id of Expense</param>
        public Expense(string id, decimal amount, DateOnly date, string category)
            : base(amount, id, date, category)
        {
        }

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
