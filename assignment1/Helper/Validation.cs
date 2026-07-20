using System.Text.RegularExpressions;

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

            if (number.Length != 10)
            {
                return false;
            }

            return number.All(char.IsDigit);
        }

        /// <summary>
        /// Validating email function
        /// </summary>
        /// <param name="mail"> the mail which has to be validated </param>
        /// <returns> the result as bool of validation result </returns>
        public static bool IsValidEmail(string? mail)
        {
            if (mail == null)
            {
                return false;
            }

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(mail, pattern, RegexOptions.IgnoreCase);
        }
    }
}
