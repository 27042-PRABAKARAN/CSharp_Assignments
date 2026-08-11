using ExpenseTracker.Model;
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
           IncomeService incomeService = new IncomeService(repository);
           ExpenseService expenseService = new ExpenseService(repository);
           DashboardService dashboardService = new DashboardService(repository);
           IncomeView incomeView = new IncomeView(incomeService);
           ExpenseView expenseView = new ExpenseView(expenseService);
           DashboardView dashboardView = new DashboardView(dashboardService);
           FinanceView view = new FinanceView(incomeView, expenseView, dashboardView);
           view.FinanceOperations();
        }
    }
}