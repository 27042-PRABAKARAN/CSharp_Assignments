using ExpenseTracker.Persistence;
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
           IncomeView incomeView = new IncomeView(transactionService);
           ExpenseView expenseView = new ExpenseView(transactionService);
           DashboardView dashboardView = new DashboardView(dashboardService);
           FinanceView view = new FinanceView(incomeView, expenseView, dashboardView);
           view.FinanceOperations();
        }
    }
}