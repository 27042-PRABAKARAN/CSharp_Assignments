namespace Calculator
{
    /// <summary>
    /// User input class to read input from users
    /// </summary>
    public static class UserInput
    {
        private const int _maxTries = 3;

        /// <summary>
        /// This reads number.
        /// </summary>
        /// <param name="prompt"> to prompt the message </param>
        /// <returns> returns read number </returns>
        public static int? ReadInt(string? prompt)
        {
            for (int tried = 1; tried <= _maxTries; tried++)
            {
                Console.Write(prompt);
                if (!int.TryParse(Console.ReadLine(), out int number))
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
