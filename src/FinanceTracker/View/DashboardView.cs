using FinanceTracker.Logger;
using FinanceTracker.Service;

namespace FinanceTracker.View
{
    /// <summary>
    /// View layer of dashboard
    /// </summary>
    internal class DashboardView
    {
        private readonly DashboardService _dashboardServices;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardView"/> class.
        /// </summary>
        /// <param name="dashboardService"> instance of dashboard service </param>
        /// <param name="logger"> instance of logger </param>
        public DashboardView(DashboardService dashboardService, ILogger logger)
        {
            this._dashboardServices = dashboardService;
            this._logger = logger;
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
            this._logger.LogInformation($"Summary Generated Successfully");
        }
    }
}
