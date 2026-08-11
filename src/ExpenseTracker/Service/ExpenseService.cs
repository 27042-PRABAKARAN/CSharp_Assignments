using ExpenseTracker.Model;
using ExpenseTracker.Model.Enums;
using ExpenseTracker.Persistence;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Service for Expense
    /// </summary>
    internal class ExpenseService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseService"/> class.
        /// </summary>
        /// <param name="repository"> The instance of the repository</param>
        public ExpenseService(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// To create an Expense
        /// </summary>
        /// <param name="amount"> amount of income </param>
        /// <param name="date"> date of income </param>
        /// <param name="type"> type of income </param>
        public void CreateExpense(decimal amount, DateOnly date, ExpenseType type)
        {
            Expense newExpense = new Expense(Guid.NewGuid().ToString(), amount, date, type.ToString());
            this._repository.AddExpense(newExpense);
        }

        /// <summary>
        /// To delete the expense
        /// </summary>
        /// <param name="id">the id of the expense to be deleted</param>
        /// <returns>status of delete</returns>
        public bool DeleteExpense(string id)
        {
            return this._repository.DeleteExpense(id);
        }

        /// <summary>
        /// Check if the expense is empty
        /// </summary>
        /// <returns> status of expense </returns>
        public bool IsEmptyExpense()
        {
            return this._repository.IsEmptyExpense();
        }

        /// <summary>
        /// To fetch all expenses
        /// </summary>
        /// <returns>list of expenses</returns>
        public IEnumerable<Expense> GetAllExpenses()
        {
            return this._repository.GetAllExpenses();
        }

        /// <summary>
        /// To update Expense
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="amount"> the amount to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateExpenseAmount(string id, decimal amount)
        {
            Expense? updateRecord = this.GetExpenseById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Amount = amount;
            return this._repository.UpdateExpense((Expense)updateRecord);
        }

        /// <summary>
        /// To update Expense date
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="date"> the date to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateExpenseDate(string id, DateOnly date)
        {
            Expense? updateRecord = this.GetExpenseById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Date = date;
            return this._repository.UpdateExpense((Expense)updateRecord);
        }

        /// <summary>
        /// To update Expense category
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="category"> the category to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateExpenseCategory(string id, string category)
        {
            Expense? updateRecord = this.GetExpenseById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Category = category;
            return this._repository.UpdateExpense((Expense)updateRecord);
        }

        /// <summary>
        /// To get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private Expense? GetExpenseById(string id)
        {
            return this.GetAllExpenses().FirstOrDefault(transaction => transaction.Id.Equals(id));
        }
    }
}
