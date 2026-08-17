using FinanceTracker.Repository;
using FinanceTracker.Service;
using FinanceTracker.View;

namespace FinanceTracker
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
           TransactionService transactionService = new TransactionService(repository);
           DashboardService dashboardService = new DashboardService(repository);
           TransactionView transactionView = new TransactionView(transactionService);
           DashboardView dashboardView = new DashboardView(dashboardService);
           FinanceView view = new FinanceView(transactionView, dashboardView);
           view.FinanceOperations();
        }
    }
}