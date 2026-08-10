using ExpenseTracker.Model;
using ExpenseTracker.Model.Enums;
using ExpenseTracker.Persistence;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// Services provided for Income
    /// </summary>
    internal class IncomeService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeService"/> class.
        /// </summary>
        /// <param name="repository"> the instance of the repository</param>
        public IncomeService(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// to create an income
        /// </summary>
        /// <param name="amount"> amount of income </param>
        /// <param name="date"> date of income </param>
        /// <param name="type"> type of income </param>
        public void CreateIncome(decimal amount, DateOnly date, IncomeType type)
        {
            Income newIncome = new Income(Guid.NewGuid().ToString(), amount, date, type.ToString());
            this._repository.AddIncome(newIncome);
        }

        /// <summary>
        /// to delete the income
        /// </summary>
        /// <param name="id">id of the record to be deleted </param>
        /// <returns> status of delete </returns>
        public bool DeleteIncome(string id)
        {
            return this._repository.DeleteIncome(id);
        }

        /// <summary>
        /// to check if the income is empty
        /// </summary>
        /// <returns> status of income </returns>
        public bool IsEmptyIncome()
        {
            return this._repository.IsEmptyIncome();
        }

        /// <summary>
        /// to fetch all expenses
        /// </summary>
        /// <returns>list of expenses</returns>
        public IEnumerable<Income> GetAllIncomes()
        {
            return this._repository.GetAllIncomes();
        }

        /// <summary>
        /// to update income
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="amount"> the amount to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateIncomeAmount(string id, decimal amount)
        {
            Income? updateRecord = this.GetIncomeById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Amount = amount;
            return this._repository.UpdateIncome((Income)updateRecord);
        }

        /// <summary>
        /// to update income
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="date"> the date to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateIncomeDate(string id, DateOnly date)
        {
            Income? updateRecord = this.GetIncomeById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Date = date;
            return this._repository.UpdateIncome((Income)updateRecord);
        }

        /// <summary>
        /// to update income
        /// </summary>
        /// <param name="id"> id of the record</param>
        /// <param name="category"> the category to be updated </param>
        /// <returns> status of update </returns>
        public bool UpdateIncomeCategory(string id, string category)
        {
            Income? updateRecord = this.GetIncomeById(id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Category = category;
            return this._repository.UpdateIncome((Income)updateRecord);
        }

        /// <summary>
        /// to get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private Income? GetIncomeById(string id)
        {
            return this.GetAllIncomes().FirstOrDefault(transaction => transaction.Id.Equals(id));
        }
    }
}
