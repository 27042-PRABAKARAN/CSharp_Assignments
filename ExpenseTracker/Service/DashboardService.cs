using ExpenseTracker.Persistence;

namespace ExpenseTracker.Service
{
    /// <summary>
    /// services of transactions
    /// </summary>
    internal class DashboardService
    {
        private readonly IRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardService"/> class.
        /// </summary>
        /// <param name="repository"> the instance of the repository</param>
        public DashboardService(IRepository repository)
        {
            this._repository = repository;
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
        /// to get total expense
        /// </summary>
        /// <returns> total expense</returns>
        public decimal GetTotalExpense()
        {
            return this._repository.GetTotalExpenses();
        }

        /// <summary>
        /// to get total expense
        /// </summary>
        /// <returns> total expense</returns>
        public decimal GetTotalIncome()
        {
            return this._repository.GetTotalIncomes();
        }

        /// <summary>
        /// to get the summary details
        /// </summary>
        /// <returns> summary </returns>
        public string GetSummary()
        {
            decimal income = this.GetTotalIncome();
            decimal expense = this.GetTotalExpense();
            if (income >= expense)
            {
                return $"You have saved {income - expense} Rupees";
            }
            else
            {
                return $"You have exceeded {expense - income} Rupees";
            }
        }
    }
}
