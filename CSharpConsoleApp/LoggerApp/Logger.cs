namespace LoggerApp
{
    /// <summary>
    /// Provides simple console logging functionality for the solution.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Writes a timestamped log message to the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public static void Log(string message)
        {
            Console.WriteLine($"[LOG - {DateTime.Now:HH:mm:ss}]: {message}");
        }
    }
}
