namespace MemoryManagement
{
    /// <summary>
    /// ConsolePrinter Provides method for displaying different output
    /// </summary>
    internal static class ConsolePrinter
    {
        /// <summary>
        /// Displays an error message
        /// </summary>
        /// <param name="message">the message that has to be printed in red</param>
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a success message
        /// </summary>
        /// <param name="message">the message that has to be printed in Green</param>
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
