namespace AdvancedConcepts.Tasks
{
    /// <summary>
    /// Demonstrates the usage and structural features of C# records, including value equality and non-destructive mutation.
    /// </summary>
    internal class Records
    {
        /// <summary>
        /// Represents an immutable book record with a title, author, and ISBN identifier.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="isbn">The unique International Standard Book Number (ISBN) for the book.</param>
        internal record Book(string title, string author, string isbn);

        /// <summary>
        /// Demonstrates record task functionality by comparing instances for value equality and utilizing the 'with' expression.
        /// </summary>
        internal void HandleTask6()
        {
            Book book1 = new Book("The Alchemist", "Paulo Coelho", "978-0061122415");
            Book book2 = new Book("Clean Code", "Robert C. Martin", "978-0132350884");
            Book duplicateOfBook2 = new Book("Clean Code", "Robert C. Martin", "978-0132350884");

            Console.WriteLine($"Checking value equality for record with different property: {book1 == book2}");
            Console.WriteLine($"Checking equality for record with `.Equals()`: {book1.Equals(book2)}\n");

            Console.WriteLine($"Checking value equality for record with different property: {duplicateOfBook2 == book2}");
            Console.WriteLine($"Checking equality for record with `.Equals()`: {duplicateOfBook2.Equals(book2)}\n");

            Book updatedBook = book1 with { title = "The Pilgrimage" };
            Console.WriteLine("Original Book:");
            this.DisplayBook(book1);

            Console.WriteLine("\nUpdated Book:");
            this.DisplayBook(updatedBook);
        }

        /// <summary>
        /// Deconstructs the given book record and displays its internal properties to the console.
        /// </summary>
        /// <param name="book1">The book record object to deconstruct and print.</param>
        private void DisplayBook(Book book1)
        {
            var (title, author, isbn) = book1;

            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"ISBN: {isbn}");
        }
    }
}
