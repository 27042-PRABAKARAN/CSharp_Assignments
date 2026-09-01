namespace Calculator
{
    /// <summary>
    /// User input class to read input from users
    /// </summary>
    public static class UserInput
    {
        private const int _maxTries = 3;

        /// <summary>
        /// This reads the input
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns string </returns>
        public static decimal? ReadAmount(string? prompt)
        {
            for (int tried = 1; tried <= _maxTries; tried++)
            {
                Console.Write(prompt);
                string? price = Console.ReadLine();
                if (price == null)
                {
                    ConsolePrinter.Error("Invalid. Please enter a positive number.");
                    ConsolePrinter.Error($"{_maxTries - tried} attempts remaining\n");
                    continue;
                }

                if (!decimal.TryParse(price, out decimal amount))
                {
                    ConsolePrinter.Error("Invalid. Please enter a valid number.");
                    ConsolePrinter.Error($"{_maxTries - tried} attempts remaining\n");
                    continue;
                }

                if (amount <= 0)
                {
                    ConsolePrinter.Error("Invalid. Price must be greater than 0.");
                    ConsolePrinter.Error($"{_maxTries - tried} attempts remaining\n");
                    continue;
                }

                if (amount > 10000000000)
                {
                    ConsolePrinter.Error("Invalid. Price cannot exceed 1000 crore.");
                    ConsolePrinter.Error($"{_maxTries - tried} attempts remaining\n");
                    continue;
                }

                return amount;
            }

            return null;
        }

        /// <summary>
        /// This reads the Date
        /// </summary>
        /// <param name="prompt"> the prompt for the input </param>
        /// <returns> returns amount </returns>
        public static DateOnly? ReadDate()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            for (int tried = 1; tried <= _maxTries; tried++)
            {
                Console.Write("Enter date (YYYY-MM-DD), (DD-MM-YYYY) or press Enter for today: ");

                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    return today;
                }

                DateOnly baseDate = new DateOnly(1900, 1, 1);
                if (DateOnly.TryParse(input, out DateOnly date))
                {
                    if (date <= today && date >= baseDate)
                    {
                        return date;
                    }
                    else if (date < baseDate)
                    {
                        ConsolePrinter.Error("dates before year 1900 are not allowed.");
                    }
                    else if (date > today)
                    {
                        ConsolePrinter.Error("Future dates are not allowed.");
                    }
                }
                else
                {
                    ConsolePrinter.Error("Invalid date.");
                }

                int remaining = _maxTries - tried;

                if (remaining > 0)
                {
                    Console.WriteLine($"{remaining} attempt(s) remaining.\n");
                }
            }

            return null;
        }

        /// <summary>
        /// This reads number.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <param name="minRange"> the minimum range  </param>
        /// <param name="maxRange"> the maximum range </param>
        /// <returns> returns read number </returns>
        public static int? ReadInt(string? prompt, int minRange, int maxRange)
        {
            for (int tried = 1; tried <= _maxTries; tried++)
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

                ConsolePrinter.Error($"{_maxTries - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// This reads number.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <returns> returns read number </returns>
        public static double? ReadDouble(string? prompt)
        {
            for (int tried = 1; tried <= _maxTries; tried++)
            {
                Console.Write(prompt);
                if (!double.TryParse(Console.ReadLine(), out double number))
                {
                    ConsolePrinter.Error($"Invalid Number.");
                }
                else
                {
                    return number;
                }

                ConsolePrinter.Error($"{_maxTries - tried} attempts remaining\n");
            }

            return null;
        }

        /// <summary>
        /// This reads choice.
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
        /// To wait until user enters key
        /// </summary>
        public static void WaitAndClear()
        {
            Console.Write("Enter any key to return to menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
