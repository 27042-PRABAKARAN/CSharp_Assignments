namespace ExpenseTracker.Model.Enums
{
    /// <summary>
    /// Transaction abstract class
    /// </summary>
    internal abstract class TransactionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="amount"> amount of transaction </param>
        /// <param name="id"> id of transaction</param>
        /// <param name="date">date of transaction</param>
        /// <param name="category"> category of transaction</param>
        protected TransactionInfo(decimal amount, string id, DateOnly date, string category)
        {
            this.Amount = amount;
            this.Category = category;
            this.Date = date;
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets transaction amount
        /// </summary>
        /// <value>
        /// Transaction amount
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets transaction Id
        /// </summary>
        /// <value>
        /// Transaction ID
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date of transaction
        /// </summary>
        /// <value>
        /// date of transaction
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the category of the transaction
        /// </summary>
        /// <value> type of transaction </value>
        public string Category { get; set; }
    }
}
