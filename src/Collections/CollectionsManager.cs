using Collections.Dictionary;
using Collections.Enumerable;
using Collections.List;
using Collections.Queue;
using Collections.Stack;

namespace Collections
{
    /// <summary>
    /// To manage and Execute appropriate Collection Execution
    /// </summary>
    internal class CollectionsManager
    {
        private readonly StudentDictionary _studentDictionary;

        private readonly EnumerableDemo _enumerableDemo;

        private readonly BookList _bookList;

        private readonly PeopleQueue _peopleQueue;

        private readonly CharacterStack _characterStack;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionsManager"/> class.
        /// </summary>
        /// <param name="enumerableDemo">Instance of Enumerable Demo</param>
        /// <param name="bookList"> Instance of Book List</param>
        /// <param name="peopleQueue"> Instance of PeopleQueue </param>
        /// <param name="characterStack"> Instance of character stack</param>
        /// <param name="studentDictionary"> Instance of student Dictionary</param>
        public CollectionsManager(EnumerableDemo enumerableDemo, BookList bookList, PeopleQueue peopleQueue, CharacterStack characterStack, StudentDictionary studentDictionary)
        {
            this._enumerableDemo = enumerableDemo;
            this._bookList = bookList;
            this._peopleQueue = peopleQueue;
            this._characterStack = characterStack;
            this._studentDictionary = studentDictionary;
        }

        /// <summary>
        /// Executes the main collection management loop.
        /// </summary>
        public void Execute()
        {
            TaskOptions? taskOption;

            do
            {
                Console.WriteLine(@"=======================================
1. Book List
2. Character Stack
3. People Queue
4. Student Dictionary
5. IEnumerable
6. Exit
=======================================");

                taskOption = UserInput.ReadEnum<TaskOptions>("Enter choice: ");

                switch (taskOption)
                {
                    case TaskOptions.BookList:
                        this._bookList.ExecuteList();
                        break;

                    case TaskOptions.CharacterStack:
                        this._characterStack.ExecuteStack();
                        break;

                    case TaskOptions.PeopleQueue:
                        this._peopleQueue.ExecutePeopleQueue();
                        break;

                    case TaskOptions.StudentDictionary:
                        this._studentDictionary.ExecuteDictionary();
                        break;

                    case TaskOptions.IEnumerable:
                        this._enumerableDemo.ExecuteIEnumerable();
                        break;

                    case TaskOptions.Exit:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                UserInput.WaitAndClear();
            }
            while (taskOption != TaskOptions.Exit);
        }
    }
}
