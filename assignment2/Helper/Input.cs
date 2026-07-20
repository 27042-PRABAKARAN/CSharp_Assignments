using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Helper
{
    /// <summary>
    /// Input helper class
    /// </summary>
    internal class Input
    {
        /// <summary>
        /// to check if the entered value is null or not
        /// </summary>
        /// <param name="input"> the input to be checked </param>
        /// <returns> the bool value of the check</returns>
        public static bool IsNull(string? input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
