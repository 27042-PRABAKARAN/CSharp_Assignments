namespace AdvancedConcepts.Tasks
{
    /// <summary>
    /// Demonstrates the usage of LINQ (Language Integrated Query) method syntax to filter and transform collections.
    /// </summary>
    internal class Queries
    {
        /// <summary>
        /// Executes the query demonstration by filtering out odd values and squaring the remaining even numbers using LINQ operations.
        /// </summary>
        public void ExecuteQueries()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Original list: " + string.Join(", ", numbers));

            List<int> updatedNumbers = numbers.Where(number => number % 2 == 0).Select(number => number * number).ToList();
            Console.WriteLine("Squares of odd numbers: " + string.Join(", ", updatedNumbers));
        }
    }
}
