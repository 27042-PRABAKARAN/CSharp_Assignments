namespace ExceptionHandling
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            ExceptionHandler exceptionHandler = new ();
            exceptionHandler.ExecuteExceptions();
        }
    }
}