using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConcepts.Tasks
{
    internal class AnonymousMethod
    {
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
