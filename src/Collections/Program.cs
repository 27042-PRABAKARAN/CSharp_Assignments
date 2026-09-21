using Collections.Dictionary;
using Collections.Enumerable;
using Collections.List;
using Collections.Queue;
using Collections.Stack;

namespace Collections
{
    /// <summary>
    /// Main entry point of the applications
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            StudentDictionary studentDictionary = new ();
            EnumerableDemo enumerableDemo = new EnumerableDemo();
            BookList bookList = new BookList();
            PeopleQueue peopleQueue = new PeopleQueue();
            CharacterStack characterStack = new CharacterStack();
            CollectionsManager collectionsManager = new CollectionsManager(enumerableDemo, bookList, peopleQueue, characterStack, studentDictionary);
            collectionsManager.Execute();
        }
    }
}
