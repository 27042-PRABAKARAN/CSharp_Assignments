using FinanceTracker.Model.Enums;

namespace FinanceTracker.Model
{
    /// <summary>
    /// Transaction abstract class
    /// </summary>
    internal class TransactionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionInfo"/> class.
        /// </summary>
        /// <param name="amount"> amount of transaction </param>
        /// <param name="id"> id of transaction</param>
        /// <param name="date">date of transaction</param>
        /// <param name="category"> category of transaction</param>
        /// <param name="type">type transaction</param>
        public TransactionInfo(decimal amount, string id, DateOnly date, string category, TransactionType type)
        {
            this.Amount = amount;
            this.Category = category;
            this.Date = date;
            this.Id = id;
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets transaction amount
        /// </summary>
        /// <value>
        /// Transaction amount
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets transaction Id
        /// </summary>
        /// <value>
        /// Transaction ID
        /// </value>
        public string Id { get; init; }

        /// <summary>
        /// Gets the Type of Transaction
        /// </summary>
        /// <value>
        /// The Type of Transaction
        /// </value>
        public TransactionType Type { get; init; }

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

        /// <summary>
        /// To clone the object
        /// </summary>
        /// <returns>returns the cloned object</returns>
        public TransactionInfo Clone()
        {
            return new TransactionInfo(this.Amount, this.Id, this.Date, this.Category, this.Type);
        }
    }
}
