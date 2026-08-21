using FinanceTracker.Service;

namespace FinanceTracker.View
{
    /// <summary>
    /// View layer of dashboard
    /// </summary>
    internal class DashboardView
    {
        private readonly DashboardService _dashboardServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardView"/> class.
        /// </summary>
        /// <param name="dashboardService"> instance of dashboard service </param>
        public DashboardView(DashboardService dashboardService)
        {
            this._dashboardServices = dashboardService;
        }

        /// <summary>
        /// To generate summary
        /// </summary>
        public void GenerateSummary()
        {
            if (this._dashboardServices.IsEmptyIncome() && this._dashboardServices.IsEmptyExpense())
            {
                Output.Error("no records for generating summary");
                return;
            }

            decimal income = this._dashboardServices.GetTotalIncome();
            decimal expense = this._dashboardServices.GetTotalExpense();
            Console.WriteLine($@"=========Summary========
Total Income: {income}
Total Expense: {expense}
========================");
            Console.WriteLine(this._dashboardServices.GetSummary());
        }
    }
}
