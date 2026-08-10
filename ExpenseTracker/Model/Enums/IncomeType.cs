namespace ExpenseTracker.Model
{
    /// <summary>
    /// enum for source of income
    /// </summary>
    internal enum IncomeType
    {
        /// <summary>
        /// salary as income source
        /// </summary>
        Salary = 1,

        /// <summary>
        /// Investments returns as income source
        /// </summary>
        InvestmentReturns,

        /// <summary>
        /// Bonus as income source
        /// </summary>
        Bonus,

        /// <summary>
        /// any other income source
        /// </summary>
        Others,
    }
}
