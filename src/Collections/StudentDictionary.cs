namespace Collections
{
    /// <summary>
    /// Provides functionality to demonstrate dictionary operations
    /// </summary>
    internal class StudentDictionary
    {
        /// <summary>
        /// To execute Dictionary Operations
        /// </summary>
        public void ExecuteDictionary()
        {
            GenericDictionary<string, int> studentDictionary = new ();
            Console.WriteLine("Adding 5 Students to dictionary : ");
            studentDictionary.Add("Student - 1", 10);
            studentDictionary.Add("Student - 2", 9);
            studentDictionary.Add("Student - 3", 8);
            studentDictionary.Add("Student - 4", 9);
            studentDictionary.Add("Student - 5", 10);
            studentDictionary.DisplayAll();
            Console.WriteLine("Deleting 3 students");
            Console.WriteLine("Deleting Student - 1");
            studentDictionary.Remove("Student - 1");
            Console.WriteLine("Deleting Student - 2");
            studentDictionary.Remove("Student - 2");
            Console.WriteLine("Deleting Student - 3");
            studentDictionary.Remove("Student - 3");
            studentDictionary.DisplayAll();
        }
    }
}
