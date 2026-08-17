namespace FinanceTracker.Model.Enums
{
    /// <summary>
    /// Type of transaction
    /// </summary>
    internal enum TransactionOptions
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
        /// Summary of Both Income and Expense
        /// </summary>
        Summary,

        /// <summary>
        /// Exit
        /// </summary>
        Exit,
    }
}
