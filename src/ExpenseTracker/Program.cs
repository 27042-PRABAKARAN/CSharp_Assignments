using ExpenseTracker.Logger;
using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace ExpenseTracker
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        public static void Main()
        {
           IRepository repository = new JsonRepository("data.json");
           ILogger logger = new FileLogger("Log.txt");
           TransactionService transactionService = new TransactionService(repository);
           DashboardService dashboardService = new DashboardService(repository);
           TransactionView transactionView = new TransactionView(transactionService, logger);
           DashboardView dashboardView = new DashboardView(dashboardService, logger);
           FinanceView view = new FinanceView(transactionView, dashboardView);
           view.FinanceOperations();
        }
    }
}