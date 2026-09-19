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
            PatternMatching patternMatching = new PatternMatching();
            patternMatching.ExecutePatternMatching();
            Console.ReadLine();
        }
    }
}