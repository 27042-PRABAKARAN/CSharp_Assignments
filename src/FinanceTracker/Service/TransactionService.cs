using FinanceTracker.Logger;
using FinanceTracker.Model;
using FinanceTracker.Model.Enums;
using FinanceTracker.Repository;

namespace FinanceTracker.Service
{
    /// <summary>
    /// Service for Transaction
    /// </summary>
    internal class TransactionService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="repository"> The instance of the repository</param>
        public TransactionService(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// To create a Transaction
        /// </summary>
        /// <param name="amount"> amount of income </param>
        /// <param name="date"> date of income </param>
        /// <param name="category"> category of Transaction </param>
        /// <param name="type"> type of income </param>
        public void CreateTransaction(decimal amount, DateOnly date, string category, TransactionType type)
        {
            TransactionInfo newTransaction = new (amount, Guid.NewGuid().ToString(), date, category, type);
            this._repository.AddTransaction(newTransaction);
        }

        /// <summary>
        /// To delete the Transaction
        /// </summary>
        /// <param name="id">the id of the expense to be deleted</param>
        /// <returns>status of delete</returns>
        public bool DeleteTransaction(string id)
        {
            return this._repository.DeleteTransaction(id);
        }

        /// <summary>
        /// To fetch all expenses
        /// </summary>
        /// <returns>list of expenses</returns>
        public IEnumerable<TransactionInfo> GetAllExpenses()
        {
            return this._repository.GetAllExpenses();
        }

        /// <summary>
        /// To fetch all expenses
        /// </summary>
        /// <returns>list of expenses</returns>
        public IEnumerable<TransactionInfo> GetAllIncomes()
        {
            return this._repository.GetAllIncomes();
        }

        /// <summary>
        /// To update Transaction Amount
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="amount"> the amount to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateTransactionAmount(string id, decimal amount)
        {
            TransactionInfo? updateRecord = this.GetTransactionById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Amount = amount;
            return this._repository.UpdateTransaction((TransactionInfo)updateRecord);
        }

        /// <summary>
        /// To update Transaction date
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="date"> the date to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateTransactionDate(string id, DateOnly date)
        {
            TransactionInfo? updateRecord = this.GetTransactionById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Date = date;
            return this._repository.UpdateTransaction((TransactionInfo)updateRecord);
        }

        /// <summary>
        /// To update Transaction category
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="category"> the category to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateTransactionCategory(string id, string category)
        {
            TransactionInfo? updateRecord = this.GetTransactionById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Category = category;
            return this._repository.UpdateTransaction((TransactionInfo)updateRecord);
        }

        /// <summary>
        /// To get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private TransactionInfo? GetTransactionById(string id)
        {
            TransactionInfo? transaction = this.GetAllExpenses().FirstOrDefault(transaction => transaction.Id.Equals(id));
            if (transaction == null)
            {
                transaction = this.GetAllIncomes().FirstOrDefault(transaction => transaction.Id.Equals(id));
            }

            return transaction;
        }
    }
}
