using ExpenseTracker.Persistence;
using ExpenseTracker.Service;
using ExpenseTracker.View;

namespace Assignments
{
    /// <summary>
    /// program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// main function
        /// </summary>
        public static void Main()
        {
           InMemoryRepository repository = new InMemoryRepository();
           TransactionServices services = new TransactionServices(repository);
           FinanceView view = new FinanceView(services);
           view.FinanceOperations();
        }
    }
}