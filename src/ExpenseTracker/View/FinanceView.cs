using ExpenseTracker.Model.Enums;
using ExpenseTracker.Persistence;

namespace ExpenseTracker.View
{
    /// <summary>
    /// the view layer of finance tracker
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
        /// operation that can be made in this applications.
        /// </summary>
        public void FinanceOperations()
        {
            Console.WriteLine("Hey User,");
            Console.WriteLine("Welcome to Finance tracker");
            bool state = true;
            while (state)
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

                switch ((TransactionType)choice)
                {
                    case TransactionType.Income:
                        {
                            Console.Clear();
                            this._incomeView.IncomeOperations();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionType.Expense:
                        {
                            Console.Clear();
                            this._expenseView.ExpenseOperations();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionType.Summary:
                        {
                            Console.Clear();
                            this._dashboardView.GenerateSummary();
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionType.Exit:
                        {
                            state = false;
                            break;
                        }
                }
            }
        }
    }
}
