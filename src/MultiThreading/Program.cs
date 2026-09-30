using MultiThreading.Tasks;

namespace MultiThreading
{
    /// <summary>
    /// The Entry point of application
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            //DownloadContent downloadContent = new DownloadContent();
            //downloadContent.Execute().GetAwaiter().GetResult();

            TaskException taskException = new TaskException();
            taskException.Execute().GetAwaiter().GetResult();
        }
    }
}
