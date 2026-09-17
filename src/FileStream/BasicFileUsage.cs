using System.Text;

namespace FileHandling
{
    /// <summary>
    /// Basic File read and write operation
    /// </summary>
    internal class BasicFileUsage
    {
        /// <summary>
        /// Executes basic file read and write operations
        /// </summary>
        public void ExecuteBasicFileUsage()
        {
            string path = "test.txt";
            string data = "This is some test data";

            // Write from MemoryStream to file
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                fileStream.Write(buffer, 0, buffer.Length);
            }

            // Reading from file using FileStream
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Display the data read from the file
                    Console.WriteLine(Encoding.UTF8.GetString(buffer));
                }

                Console.WriteLine();
            }

            Console.WriteLine("File operation completed.");
        }
    }
}
