using System.Diagnostics;
using System.Text;

namespace FileHandling
{
    /// <summary>
    /// File Data process are being carried out
    /// </summary>
    internal class FileDataProcessor
    {
        private const string _inputFilePath = "Book.txt";
        private const string _outputFilePath = "output.txt";
        private const int _chunkSize = 1024 * 1024;

        /// <summary>
        /// Executes the Data processing operations
        /// </summary>
        public void ExecuteDataProcessor()
        {
            this.GenerateLargeFile(_inputFilePath, 1024);
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Chunking file stream reading processing and writing");
            stopwatch.Start();
            this.ReadWithFileStream(_inputFilePath);
            stopwatch.Stop();
            Console.WriteLine($"Reading using File Stream: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("BufferedStream Reading started");
            stopwatch.Restart();
            this.ReadWithBufferedStream(_inputFilePath);
            stopwatch.Stop();
            Console.WriteLine($"Reading time to complete book using Buffered Stream: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("Converting all the text to uppercase and writing it using memory stream");
            stopwatch.Restart();
            this.ProcessWithFileStream(_inputFilePath, _outputFilePath);
            stopwatch.Stop();
            Console.WriteLine($"Converting all the text to uppercase and writing it using memory stream took: {stopwatch.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// Generates a large sized file
        /// </summary>
        /// <param name="filePath"> file path</param>
        /// <param name="sizeInMb"> size of the file</param>
        public void GenerateLargeFile(string filePath, int sizeInMb)
        {
            Console.WriteLine($"Creating a {sizeInMb}MB file.");
            string text = "Very Large File is being created\n";
            byte[] blockBytes = Encoding.UTF8.GetBytes(text);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                long bytes = (long)sizeInMb * 1024 * 1024;
                long written = 0;
                while (written < bytes)
                {
                    fileStream.Write(blockBytes, 0, blockBytes.Length);
                    written += blockBytes.Length;
                }
            }

            Console.WriteLine("Large file created successfully.");
        }

        /// <summary>
        /// to read with file stream
        /// </summary>
        /// <param name="inputPath"> the file path of the input file</param>
        public void ReadWithFileStream(string inputPath)
        {
            byte[] buffer = new byte[_chunkSize];

            using (FileStream inputFile = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                while ((bytesRead = inputFile.Read(buffer, 0, _chunkSize)) > 0)
                {
                }
            }
        }

        /// <summary>
        /// to read with file stream, process data and write using memory stream
        /// </summary>
        /// <param name="inputPath"> the file path of the input file</param>
        /// <param name="outputPath"> the file path of the Output file </param>
        public void ProcessWithFileStream(string inputPath, string outputPath)
        {
            byte[] buffer = new byte[_chunkSize];

            using (FileStream inputFile = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                int bytesRead;
                while ((bytesRead = inputFile.Read(buffer, 0, _chunkSize)) > 0)
                {
                    string textChunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string processedText = this.ConvertUpperCase(textChunk);
                    this.WriteWithMemoryStream(outputFile, processedText);
                }
            }
        }

        /// <summary>
        /// reads the data using buffered stream only
        /// </summary>
        /// <param name="filePath"> file path of the file to be read </param>
        public void ReadWithBufferedStream(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 0))
            using (BufferedStream bufferedStream = new BufferedStream(fileStream, _chunkSize))
            using (StreamReader reader = new StreamReader(bufferedStream))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                }
            }
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

        /// <summary>
        /// To write with memory stream
        /// </summary>
        /// <param name="targetFileStream"> the target file stream to be written</param>
        /// <param name="dataToWrite"> the data to be written </param>
        public void WriteWithMemoryStream(FileStream targetFileStream, string dataToWrite)
        {
            byte[] rawBytes = Encoding.UTF8.GetBytes(dataToWrite);

            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Write(rawBytes, 0, rawBytes.Length);
                memStream.Position = 0;
                memStream.CopyTo(targetFileStream);
            }
        }
    }
}
