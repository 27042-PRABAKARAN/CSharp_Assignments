namespace ExceptionHandling
{
    /// <summary>
    /// User input class to read input from users
    /// </summary>
    public static class UserInput
    {
        /// <summary>
        /// Prompts the user to enter a number corresponding to an enum value.
        /// </summary>
        /// <typeparam name="T">The enum type to validate against.</typeparam>
        /// <param name="prompt">The message displayed to the user.</param>
        /// <returns>The entered number if valid; otherwise, null.</returns>
        public static int? ReadEnum<T>(string prompt)
            where T : Enum
        {
            int maxRange = Enum.GetNames(typeof(T)).Length;
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int number) && number >= 1 && number <= maxRange)
            {
                return number;
            }

            ConsolePrinter.Error($"Invalid Number. Please enter a number between 1 to {maxRange}.");

            return null;
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