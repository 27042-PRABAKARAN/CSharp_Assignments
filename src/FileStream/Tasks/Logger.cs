using System.Text;

namespace FileHandling.Tasks
{
    /// <summary>
    /// Logs messages to file
    /// </summary>
    internal class Logger
    {
        private readonly string _filePath;
        private readonly SemaphoreSlim _semaphore = new (1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="filePath">The target storage path for the log file.</param>
        public Logger(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Records unexpected events that do not stops the application.
        /// </summary>
        /// <param name="message">The warning details to save.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LogWarning(string message)
        {
            await this.WriteLog("WARNING", message);
        }

        /// <summary>
        /// Records unexpected operational crashes.
        /// </summary>
        /// <param name="message">The error details to save.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LogError(string message)
        {
            await this.WriteLog("ERROR", message);
        }

        /// <summary>
        /// Records critical system failures and unexpected operational crashes.
        /// </summary>
        /// <param name="message">The information details to save.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task LogInformation(string message)
        {
            await this.WriteLog("INFO", message);
        }

        /// <summary>
        /// appends a formatted timestamp, log level, and message line to the file.
        /// </summary>
        /// <param name="level">The Stamp.</param>
        /// <param name="message">The descriptive statement to track.</param>
        private async Task WriteLog(string level, string message)
        {
            string logMessage =
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            await this._semaphore.WaitAsync();
            try
            {
                using (FileStream fileStream = new FileStream(this._filePath, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4 * 1024, useAsync: true))
                {
                    using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
                    {
                        await writer.WriteLineAsync(logMessage);
                        Console.WriteLine(logMessage + "message Logged");
                    }
                }
            }
            finally
            {
                this._semaphore.Release();
            }
        }
    }
}
