namespace FilleHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileDataProcessor fileDataProcessor = new FileDataProcessor();
            TaskManager taskManager = new TaskManager(fileDataProcessor);
            taskManager.ExecuteTask();
        }
    }
}