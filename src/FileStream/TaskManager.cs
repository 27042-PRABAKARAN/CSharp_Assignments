using FilleHandling.Enums;

namespace FilleHandling
{
    internal class TaskManager
    {
        private readonly FileDataProcessor _fileDataProcessor;

        public TaskManager(FileDataProcessor fileDataProcessor)
        {
            this._fileDataProcessor = fileDataProcessor;
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
            }
            UserInput.WaitAndClear();
        }
    }
}
