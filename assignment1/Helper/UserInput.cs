using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Helper
{
    /// <summary>
    /// Input class for taking inputs
    /// </summary>
    public static class UserInput
    {
        /// <summary>
        /// function to take user input in console
        /// </summary>
        /// <returns> user input </returns>
        public static string? Input()
        {
            string? userInput = Console.ReadLine();
            return userInput;
        }

        /// <summary>
        /// to check the input is null or not
        /// </summary>
        /// <param name="input"> the string to be checked </param>
        /// <returns> boolean </returns>
        public static bool CheckInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return true;
        }
    }
}
