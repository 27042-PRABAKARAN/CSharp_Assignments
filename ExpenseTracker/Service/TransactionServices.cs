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
            Income newIncome = new Income(Guid.NewGuid().ToString(), amount, date, type);
            this._repository.AddIncome(newIncome);
        }

        /// <summary>
        /// to create an income
        /// </summary>
        /// <param name="amount"> amount of income </param>
        /// <param name="date"> date of income </param>
        /// <param name="type"> type of income </param>
        public void CreateExpense(decimal amount, DateOnly date, Source type)
        {
            Income newIncome = new Income(Guid.NewGuid().ToString(), amount, date, type);
            this._repository.AddIncome(newIncome);
        }
    }
}
