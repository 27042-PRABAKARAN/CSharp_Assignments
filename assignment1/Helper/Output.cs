using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Model;

namespace Assignment1.Helper
{
    /// <summary>
    /// Display class is used for displaying output
    /// </summary>
    public static class Output
    {
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
                Console.Write(++i + ". ");
                Console.Write(entry.Name + " ");
                Console.Write(entry.Email + " ");
                Console.Write(entry.Contact + " ");
                Console.Write(entry.Description + "\n");
            }
        }
    }
}
