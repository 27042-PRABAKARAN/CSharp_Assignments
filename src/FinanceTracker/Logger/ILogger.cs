namespace FinanceTracker.Logger
{
    /// <summary>
    /// Provides methods to log application events and system messages.
    /// </summary>
    internal interface ILogger
    {
        /// <summary>
        /// Logs general application milestones and routine system updates.
        /// </summary>
        /// <param name="message">The information message text.</param>
        void LogInformation(string message);

        /// <summary>
        /// Logs unexpected events that do not stop the application.
        /// </summary>
        /// <param name="message">The warning message text.</param>
        void LogWarning(string message);

        /// <summary>
        /// Logs critical failures and system errors that disrupt operations.
        /// </summary>
        /// <param name="message">The error message text.</param>
        void LogError(string message);
    }
}
