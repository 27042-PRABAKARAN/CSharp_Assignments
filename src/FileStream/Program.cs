using FileHandling.Tasks;

namespace FileHandling
{
    /// <summary>
    /// Program class which is initial point of the application
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            FileDataProcessor fileDataProcessor = new FileDataProcessor();
            AsyncFileDataProcessor asyncFileDataProcessor = new ();
            BasicFileUsage basicFileUsage = new BasicFileUsage();
            Persons users = new ();
            TaskManager taskManager = new TaskManager(fileDataProcessor, asyncFileDataProcessor, basicFileUsage, users);
            taskManager.ExecuteTask();
        }
    }
}