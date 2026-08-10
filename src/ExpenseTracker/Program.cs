using ExpenseTracker.Persistence;
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
           FinanceView view = new FinanceView(repository);
           view.FinanceOperations();
        }
    }
}