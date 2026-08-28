namespace LanguageIntegratedQuery.Task
{
    /// <summary>
    /// Object Queries
    /// </summary>
    internal class ObjectQueries
    {
        /// <summary>
        /// Task 3
        /// </summary>
        /// <param name="numbers"> array of numbers </param>
        public void Task3(int[] numbers)
        {
            var secondHighest = numbers
                .Distinct()
                .OrderByDescending(product => product)
                .Skip(1)
                .FirstOrDefault();

            Console.WriteLine($"\nSecond Highest Number: {secondHighest}");

            int target = 70;

            var pairs = numbers
                .SelectMany(
                    (first, index) => numbers
                        .Skip(index + 1)
                        .Where(second => first + second == target)
                        .Select(second => new
                        {
                            First = Math.Min(first, second),
                            Second = Math.Max(first, second),
                        }))
                .Distinct()
                .ToList();

            Console.WriteLine($"\nPairs That Add Up To {target}:");

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.First} + {pair.Second} = {target}");
            }
        }
    }
}
