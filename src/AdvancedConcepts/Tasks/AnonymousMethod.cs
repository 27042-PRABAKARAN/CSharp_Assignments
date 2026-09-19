namespace AdvancedConcepts.Tasks
{
    /// <summary>
    /// Represents a task that demonstrates the usage of anonymous methods and lambda expressions in C#.
    /// </summary>
    internal class AnonymousMethod
    {
        /// <summary>
        /// Executes the demonstration by sorting an integer array using an anonymous comparison lambda expression.
        /// </summary>
        public void ExecuteAnonymousMethod()
        {
            int[] numbers = { 54, 12, 15, 25, 35, 44, 0, 1 };

            Console.WriteLine("Original array: " + string.Join(", ", numbers));
            Array.Sort(numbers,  (firstElement, secondElement) =>
            {
                return firstElement.CompareTo(secondElement);
            });

            Console.WriteLine("Sorted array: " + string.Join(", ", numbers));
        }
    }
}
