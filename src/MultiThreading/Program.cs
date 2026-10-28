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
            var downloadContent = new DownloadContent();
            var taskException = new TaskException();
            var multiThread = new MultiThread();
            var taskParallelLibrary = new TaskParallelLibrary();
            var chainOperator = new ChainOperator();
            var deadlockSimulator = new DeadlockSimulator();
            var awaitConfigure = new AwaitConfigure();

            bool state = true;
            while (state)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("    SELECT A TASK TO EXECUTE            ");
                Console.WriteLine("========================================");

                string[] enumNames = Enum.GetNames(typeof(TaskOptions));
                for (int i = 0; i < enumNames.Length; i++)
                {
                    Console.WriteLine($" [{i + 1}] {enumNames[i]}");
                }

                Console.WriteLine("========================================");

                TaskOptions? selectedOption = UserInput.ReadEnum<TaskOptions>("Enter a choice: ");

                switch (selectedOption)
                {
                    case TaskOptions.DownloadContent:
                        downloadContent.Execute().GetAwaiter().GetResult();
                        break;

                    case TaskOptions.TaskException:
                        taskException.Execute().GetAwaiter().GetResult();
                        break;

                    case TaskOptions.MultiThread:
                        multiThread.Execute();
                        break;

                    case TaskOptions.TaskParallelLibrary:
                        taskParallelLibrary.Execute();
                        break;

                    case TaskOptions.ChainOperator:
                        chainOperator.Execute().Wait();
                        break;

                    case TaskOptions.DeadlockSimulator:
                        deadlockSimulator.Execute();
                        break;

                    case TaskOptions.AwaitConfigure:
                        awaitConfigure.Execute().Wait();
                        break;
                    case TaskOptions.Exit:
                        state = false;
                        break;
                }

                UserInput.WaitAndClear();
            }
        }
    }
}