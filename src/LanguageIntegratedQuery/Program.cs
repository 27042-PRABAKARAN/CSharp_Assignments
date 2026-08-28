using LanguageIntegratedQuery.Task;

namespace LanguageIntegratedQuery
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
            BasicLINQ basicLINQ = new BasicLINQ();
            ComplexQueries complex = new ComplexQueries();
            ObjectQueries objectQueries = new ObjectQueries();
            Optimization optimization = new Optimization();
            TestBuilder testBuilder = new TestBuilder();
            Tasks task = new Tasks(basicLINQ, complex, objectQueries, optimization, testBuilder);
            task.TaskOperations();
        }
    }
}