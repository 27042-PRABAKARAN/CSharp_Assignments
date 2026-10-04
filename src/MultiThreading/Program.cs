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

            //TaskException taskException = new TaskException();
            //taskException.Execute().GetAwaiter().GetResult();

            //MultiThread runner = new MultiThread();
            //runner.Execute();

            //TaskParallelLibrary taskParallelLibrary = new TaskParallelLibrary();
            //taskParallelLibrary.Execute();

            //ChainOperator chainOperator = new ChainOperator();
            //chainOperator.Execute().Wait();

            DeadlockSimulator deadlock = new DeadlockSimulator();
            deadlock.Execute();

        }
    }
}
