namespace ExpenseTracker.View
{
    /// <summary>
    /// user input class
    /// </summary>
    public static class UserInput
    {
        /// <summary>
        /// this reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static decimal? ReadPrice(string? prompt)
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write(prompt);
                string? price = Console.ReadLine();
                if (price == null)
                {
                    Output.Error("Invalid. Please enter a positive number.");
                    Output.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (!decimal.TryParse(price, out decimal amount))
                {
                    Output.Error("Invalid. Please enter a valid number.");
                    Output.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (amount <= 0)
                {
                    Output.Error("Invalid. Price must be greater than 0.");
                    Output.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                if (amount > 10000000000)
                {
                    Output.Error("Invalid. Price cannot exceed 1000 crore.");
                    Output.Error($"{3 - tried} attempts remaining\n");
                    continue;
                }

                return amount;
            }

            return null;
        }

        /// <summary>
        /// this reads the amount
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns amount </returns>
        public static DateOnly? ReadDate()
        {
            for (int tried = 1; tried <= 3; tried++)
            {
                Console.Write("Enter date (YYYY-MM-DD) or press Enter for today: ");

                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    return DateOnly.FromDateTime(DateTime.Today);
                }

                if (DateOnly.TryParse(input, out DateOnly date))
                {
                    return date;
                }
                else
                {
                    Output.Error("Invalid date");

                    int remaining = 3 - tried;
                    if (remaining > 0)
                    {
                        Console.WriteLine($"{remaining} attempt(s) remaining.\n");
                    }
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
        /// this reads choice.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <returns> returns read number </returns>
        public static int? ReadChoice(string? prompt)
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

        /// <summary>
        /// to wait until user enters key
        /// </summary>
        public static void WaitAndClear()
        {
            Console.Write("Enter any key to return to menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
