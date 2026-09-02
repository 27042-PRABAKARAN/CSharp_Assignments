namespace ExceptionHandling
{
    /// <summary>
    /// Display class is used for displaying output
    /// </summary>
    public static class ConsolePrinter
    {
        /// <summary>
        /// to print the message in red
        /// </summary>
        /// <param name="message">the message that has to be printed in red</param>
        public static void Error(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// to print the message in Green
        /// </summary>
        /// <param name="message">the message that has to be printed in Green</param>
        public static void Success(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Display function is present here
        /// </summary>
        /// <param name="text"> the content that has to be displayed </param>
        public static void Display(string? text)
        {
            Console.WriteLine(text);
        }
    }
}
