using FinanceTracker.Model;
using FinanceTracker.Model.Enums;

namespace FinanceTracker.Repository
{
    /// <summary>
    /// In memory Repository
    /// </summary>
    internal class InMemoryRepository
        : IRepository
    {
        /// <summary>
        /// List of transactions
        /// </summary>
        private readonly List<TransactionInfo> _transactions = new ();

        /// <summary>
        /// To add a transaction
        /// </summary>
        /// <param name="transaction"> the transaction </param>
        public void AddTransaction(TransactionInfo transaction)
        {
            this._transactions.Add(transaction);
        }

        /// <summary>
        /// To remove the transaction.
        /// </summary>
        /// <param name="id">id of transaction</param>
        /// <returns>returns status of deleting</returns>
        public bool DeleteTransaction(string id)
        {
            TransactionInfo? deleteTransaction = this.GetTransactionById(id);
            if (deleteTransaction != null)
            {
                this._transactions.Remove(deleteTransaction);
                return true;
            }

            return false;
        }

        /// <summary>
        /// To get all the transaction
        /// </summary>
        /// <returns> list of transactions </returns>
        public IEnumerable<TransactionInfo> GetAllIncomes()
        {
            return this._transactions.Where(transaction => transaction.Type == TransactionType.Income).Select(transaction => transaction.Clone()).ToList();
        }

        /// <summary>
        /// To get all the transaction
        /// </summary>
        /// <returns> list of transactions </returns>
        public IEnumerable<TransactionInfo> GetAllExpenses()
        {
            return this._transactions.Where(transaction => transaction.Type == TransactionType.Expense).Select(transaction => transaction.Clone()).ToList();
        }

        /// <summary>
        /// To update the income record
        /// </summary>
        /// <param name="incomeRecord"> the updated record</param>
        /// <returns> status of update </returns>
        public bool UpdateTransaction(TransactionInfo incomeRecord)
        {
            TransactionInfo? updateRecord = this.GetTransactionById(incomeRecord.Id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Amount = incomeRecord.Amount;
            updateRecord.Date = incomeRecord.Date;
            updateRecord.Category = incomeRecord.Category;
            return true;
        }

        /// <summary>
        /// To check empty Income list
        /// </summary>
        /// <returns> status of the Income List</returns>
        public bool IsEmptyIncome()
        {
            return this._transactions.Where(transaction => transaction.Type == TransactionType.Income).ToList().Count == 0;
        }

        /// <summary>
        /// To check empty expensed
        /// </summary>
        /// <returns> status of Expense List</returns>
        public bool IsEmptyExpense()
        {
            return this._transactions.Where(transaction => transaction.Type == TransactionType.Expense).ToList().Count == 0;
        }

        /// <summary>
        /// To get total expense
        /// </summary>
        /// <returns> total expense </returns>
        public decimal GetTotalExpenses()
        {
            return this._transactions.Where(transaction => transaction.Type == TransactionType.Expense).ToList().Sum(entry => entry.Amount);
        }

        /// <summary>
        /// To get total expense
        /// </summary>
        /// <returns> total expense </returns>
        public decimal GetTotalIncomes()
        {
            return this._transactions.Where(transaction => transaction.Type == TransactionType.Income).ToList().Sum(entry => entry.Amount);
        }

        /// <summary>
        /// To get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private TransactionInfo? GetTransactionById(string id)
        {
            return this._transactions.Find(transaction => transaction.Id.Equals(id));
        }
    }
}
