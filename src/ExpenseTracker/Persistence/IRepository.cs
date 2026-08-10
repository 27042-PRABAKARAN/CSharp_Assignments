using ExpenseTracker.Model;

namespace ExpenseTracker.Persistence
{
    /// <summary>
    /// Defines data operations for managing incomes and expenses.
    /// </summary>
    internal interface IRepository
    {
        /// <summary>
        /// Adds a new income transaction.
        /// </summary>
        /// <param name="transaction"> transaction to be added</param>
        void AddIncome(Income transaction);

        /// <summary>
        /// Adds a new expense transaction.
        /// </summary>
        /// <param name="transaction"> transaction to be added</param>
        void AddExpense(Expense transaction);

        /// <summary>
        /// Removes an income transaction by its identifier.
        /// </summary>
        /// <returns> status of delete</returns>
        /// <param name="id"> id of income</param>
        bool DeleteIncome(string id);

        /// <summary>
        /// Removes an expense transaction by its identifier.
        /// </summary>
        /// <returns> status of delete</returns>
        /// <param name="id"> id of income</param>
        bool DeleteExpense(string id);

        /// <summary>
        /// To check empty Income list
        /// </summary>
        /// <returns> status of the Income List</returns>
        public bool IsEmptyIncome();

        /// <summary>
        /// To check empty expensed
        /// </summary>
        /// <returns> status of Expense List</returns>
        public bool IsEmptyExpense();

        /// <summary>
        /// To update the income record
        /// </summary>
        /// <param name="incomeRecord"> the updated record</param>
        /// <returns> status of update </returns>
        public bool UpdateIncome(Income incomeRecord);

        /// <summary>
        /// To update the expense record
        /// </summary>
        /// <param name="expenseRecord"> the updated record</param>
        /// <returns> status of update</returns>
        public bool UpdateExpense(Expense expenseRecord);

        /// <summary>
        /// To fetch all income
        /// </summary>
        /// <returns> list of incomes</returns>
        public IEnumerable<Income> GetAllIncomes();

        /// <summary>
        /// To fetch all expense
        /// </summary>
        /// <returns>list of expense</returns>
        public IEnumerable<Expense> GetAllExpenses();

        /// <summary>
        /// To get total expense
        /// </summary>
        /// <returns> total expense </returns>
        public decimal GetTotalExpenses();

        /// <summary>
        /// To get total Income
        /// </summary>
        /// <returns> total Income </returns>
        public decimal GetTotalIncomes();
    }
}