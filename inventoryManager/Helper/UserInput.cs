using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace InventoryManager.Helper
{
    /// <summary>
    /// Input class for taking inputs
    /// </summary>
    public static class UserInput
    {
        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static string? ReadInput(string? prompt)
        {
            string? userInput = GetValidInput(prompt, Validation.IsValidInput, "Nothing Entered !!");
            return userInput;
        }

        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static decimal? ReadDecimal(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
                {
                    Output.Error("Invalid. Please enter a positive number.");
                }
                else
                {
                    return amount;
                }

                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// this reads the Id
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static string? ReadId(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Output.Error("Invalid. Please enter a ID Similar to ABCD-0001.");
                    continue;
                }

                if (!Regex.IsMatch(input, @"^[A-Za-z]{4}-\d{4}$"))
                {
                    Output.Error("Invalid. Please enter a ID Similar to ABCD-0001.");
                }
                else
                {
                    return input;
                }

                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// this reads number.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <param name="minRange"> the minimum range  </param>
        /// <param name="maxRange"> the maximum range </param>
        /// <returns> returns read number </returns>
        public static int? ReadInt(string? prompt, int minRange, int maxRange)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out int number) || number > maxRange || number < minRange)
                {
                    Output.Error($"Invalid Number. Please enter a number between {minRange} to {maxRange}.");
                }
                else
                {
                    return number;
                }

                Output.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
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
