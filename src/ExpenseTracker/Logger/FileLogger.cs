using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpenseTracker.Logger
{/// <summary>
 /// Implements the logger interface to save messages to a local text file.
 /// </summary>
    internal class FileLogger : ILogger
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLogger"/> class.
        /// </summary>
        /// <param name="filePath">The target storage path for the log file.</param>
        public FileLogger(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Records unexpected events that do not stops the application.
        /// </summary>
        /// <param name="message">The warning details to save.</param>
        public void LogWarning(string message)
        {
            this.WriteLog("WARNING", message);
        }

        /// <summary>
        /// Records unexpected operational crashes.
        /// </summary>
        /// <param name="message">The error details to save.</param>
        public void LogError(string message)
        {
            this.WriteLog("ERROR", message);
        }

        /// <summary>
        /// Records critical system failures and unexpected operational crashes.
        /// </summary>
        /// <param name="message">The information details to save.</param>
        public void LogInformation(string message)
        {
            this.WriteLog("INFO", message);
        }

        /// <summary>
        /// appends a formatted timestamp, log level, and message line to the file.
        /// </summary>
        /// <param name="level">The Stamp.</param>
        /// <param name="message">The descriptive statement to track.</param>
        private void WriteLog(string level, string message)
        {
            string logMessage =
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";

            File.AppendAllText(
                this._filePath,
                logMessage + Environment.NewLine);
        }
    }
}
