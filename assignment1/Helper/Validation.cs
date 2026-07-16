using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1.Helper
{
    /// <summary>
    /// Validation class which has validation methods.
    /// </summary>
    internal static class Validation
    {
        /// <summary>
        /// Validating phone number
        /// </summary>
        /// <param name="number"> the string of the phone number</param>
        /// <returns> validation result </returns>
        public static bool ValidatingContact(string? number)
        {
            if (number == null)
            {
                return false;
            }

            foreach (char c in number)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            if (number.Length != 10)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validating email function
        /// </summary>
        /// <param name="mail"> the mail which has to be validated </param>
        /// <returns> the result as bool of validation result </returns>
        public static bool IsValidEmail(string? mail)
        {
            return !string.IsNullOrWhiteSpace(mail) && Regex.IsMatch(mail, @"^.+@.+\..+$");
        }
    }
}
