namespace MemoryManagement.Tasks
{
    /// <summary>
    /// Handles Writing data from text files.
    /// </summary>
    internal class FileWriter : IDisposable
    {
        private readonly StreamWriter _streamWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        /// <param name="filePath">Path in which the file exists.</param>
        public FileWriter(string filePath)
        {
            this._streamWriter = new StreamWriter(filePath, true);
        }

        /// <summary>
        /// Writes the data into the file.
        /// </summary>
        /// <param name="text">Text that should be appended in the file.</param>
        public void Write(string text)
        {
            this._streamWriter.WriteLine(text);
        }

        /// <summary>
        /// Disposes the StreamWriter
        /// </summary>
        public void Dispose()
        {
            this._streamWriter.Dispose();
        }
    }
}
