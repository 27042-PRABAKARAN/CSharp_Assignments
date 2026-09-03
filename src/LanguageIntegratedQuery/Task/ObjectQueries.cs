namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Demonstrates LINQ Object Queries
    /// </summary>
    internal class ObjectQueries
    {
        /// <summary>
        /// Task 3 - Finds second highest number and unique pairs that adds up to a target value
        /// </summary>
        /// <param name="numbers">Array of numbers</param>
        public void ExecuteObjectQueries(int[] numbers)
        {
            Console.Clear();
            Console.WriteLine(@"========================================
TASK 3 - LINQ OBJECT QUERIES
========================================");

            Console.WriteLine("\nFinding the second highest number");

            var secondHighest = numbers
                .Distinct()
                .OrderByDescending(number => number)
                .Skip(1)
                .FirstOrDefault();

            Console.WriteLine("Second highest number found.");
            Console.WriteLine($"Second Highest Number: {secondHighest}");

            int target = secondHighest;

            Console.WriteLine($"\nFinding unique pairs that add up to {target}");

            var pairs = numbers
                .SelectMany((first, index) => numbers
                .Skip(index + 1)
                .Where(second => first + second == target)
                .Select(second => new
                {
                    First = first,
                    Second = second,
                }))
                .Distinct()
                .ToList();

            Console.WriteLine("Pair search completed.");

            Console.WriteLine($"\nPairs That Add Up To {target}:");

            if (pairs.Count == 0)
            {
                Console.WriteLine("No matching pairs found.");
                return;
            }

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.First} + {pair.Second} = {target}");
            }
        }
    }
}