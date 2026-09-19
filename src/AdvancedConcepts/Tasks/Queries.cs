using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConcepts.Tasks
{
    internal class Queries
    {
        public void ExecuteQueries()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("Original list: " + string.Join(", ", numbers));
            List<int> updatedNumbers = numbers.Where(number => number % 2 == 0).Select(number => number * number).ToList();
            Console.WriteLine("Squares of odd numbers: " + string.Join(", ", updatedNumbers));
        }
    }
}
