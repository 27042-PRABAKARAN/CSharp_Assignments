using FileHandling.Enums;

namespace FileHandling
{
    internal class TaskManager
    {
        private readonly FileDataProcessor _fileDataProcessor;
        private readonly AsyncFileDataProcessor _asyncFileDataProcessor;
        private readonly BasicFileUsage _basicFileUsage;
        private readonly Persons _users;

        public TaskManager(FileDataProcessor fileDataProcessor, AsyncFileDataProcessor asyncFileDataProcessor, BasicFileUsage basicFileUsage, Persons users)
        {
            this._fileDataProcessor = fileDataProcessor;
            this._asyncFileDataProcessor = asyncFileDataProcessor;
            this._basicFileUsage = basicFileUsage;
            this._users = users;
        }

        public void ExecuteTask()
        {
            Console.WriteLine(@"=================================
1. Task 1 - File Data Processor");
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
                        break;
                    }
            }

            UserInput.WaitAndClear();
        }
    }
}
