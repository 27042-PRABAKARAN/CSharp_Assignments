using ExpenseTracker.Persistence;
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
           FinanceView view = new FinanceView(repository);
           view.FinanceOperations();
        }
    }
}