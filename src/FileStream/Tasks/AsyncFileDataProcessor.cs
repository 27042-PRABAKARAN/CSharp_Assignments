using System.Diagnostics;
using System.Text;

namespace FileHandling.Tasks
{
    /// <summary>
    /// Processing File data asynchronously
    /// </summary>
    internal class AsyncFileDataProcessor
    {
        private string _firstBookPath = "firstBook.txt";
        private string _secondBookPath = "secondBook.txt";
        private string _thirdBookPath = "thirdBook.txt";
        private int _chunkSize = 1024 * 1024;

        /// <summary>
        /// Executes File Data processing asynchronously
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task ExecuteAsyncFileDataProcessor()
        {
            Task generateFirstFile = this.GenerateLargeData(this._firstBookPath);
            Task generateSecondFile = this.GenerateLargeData(this._secondBookPath);
            Task generateThirdFile = this.GenerateLargeData(this._thirdBookPath);
            await Task.WhenAll(generateFirstFile, generateSecondFile, generateThirdFile);

            Stopwatch stopwatch = new ();
            stopwatch.Start();

            Task processFirstFile = this.ProcessFileAsync(this._firstBookPath, "Output1.txt");
            Task processSecondFile = this.ProcessFileAsync(this._secondBookPath, "Output2.txt");
            Task processThirdFile = this.ProcessFileAsync(this._thirdBookPath, "Output3.txt");
            await Task.WhenAll(processFirstFile, processSecondFile, processThirdFile);

            stopwatch.Stop();
            Console.WriteLine($"Processed 3 files asynchronously, time taken {stopwatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Generate large data file
        /// </summary>
        /// <param name="filePath"> path of the file to be generated </param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task GenerateLargeData(string filePath)
        {
            Console.WriteLine($"Generating large file: {filePath}");
            int targetChunkSize = 1024 * 1024;
            byte[] baseData = Encoding.UTF8.GetBytes("This is the data for book.\n");
            byte[] largeChunk = new byte[targetChunkSize];

            for (int i = 0; i < largeChunk.Length; i += baseData.Length)
            {
                int bytesToCopy = Math.Min(baseData.Length, largeChunk.Length - i);
                Buffer.BlockCopy(baseData, 0, largeChunk, i, bytesToCopy);
            }

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                long bytes = 1024L * 1024 * 1024;
                long written = 0;
                while (written < bytes)
                {
                    await fileStream.WriteAsync(largeChunk);
                    written += largeChunk.Length;
                }
            }

            Console.WriteLine($"Completed Generating: {filePath}");
        }

        /// <summary>
        /// Processing files asynchronously
        /// </summary>
        /// <param name="inputPath">File path of input file</param>
        /// <param name="outputPath">File path of output file</param>
        /// <returns> current task</returns>
        public async Task ProcessFileAsync(string inputPath, string outputPath)
        {
            Console.WriteLine($"Started Processing: {inputPath}");
            char[] buffer = new char[this._chunkSize];

            using (StreamReader reader = new StreamReader(inputPath, Encoding.UTF8, true, bufferSize: this._chunkSize))
            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8, bufferSize: this._chunkSize))
            {
                int charsRead;
                while ((charsRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string upperText = new string(buffer, 0, charsRead).ToUpperInvariant();
                    await writer.WriteAsync(upperText);
                }
            }

            Console.WriteLine($"Completed processing: {inputPath}");
        }

        /// <summary>
        /// To convert the given input data to upper case
        /// </summary>
        /// <param name="inputData"> the input data to be converted into uppercase </param>
        /// <returns> returns processed data</returns>
        public string ConvertUpperCase(string inputData)
        {
            return inputData.ToUpper();
        }
    }
}
