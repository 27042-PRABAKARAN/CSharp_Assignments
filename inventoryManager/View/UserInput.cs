using System.Text.RegularExpressions;
using InventoryManager.Helper;

namespace InventoryManager.View
{
    /// <summary>
    /// Input class for taking inputs
    /// </summary>
    internal static class UserInput
    {
        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static string? ReadInput(string prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    return input.Trim();
                }

                ConsolePrinter.Error("Nothing entered");
                ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static decimal? ReadPrice(string prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? price = Console.ReadLine();
                if (price == null)
                {
                    ConsolePrinter.Error("Invalid. Please enter a positive number.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (!decimal.TryParse(price, out decimal amount))
                {
                    ConsolePrinter.Error("Invalid. Please enter a valid number.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (amount <= 0)
                {
                    ConsolePrinter.Error("Invalid. Price must be greater than 0.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (amount > 10000000)
                {
                    ConsolePrinter.Error("Invalid. Price cannot exceed 1 crore.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                return amount;
            }

            return null;
        }

        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static string? ReadName(string prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    ConsolePrinter.Error("Name cannot be empty.");
                }
                else if (!Regex.IsMatch(input, @"^[A-Za-z0-9 ]+$"))
                {
                    ConsolePrinter.Error("Name cannot contain special characters."); 
                }
                else
                {
                    return input.Trim();
                }

                ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static long? ReadQuantity(string prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (long.TryParse(Console.ReadLine(), out long quantity) && quantity >= 0)
                {
                    if (quantity > 10000000)
                    {
                        ConsolePrinter.Error("Invalid Quantity cannot exceed 1cr");
                        ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                        continue;
                    }
                    else
                    {
                        return quantity;
                    }
                }
                else
                {
                    ConsolePrinter.Error("Invalid. Please enter a Non negative number.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }
            }

            return null;
        }

        /// <summary>
        /// this reads the Id
        /// </summary>
        /// <param name="prompt">the prompt for the input </param>
        /// <param name="isValid"> function to validate id</param>
        /// <returns> ID read from user </returns>
        public static string? ReadId(string prompt, Func<string, bool> isValid)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (input == null)
                {
                    ConsolePrinter.Error("Invalid. Please enter a ID Similar to ABCD-0001.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (!Regex.IsMatch(input, @"^[A-Za-z]{4}-\d+$"))
                {
                    ConsolePrinter.Error("Invalid. Please enter a ID Similar to ABCD-0001.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (isValid(input))
                {
                    ConsolePrinter.Error("Product Id already Exists.");
                    ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }
                else
                {
                    return input.Trim();
                }
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
        public static int? ReadInt(string prompt, int minRange, int maxRange)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out int number) || number > maxRange || number < minRange)
                {
                    ConsolePrinter.Error($"Invalid Number. Please enter a number between {minRange} to {maxRange}.");
                }
                else
                {
                    return number;
                }

                ConsolePrinter.Error($"{3 - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// this reads choice.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <returns> returns read number </returns>
        public static int? ReadChoice(string prompt)
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                return null;
            }
            else
            {
                return number;
            }
        }
    }
}
