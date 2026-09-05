using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MemoryManagement.Tasks
{
    /// <summary>
    /// File data handler
    /// </summary>
    internal class FileHandler
    {
        /// <summary>
        /// //// /// To see automatic dispose method calling
        /// </summary>
        public void ExecuteFileHandler()
        {
            string filePath = "demo.txt";

            Console.WriteLine("Writing");
            using (FileWriter writer = new FileWriter(filePath))
            {
                writer.Write("Line 1");
                writer.Write("Line 2");
                writer.Write("Line 3");
                Console.WriteLine("Data written to file successfully.");
            }

            Console.WriteLine("Reading");

            try
            {
                using (FileReader reader = new FileReader(filePath))
                {
                    string inputLine = reader.ReadData(2);
                    Console.WriteLine($"Line 2: {inputLine}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error accessing the file: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
