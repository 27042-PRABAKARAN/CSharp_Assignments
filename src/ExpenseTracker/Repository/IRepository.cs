using ExpenseTracker.Model;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Defines data operations for managing incomes and expenses.
    /// </summary>
    internal interface IRepository
    {
        /// <summary>
        /// To add a transaction
        /// </summary>
        /// <param name="transaction"> the transaction </param>
        public void AddTransaction(Transaction transaction);

        /// <summary>
        /// To remove the transaction.
        /// </summary>
        /// <param name="id">id of transaction</param>
        /// <returns>returns status of deleting</returns>
        public bool DeleteTransaction(string id);

        /// <summary>
        /// To get all the transaction
        /// </summary>
        /// <returns> list of transactions </returns>
        public IEnumerable<Transaction> GetAllIncomes();

        /// <summary>
        /// To get all the transaction
        /// </summary>
        /// <returns> list of transactions </returns>
        public IEnumerable<Transaction> GetAllExpenses();

        /// <summary>
        /// To update the income record
        /// </summary>
        /// <param name="incomeRecord"> the updated record</param>
        /// <returns> status of update </returns>
        public bool UpdateTransaction(Transaction incomeRecord);

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
        /// To get total expense
        /// </summary>
        /// <returns> total expense </returns>
        public decimal GetTotalExpenses();

        /// <summary>
        /// To get total expense
        /// </summary>
        /// <returns> total expense </returns>
        public decimal GetTotalIncomes();
    }
}