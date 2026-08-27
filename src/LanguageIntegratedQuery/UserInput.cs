namespace LanguageIntegratedQuery
{
    /// <summary>
    /// Class to get user input
    /// </summary>
    internal class UserInput
    {
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
