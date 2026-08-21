using FinanceTracker.Model.Enums;

namespace FinanceTracker.View
{
    /// <summary>
    /// The view layer of finance tracker
    /// </summary>
    internal class FinanceView
    {
        private readonly DashboardView _dashboardView;
        private readonly TransactionView _transactionView;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceView"/> class.
        /// </summary>
        /// <param name="transactionView"> instance of Transaction view layer </param>
        /// <param name="dashboardView"> instance of dashboard view layer </param>
        public FinanceView(TransactionView transactionView, DashboardView dashboardView)
        {
            this._dashboardView = dashboardView;
            this._transactionView = transactionView;
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
                            this._transactionView.TransactionManager(TransactionType.Income);
                            UserInput.WaitAndClear();
                            break;
                        }

                    case TransactionOptions.Expense:
                        {
                            this._transactionView.TransactionManager(TransactionType.Expense);
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

                    default:
                        {
                        Console.WriteLine("Enter a valid number between 1 to 4");
                        break;
                        }
                }
            }
        }
    }
}
