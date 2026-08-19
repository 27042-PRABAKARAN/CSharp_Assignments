using ExpenseTracker.Repository;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
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
           InMemoryRepository repository = new InMemoryRepository();
           TransactionService transactionService = new TransactionService(repository);
           DashboardService dashboardService = new DashboardService(repository);
           TransactionView transactionView = new TransactionView(transactionService);
           DashboardView dashboardView = new DashboardView(dashboardService);
           FinanceView view = new FinanceView(transactionView, dashboardView);
           view.FinanceOperations();
        }
    }
}