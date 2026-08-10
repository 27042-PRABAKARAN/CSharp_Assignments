namespace ExpenseTracker.Model.Enums
{
    /// <summary>
    /// Enum for source of income
    /// </summary>
    internal enum IncomeType
    {
        /// <summary>
        /// Salary as income source
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
        /// Any other income source
        /// </summary>
        Others,
    }
}
