using MemoryManagement.Models.Enums;
using MemoryManagement.Tasks;

namespace MemoryManagement
{
    /// <summary>
    /// Manages memory-related operations
    /// </summary>
    internal class MemoryHandler
    {
        private readonly ReferenceAndValueType _types;
        private readonly FileHandler _fileHandler;
        private readonly GcCollector _gcCollector;
        private readonly StackAndHeap _stackAndHeap;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryHandler"/> class.
        /// </summary>
        /// <param name="referenceAndValueType"> Instance of reference and value type</param>
        /// <param name="fileHandler"> Instance of file handler </param>
        /// <param name="gcCollector"> Instance of GC collector</param>
        /// <param name="stackAndHeap"> Instance of stack and heap memory handler</param>
        public MemoryHandler(ReferenceAndValueType referenceAndValueType, FileHandler fileHandler, GcCollector gcCollector, StackAndHeap stackAndHeap)
        {
            this._types = referenceAndValueType;
            this._fileHandler = fileHandler;
            this._gcCollector = gcCollector;
            this._stackAndHeap = stackAndHeap;
        }

        /// <summary>
        /// To navigate to required task
        /// </summary>
        public void ExecuteMemoryOperation()
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine(@"=====================================
1. Task 1 - ValueType Vs ReferenceType
2. Task 2 - Stack Memory vs Heap memory
3. Task 3 - Manual Garbage collection
4. Task 4 - Using KeyWord
5. Exit
=====================================");
                TaskOptions? option = UserInput.ReadEnum<TaskOptions>("Enter the choice: ");
                if (!option.HasValue)
                {
                    continue;
                }

                switch (option)
                {
                    case TaskOptions.ValueAndReferenceType:
                        {
                        this._types.ExecuteReferenceAndValueTypes();
                        break;
                        }

                    case TaskOptions.StackAndHeapMemory:
                        {
                            this._stackAndHeap.ExecuteStackAndHeap();
                            break;
                        }

                    case TaskOptions.GarbageCollection:
                        {
                            this._gcCollector.ExecuteGarbageCollector();
                            break;
                        }

                    case TaskOptions.UsingKeyWord:
                        {
                            this._fileHandler.ExecuteFileHandler();
                            break;
                        }

                    case TaskOptions.Exit:
                        {
                            state = false;
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Enter Valid Number");
                            break;
                        }
                }
                UserInput.WaitAndClear();
            }
        }
    }
}
