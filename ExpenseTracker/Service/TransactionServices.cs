using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Model;
using ExpenseTracker.Persistence;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// services of transactions
    /// </summary>
    internal class TransactionServices
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionServices"/> class.
        /// </summary>
        /// <param name="repository"> the instance of the repository</param>
        public TransactionServices(IRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// to create an income
        /// </summary>
        /// <param name="amount"> amount of income </param>
        /// <param name="date"> date of income </param>
        /// <param name="type"> type of income </param>
        public void CreateIncome(decimal amount, DateOnly date, Source type)
        {
            Income newIncome = new Income(Guid.NewGuid().ToString(), amount, date, type.ToString());
            this._repository.AddIncome(newIncome);
        }

        /// <summary>
        /// to create an income
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
        /// to delete the income
        /// </summary>
        /// <param name="id">id of the record to be deleted </param>
        /// <returns> status of delete </returns>
        public bool DeleteIncome(string id)
        {
            return this._repository.DeleteIncome(id);
        }

        /// <summary>
        /// to delete the expense
        /// </summary>
        /// <param name="id">the id of the expense to be deleted</param>
        /// <returns>status of delete</returns>
        public bool DeleteExpense(string id)
        {
            return this._repository.DeleteExpense(id);
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
        /// check if the expense is empty
        /// </summary>
        /// <returns> status of expense </returns>
        public bool IsEmptyExpense()
        {
            return this._repository.IsEmptyExpense();
        }

        /// <summary>
        /// to fetch all expenses
        /// </summary>
        /// <returns>list of expenses</returns>
        public List<Expense> GetAllExpenses()
        {
            return this._repository.GetAllExpenses();
        }

        /// <summary>
        /// to fetch all expenses
        /// </summary>
        /// <returns>list of expenses</returns>
        public List<Income> GetAllIncomes()
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
        /// to update Expense
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
        /// to update Expense
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
        /// to updateExpense
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
        /// to get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private Income? GetIncomeById(string id)
        {
            return this.GetAllIncomes().Find(transaction => transaction.Id.Equals(id));
        }

        /// <summary>
        /// to get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private Expense? GetExpenseById(string id)
        {
            return this.GetAllExpenses().Find(transaction => transaction.Id.Equals(id));
        }
    }
}
