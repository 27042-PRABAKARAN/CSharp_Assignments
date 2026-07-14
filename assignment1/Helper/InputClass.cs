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
    public static class InputClass
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
    }
}
