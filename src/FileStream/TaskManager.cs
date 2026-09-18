using FileHandling.Enums;
using FileHandling.Tasks;

namespace FileHandling
{
    /// <summary>
    /// Task Manager
    /// </summary>
    internal class TaskManager
    {
        private readonly FileDataProcessor _fileDataProcessor;
        private readonly AsyncFileDataProcessor _asyncFileDataProcessor;
        private readonly BasicFileUsage _basicFileUsage;
        private readonly Persons _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskManager"/> class.
        /// </summary>
        /// <param name="fileDataProcessor">instance of file data processor</param>
        /// <param name="asyncFileDataProcessor"> instance of asynchronous file data processor</param>
        /// <param name="basicFileUsage"> instance of basic file usage class </param>
        /// <param name="users"> instance of users class</param>
        public TaskManager(FileDataProcessor fileDataProcessor, AsyncFileDataProcessor asyncFileDataProcessor, BasicFileUsage basicFileUsage, Persons users)
        {
            this._fileDataProcessor = fileDataProcessor;
            this._asyncFileDataProcessor = asyncFileDataProcessor;
            this._basicFileUsage = basicFileUsage;
            this._users = users;
        }

        /// <summary>
        /// TO Execute the tasks
        /// </summary>
        public void ExecuteTask()
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"=================================
1. Task 1 - File Data Processor
2. Task 2 - File Data Processing Asynchronously
3. Task 3 - Basic Stream usage
4. Task 4 - Asynchronous File Logging
5. Task 5 - Exit
=================================");
                TaskOptions? option = UserInput.ReadEnum<TaskOptions>("Enter a choice: ");
                switch (option)
                {
                    case TaskOptions.FileDataProcessor:
                        {
                            this._fileDataProcessor.ExecuteDataProcessor();
                            break;
                        }

                    case TaskOptions.AsyncFileDataProcessor:
                        {
                            this._asyncFileDataProcessor.ExecuteAsyncFileDataProcessor().GetAwaiter().GetResult();
                            break;
                        }

                    case TaskOptions.BasicFileOperations:
                        {
                            this._basicFileUsage.ExecuteBasicFileUsage();
                            break;
                        }

                    case TaskOptions.Logger:
                        {
                            this._users.Run().GetAwaiter().GetResult();
                            break;
                        }

                    case TaskOptions.Exit:
                        {
                            state = false;
                            break;
                        }
                }

                UserInput.WaitAndClear();
            }
        }
    }
}
