using System;
using System.Collections.Generic;

namespace Assignments
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        private static List<List<string>> masterList = new List<List<string>>();

        /// <summary>
        /// main function.
        /// </summary>
        private static void Main(string[] args)
        {
            // the master list that is where all the data is stored and manipulated.
            bool endApp = false;
            Console.WriteLine("Welcome to contact manager");
            while (!endApp)
            {
                PrintOperationsAvailable();
                string? userChoice = Console.ReadLine();
                switch (userChoice.ToLower())
                {
                    case "a": AddContact(); break;
                    case "v": ViewContact(); break;
                    case "s": SearchContact(); break;
                    case "e": EditContact(); break;
                    case "d": DeleteContact(); break;
                    case "o": SortContact(); break;
                    case "exit": endApp = true; break;
                    default: Console.WriteLine("Enter a valid choice"); break;
                }
            }
        }

        /// <summary>
        /// funtion to print all the available operation.
        /// </summary>
        private static void PrintOperationsAvailable()
            {
                Console.WriteLine(
                    "1. [A]dd a contact.\n" +
                    "2. [V]iew all contacts.\n" +
                    "3. [S]earch a contact.\n" +
                    "4. [E]dit a contact.\n" +
                    "5. [D]elete a contact.\n" +
                    "6. [O]rder the contacts.\n"+
                    "7. type exit to exit the app.");
            }

        /// <summary>
        /// funtion to add a contact .
        /// </summary>
        private static void AddContact()
            { // adding a new contact
                List<string> newContact = new List<string>();
                Console.WriteLine("Adding a contact");
                Console.WriteLine("Enter name : ");
                string? name = Console.ReadLine();
                Console.WriteLine("Enter email: ");
                string? email = Console.ReadLine();
                Console.WriteLine("Enter phone : ");
                string? phone = Console.ReadLine();
                Console.WriteLine("Enter other details : ");
                string? otherDetails = Console.ReadLine();
                newContact.Add(name);
                newContact.Add(email);
                newContact.Add(phone);
                newContact.Add(otherDetails);
                masterList.Add(newContact);
                Console.WriteLine("Added succesfully");
            }

        /// <summary>
        /// funtion to view all contact .
        /// </summary>
        private static void ViewContact()
            { // displaying list of contact
                Console.WriteLine("viewing list of contacts");
                int i = 0;
                foreach (var entry in masterList)
                {
                    Console.Write((++i) + ".");
                    foreach (var item in entry)
                    {
                        Console.Write($"{item} ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine("end of list");
            }

        /// <summary>
        /// funtion to Search a contact.
        /// </summary>
        private static void SearchContact()
            { // Searching is implemented and can be searched using various parameters such as name contact  and email
                Console.WriteLine("Searching Contact");
                Console.WriteLine("Search using\n [N]ame \n [C]ontact \n [E]mail");
                string? choice = Console.ReadLine();
                switch (choice.ToLower())
                {
                    case "n":
                        {
                            bool found = false;
                            Console.WriteLine("Enter name : ");
                            string? userchoice = Console.ReadLine();
                            foreach (var entry in masterList)
                            {
                                if (entry[0] == userchoice)
                                {
                                    found = true;
                                    foreach (var item in entry)
                                    {
                                        Console.Write($"{item} ");
                                    }

                                    Console.WriteLine();
                                }
                            }

                            if (found == false)
                            {
                                Console.WriteLine("Not found");
                            }

                            break;
                        }

                    case "c":
                        {
                            bool found = false;
                            Console.WriteLine("Enter Contact : ");
                            string? userchoice = Console.ReadLine();
                            foreach (var entry in masterList)
                            {
                                if (entry[2] == userchoice)
                                {
                                    foreach (var item in entry)
                                    {
                                        found = true;
                                        Console.Write($"{item} ");
                                    }

                                    Console.WriteLine();
                                }
                            }

                            if (found == false)
                            {
                                Console.WriteLine("Not found");
                            }

                            break;
                        }

                    case "e":
                        {
                            bool found = false;
                            Console.WriteLine("Enter email: ");
                            string? userchoice = Console.ReadLine();
                            foreach (var entry in masterList)
                            {
                                if (entry[1] == userchoice)
                                {
                                    found = true;
                                    foreach (var item in entry)
                                    {
                                        Console.Write($"{item} ");
                                    }

                                    Console.WriteLine();
                                }
                            }

                            if (found == false)
                            {
                                Console.WriteLine("Not found");
                            }

                            break;
                        }

                    default: Console.WriteLine("Enter a valid choice"); break;
                }
            }

        /// <summary>
        /// funtion to Sort the contacts
        /// </summary>
        private static void SortContact()
            {
                Console.WriteLine("The Sorted list of contacts are : ");
                masterList.Sort((a, b) => string.Compare(a[0], b[0], StringComparison.Ordinal));
                ViewContact();
            }

        /// <summary>
        /// funtion to edit a contact.
        /// </summary>
        private static void EditContact()
            {// Editing a contact using the Sno of the displyed list
                Console.WriteLine("Editing contact");
                ViewContact();
                Console.WriteLine("Enter the Sno: ");
                string editContactindex = Console.ReadLine();
                int index;
                if (int.TryParse(editContactindex, out index) && index > 0 && index <= masterList.Count())
                {
                    Console.WriteLine("Enter name: ");
                    string? name = Console.ReadLine();
                    Console.WriteLine("Enter Email: ");
                    string? email = Console.ReadLine();
                    Console.WriteLine("Enter contact: ");
                    string? contact = Console.ReadLine();
                    Console.WriteLine("Enter Other details");
                    string? otherDetails = Console.ReadLine();
                    masterList[index - 1][0] = name;
                    masterList[index - 1][1] = email;
                    masterList[index - 1][2] = contact;
                    masterList[index - 1][3] = otherDetails;
                    Console.WriteLine("Edited Succesfully");
                }
                else
                {
                    Console.WriteLine("Enter a valid Sno");
                }
            }

        /// <summary>
        /// funtion to Delete a contact.
        /// </summary>
        private static void DeleteContact()
            {// Deleting a contact using the Sno of displayed list
                Console.WriteLine("Deleting a contact");
                ViewContact();
                Console.WriteLine("Enter the Sno:");
                string? deleteContactindex = Console.ReadLine();
                int index;
                if (int.TryParse(deleteContactindex, out index) && index >= 0 && index <= masterList.Count())
                {
                    masterList.RemoveAt(index - 1);
                    Console.WriteLine("Deleted Succesfully");
                }
                else
                {
                    Console.WriteLine("Invalid number entered.");
                }
            }
    }
}