using MemoryHandler.Enums;

namespace MemoryHandler
{
    internal class MemoryHandler
    {
        private readonly ExplodeMemory _memoryExploder;
        private readonly MemoryManager _memoryManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryHandler"/> class.
        /// </summary>
        /// <param name="memoryExploder"> instance of the class memoryExploder </param>
        /// <param name="memoryManager"> instance of the class memoryManager </param>
        public MemoryHandler(ExplodeMemory memoryExploder, MemoryManager memoryManager)
        {
            this._memoryExploder = memoryExploder;
            this._memoryManager = memoryManager;
        }

        /// <summary>
        /// To execute memory Operations
        /// </summary>
        public void ExecuteMemoryOperations()
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"============================================
1. Explode Memory.
2. Manage Memory.
3. Exit.
============================================");
                TaskOptions? taskOption = UserInput.ReadEnum<TaskOptions>("Enter a Choice: ");
                switch (taskOption)
                {
                    case TaskOptions.ExplodeMemory:
                        {
                            this._memoryExploder.AddMemory();
                            break;
                        }

                    case TaskOptions.ManageMemory:
                        {
                            this._memoryManager.AddMemory();
                            break;
                        }

                    case TaskOptions.Exit:
                        {
                            state = false;
                            break;
                        }

                    default:
                        {
                            ConsolePrinter.Error("Enter a valid choice.");
                            break;
                        }
                }
            }
        }
    }
}
