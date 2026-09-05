using MemoryManagement.Models;
using MemoryManagement.Tasks;

namespace Assignments
{
    /// <summary>
    /// The main entry point of the application
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            FileHandler fileHandler = new FileHandler();
            fileHandler.ExecuteFileHandler();
        }
    }
}