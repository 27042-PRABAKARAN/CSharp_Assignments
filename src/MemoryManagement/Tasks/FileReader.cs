namespace MemoryManagement.Tasks
{
    /// <summary>
    /// Handles Reading data from text files.
    /// </summary>
    internal class FileReader : IDisposable
    {
        private readonly StreamReader _streamReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReader"/> class.
        /// </summary>
        /// <param name="filePath">Path in which the file exists.</param>
        public FileReader(string filePath)
        {
            this._streamReader = new StreamReader(filePath, true);
        }

        /// <summary>
        /// Reads the data from the file.
        /// </summary>
        /// <param name="lineNumber">Line in which the data should be retrieved.</param>
        /// <returns>Returns the data from the specific line in a file.</returns>
        public string ReadData(int lineNumber)
        {
            this._streamReader.DiscardBufferedData();
            this._streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < lineNumber - 1; i++)
            {
                this._streamReader.ReadLine();
            }

            return this._streamReader.ReadLine() ?? "No data found";
        }

        /// <summary>
        /// Disposes the StreamReader.
        /// </summary>
        public void Dispose()
        {
            this._streamReader.Dispose();
        }
    }
}