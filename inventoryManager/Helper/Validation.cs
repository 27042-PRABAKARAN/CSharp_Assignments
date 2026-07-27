using System.Text.RegularExpressions;

namespace InventoryManager.Helper
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
        public static bool IsValidContact(string? number)
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

        /// <summary>
        /// to check the input is null or not
        /// </summary>
        /// <param name="input"> the string to be checked </param>
        /// <returns> validation </returns>
        public static bool IsValidInput(string? input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// TO check if user is enterring a valid input or not
        /// </summary>
        /// <param name="prompt"> to print before user enters value </param>
        /// <param name="validation">  the validating function </param>
        /// <param name="errorMessage"> the error message </param>
        /// <returns> returns string </returns>
        public static string? GetValidInput(string? prompt, Func<string, bool> validation, string? errorMessage)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Output.Error(errorMessage);
                    continue;
                }

                if (validation(input))
                {
                    return input;
                }

                Output.Error(errorMessage);
                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }
    }
}
