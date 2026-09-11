using Collections.Dictionary;

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
            studentDictionary.ExecuteDictionary();
            Console.ReadKey();
        }
    }
}
