using ExpenseTracker.Model.Enums;

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
        /// <param name="incomeView"> instance of income view layer </param>
        /// <param name="expenseView"> instance of expense view layer </param>
        /// <param name="dashboardView"> instance of dashboard view layer </param>
        public FinanceView(IncomeView incomeView, ExpenseView expenseView, DashboardView dashboardView)
        {
            this._dashboardView = dashboardView;
            this._incomeView = incomeView;
            this._expenseView = expenseView;
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
