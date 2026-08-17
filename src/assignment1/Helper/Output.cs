using Assignment1.Model;

namespace Assignment1.Helper
{
    /// <summary>
    /// Display class is used for displaying output
    /// </summary>
    public static class Output
    {
        /// <summary>
        /// to print the message in red
        /// </summary>
        /// <param name="message">the message that has to be printed in red</param>
        public static void Error(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// to print the message in Green
        /// </summary>
        /// <param name="message">the message that has to be printed in Green</param>
        public static void Success(string? message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Display funtion is present here
        /// </summary>
        /// <param name="text"> the content that has to be displayed </param>
        public static void Display(string? text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// ShowList funtion is present here
        /// </summary>
        /// <param name="contact"> the Contact that has to be displayed in right manner</param>
        public static void ShowList(List<ContactInfo>? contact)
        {
            if (contact == null)
            {
                return;
            }

            int i = 0;
            foreach (var entry in contact)
            {
                Console.WriteLine($"{++i}. {entry.Name} {entry.Email} {entry.Contact} {entry.Description}");
            }
        }
    }
}
