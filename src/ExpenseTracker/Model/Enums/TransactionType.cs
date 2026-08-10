namespace ExpenseTracker.Model.Enums
{
    /// <summary>
    /// Type of transaction
    /// </summary>
    internal enum TransactionType
    {
        /// <summary>
        /// Income Type
        /// </summary>
        Income = 1,

        /// <summary>
        /// Expense Type
        /// </summary>
        Expense,

        /// <summary>
        /// summary of Both Income and Expense
        /// </summary>
        Summary,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
