using AdvancedConcepts.Tasks;

namespace AdvancedConcepts
{
    /// <summary>
    /// the main entry point of the application
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Events events = new Events();
            Types types = new Types();
            AnonymousMethod anonymousMethod = new AnonymousMethod();
            Delegates delegates = new Delegates();
            Queries queries = new Queries();
            Records records = new Records();
            PatternMatching patternMatching = new PatternMatching();
            App app = new App(events, types, anonymousMethod, delegates, queries, records, patternMatching);
            app.Execute();
        }
    }
}