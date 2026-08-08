using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ExpenseTracker.Model;

namespace ExpenseTracker.Persistence
{
    /// <summary>
    /// In memory Repository
    /// </summary>
    internal class InMemoryRepository
        : IRepository
    {
        /// <summary>
        /// list of transactions
        /// </summary>
        private readonly List<Income> _incomeTransactions = new List<Income>();

        /// <summary>
        /// list of transactions
        /// </summary>
        private readonly List<Expense> _expenseTransactions = new List<Expense>();

        /// <summary>
        /// to add a transaction
        /// </summary>
        /// <param name="transaction"> the transaction </param>
        public void AddIncome(Income transaction)
        {
            this._incomeTransactions.Add(transaction);
        }

        /// <summary>
        /// to add a transaction
        /// </summary>
        /// <param name="transaction"> the transaction </param>
        public void AddExpense(Expense transaction)
        {
            this._expenseTransactions.Add(transaction);
        }

        /// <summary>
        /// to remove the transaction.
        /// </summary>
        /// <param name="id">id of transaction</param>
        /// <returns>returns status of deleting</returns>
        public bool DeleteIncome(string id)
        {
            Income? deleteIncome = this.GetIncomeById(id);
            if (deleteIncome != null)
            {
                this._incomeTransactions.Remove(deleteIncome);
                return true;
            }

            return false;
        }

        /// <summary>
        /// to remove the transaction.
        /// </summary>
        /// <param name="id">id of transaction</param>
        /// <returns>returns status of deleting</returns>
        public bool DeleteExpense(string id)
        {
            Expense? deleteExpense = this.GetExpenseById(id);
            if (deleteExpense != null)
            {
                this._expenseTransactions.Remove(deleteExpense);
                return true;
            }

            return false;
        }

        /// <summary>
        /// to get all the transaction
        /// </summary>
        /// <returns> list of transactions </returns>
        public List<Income> GetAllIncomes()
        {
            return this._incomeTransactions.Select(transaction => transaction.Clone()).ToList();
        }

        /// <summary>
        /// to get all the transaction
        /// </summary>
        /// <returns> list of transactions </returns>
        public List<Expense> GetAllExpenses()
        {
            return this._expenseTransactions.Select(transaction => transaction.Clone()).ToList();
        }

        /// <summary>
        /// to update the income record
        /// </summary>
        /// <param name="incomeRecord"> the updated record</param>
        /// <returns> status of update </returns>
        public bool UpdateIncome(Income incomeRecord)
        {
            Income? updateRecord = this.GetIncomeById(incomeRecord.Id);
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
        /// to update the expense record
        /// </summary>
        /// <param name="expenseRecord"> the updated record</param>
        /// <returns> status of update</returns>
        public bool UpdateExpense(Expense expenseRecord)
        {
            Expense? updateRecord = this.GetExpenseById(expenseRecord.Id);
            if (updateRecord == null)
            {
                return false;
            }

            updateRecord.Amount = expenseRecord.Amount;
            updateRecord.Date = expenseRecord.Date;
            updateRecord.Category = expenseRecord.Category;
            return true;
        }

        /// <summary>
        /// to check empty Income list
        /// </summary>
        /// <returns> status of the Income List</returns>
        public bool IsEmptyIncome()
        {
            return this._incomeTransactions.Count == 0;
        }

        /// <summary>
        /// to check empty expensed
        /// </summary>
        /// <returns> status of Expense List</returns>
        public bool IsEmptyExpense()
        {
            return this._expenseTransactions.Count == 0;
        }

        /// <summary>
        /// to get total expense
        /// </summary>
        /// <returns> total expense </returns>
        public decimal GetTotalExpenses()
        {
            return this._expenseTransactions?
              .Where(e => e != null)
              .Sum(e => e.Amount) ?? 0m;
        }

        /// <summary>
        /// to get total expense
        /// </summary>
        /// <returns> total expense </returns>
        public decimal GetTotalIncomes()
        {
            return this._incomeTransactions?
              .Where(e => e != null)
              .Sum(e => e.Amount) ?? 0m;
        }

        /// <summary>
        /// to get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private Income? GetIncomeById(string id)
        {
            return this._incomeTransactions.Find(transaction => transaction.Id.Equals(id));
        }

        /// <summary>
        /// to get transaction by id
        /// </summary>
        /// <param name="id"> id of the transaction </param>
        /// <returns> returns list of transaction </returns>
        private Expense? GetExpenseById(string id)
        {
            return this._expenseTransactions.Find(transaction => transaction.Id.Equals(id));
        }
    }
}
