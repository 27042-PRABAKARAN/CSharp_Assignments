using System.Collections.Generic;
namespace Assignments
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<List<string>> masterList = new List<List<string>>();
            bool endApp = false;
            Console.WriteLine("Welcome to contact manager");
            while (!endApp)
            {
                PrintOperationsAvailable();
                String userChoice = Console.ReadLine();
                switch (userChoice.ToLower())
                {
                    case "a": AddContact(); break;
                    case "v": ViewContact(); break;
                    case "s": SearchContact(); break;
                    case "e": EditContact(); break;
                    case "d": DeleteContact(); break;
                    case "exit": endApp = true; break;
                }
            }
            void DeleteContact()
            {
                Console.WriteLine("Deleting a contact");
                ViewContact();
                Console.WriteLine("Enter the Sno:");
                string deleteContactindex = Console.ReadLine();
                int index = int.Parse(deleteContactindex);
                masterList.RemoveAt(index - 1);
                Console.WriteLine("Deleted Succesfully");
            }
            void EditContact()
            {
                Console.WriteLine("Editing contact");
                Console.WriteLine("Edited Succesfully");
            }

            void SearchContact()
            {
                    Console.WriteLine("Searching Contact");
                }

            void ViewContact()
            {
                Console.WriteLine("viewing list of contacts");
                int i = 0;
                foreach (var entry in masterList)
                {
                    Console.Write(i + 1 + ".");
                    foreach (var item in entry)
                    {
                        Console.Write($"{item} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("end of list");
            }
            void AddContact()
            {
                List<string> newContact = new List<string>();
                Console.WriteLine("Adding a contact");
                Console.WriteLine("Enter name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter dob as (dd/mm/yyyy) : ");
                string dob = Console.ReadLine();
                Console.WriteLine("Enter phone : ");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter other details : ");
                string otherDetails = Console.ReadLine();
                newContact.Add(name);
                newContact.Add(dob);
                newContact.Add(phone);
                newContact.Add(otherDetails);
                masterList.Add(newContact);
                Console.WriteLine("Added succesfully");
            }

            static void PrintOperationsAvailable()
            {
                Console.WriteLine(
                    "1. [A]dd a contact.\n" +
                    "2. [V]iew all contacts.\n" +
                    "3. [S]earch a contact.\n" +
                    "4. [E]dit a contact.\n" +
                    "5. [D]elete a contact.\n" +
                    "5. type exit to exit the app.");
            }
        }
    }
}