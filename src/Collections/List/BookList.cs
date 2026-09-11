namespace Collections.List
{
    /// <summary>
    /// To Store and manipulate Book list
    /// </summary>
    internal class BookList
    {
        /// <summary>
        /// To Execute List operations
        /// </summary>
        public void ExecuteList()
        {
            GenericList<string> books = new ();
            Console.WriteLine("Adding 5 books");
            books.Add("Harry potter - philosopher stone");
            books.Add("Harry potter - Chamber of secretes");
            books.Add("Harry potter - Goblet of fire");
            books.Add("Harry potter - Order of phoenix");
            books.Add("Harry potter - Half blood prince ");
            books.DisplayAll();
            books.Remove("Harry potter - philosopher stone");
            Console.WriteLine("Removed the book Harry potter - philosopher stone");
            books.DisplayAll();
            IReadOnlyList<string> filteredBooks = books.Find("Harry");
            Console.WriteLine($"Found {filteredBooks.Count} books containing 'Harry':");
            foreach (string book in filteredBooks)
            {
                Console.WriteLine(book);
            }
        }
    }
}
