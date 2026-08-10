using ExpenseTracker.Model.Enums;
using ExpenseTracker.Persistence;

namespace ExpenseTracker.View
{
    /// <summary>
    /// The view layer of finance tracker
    /// </summary>
    internal class FinanceView
    {
        private readonly DashboardView _dashboardView;
        private readonly IncomeView _incomeView;
        private readonly ExpenseView _expenseView;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceView"/> class.
        /// </summary>
        /// <param name="service"> instance of services </param>
        /// <param name="repository"> instance of repository </param>
        public FinanceView(IRepository repository)
        {
            this._dashboardView = new DashboardView(repository);
            this._incomeView = new IncomeView(repository);
            this._expenseView = new ExpenseView(repository);
        }

        /// <summary>
        /// Operation that can be made in this applications.
        /// </summary>
        public void FinanceOperations()
        {
            Console.WriteLine("Hey User,");
            Console.WriteLine("Welcome to Finance tracker");
            bool loop = true;
            while (loop)
            {
                Console.WriteLine(@"===========MENU==========
1. Income Options
2. Expense Options
3. Generate Summary
4. Exit
=========================");
                int? choice = UserInput.ReadChoice("Enter your choice: ");
                if (choice == null)
                {
                    continue;
                }

                Console.Clear();

                switch ((TransactionOptions)choice)
                {
                    case TransactionOptions.Income:
                        {
                            this._incomeView.IncomeOperations();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOptions.Expense:
                        {
                            this._expenseView.ExpenseOperations();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOptions.Summary:
                        {
                            this._dashboardView.GenerateSummary();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOptions.Exit:
                        {
                            loop = false;
                            break;
                        }
                }
            }
        }
    }
}
