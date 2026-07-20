using System;
using System.Collections.Generic;
using Assignment1.Helper;
using Assignment1.Model;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// Enum Operations created
    /// </summary>
    /// <value>
    /// Converts user choice to meaningful operations
    /// </value>
    internal enum Operation
    {
        /// <summary>
        /// Add operation
        /// </summary>
        Add = 1,

        /// <summary>
        /// View Operation
        /// </summary>
        View,

        /// <summary>
        /// Search Operation
        /// </summary>
        Search,

        /// <summary>
        /// Edit operation
        /// </summary>
        Edit,

        /// <summary>
        /// Delete operation
        /// </summary>
        Delete,

        /// <summary>
        /// Exiting
        /// </summary>
        Exit,
    }

    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Service object for service class
        /// </summary>
        private static Service _service = new Service();

        /// <summary>
        /// funtion to print all the available operation.
        /// </summary>
        public static void PrintOperationsAvailable()
        {
            Output.Display(
                "\n1. Add a contact.\n" +
                "2. View all contacts.\n" +
                "3. Search a contact.\n" +
                "4. Edit a contact.\n" +
                "5. Delete a contact.\n" +
                "6. type exit to exit the app.\n");
        }

        /// <summary>
        /// method to add contact
        /// </summary>
        public static void AddContacts()
        {
            Output.Display("Enter Name: ");
            string? name = UserInput.Input();
            Output.Display("Enter Email: ");
            string? email = UserInput.Input();
            Output.Display("Enter Contact: ");
            string? contact = UserInput.Input();
            Output.Display("Enter Description: ");
            string? description = UserInput.Input();
            bool added = _service.Create(name, email, contact, description);
            if (added)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Output.Display("Added Successfully\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Output.Display("Enter proper Name ,Contact and Email\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// created view Contacts function
        /// </summary>
        public static void ViewContacts()
        {
            List<ContactInfo> contacts = _service.View();
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            Output.Display("\nComplete contact list : ");
            Output.ShowList(contacts);
            Output.Display("end of list\n");
        }

        /// <summary>
        /// This is the Search Contact function.
        /// </summary>
        public static void SearchContact()
        {
            Output.Display("Searching Contact");
            Output.Display("Search using\n [N]ame \n [C]ontact \n [E]mail");
            string? choice = UserInput.Input();
            if (choice != null)
            {
                switch (choice.ToLower())
                {
                    case "n":
                        {
                            bool found = true;
                            Output.Display("Enter name : ");
                            string? userchoice = UserInput.Input();
                            List<ContactInfo>? records = _service.Search("n", userchoice);
                            if (records == null)
                            {
                                found = false;
                            }

                            if (found == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Output.Display("Not found");
                                Console.ResetColor();
                            }
                            else
                            {
                                Output.ShowList(records);
                            }

                            break;
                        }

                    case "c":
                        {
                            bool found = true;
                            Output.Display("Enter Contact Number : ");
                            string? userchoice = UserInput.Input();
                            List<ContactInfo>? records = _service.Search("c", userchoice);
                            if (records == null)
                            {
                                found = false;
                            }

                            if (found == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Output.Display("Not found");
                                Console.ResetColor();
                            }
                            else
                            {
                                Output.ShowList(records);
                            }

                            break;
                        }

                    case "e":
                        {
                            bool found = true;
                            Output.Display("Enter Email : ");
                            string? userchoice = UserInput.Input();
                            List<ContactInfo>? records = _service.Search("e", userchoice);
                            if (records == null)
                            {
                                found = false;
                            }

                            if (found == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Output.Display("Not found");
                                Console.ResetColor();
                            }
                            else
                            {
                                Output.ShowList(records);
                            }

                            break;
                        }

                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Output.Display("Enter a valid choice\n"); 
                            Console.ResetColor();
                            break;
                        }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Output.Display("Enter a valid choice\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// funtion to Delete a contact.
        /// </summary>
        public static void DeleteContact()
        {
            Output.Display("Deleting a contact");
            List<ContactInfo> contact = _service.View();
            contact.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            ViewContacts();
            Output.Display("Enter the Sno:");
            string? deleteContactindex = UserInput.Input();
            int index;
            int length = contact.Count();
            if (int.TryParse(deleteContactindex, out index) && index > 0 && index <= length)
            {
                index = index - 1;

                _service.Delete(contact[index].Id);
                Console.ForegroundColor = ConsoleColor.Green;
                Output.Display("Deleted Succesfully\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Output.Display("Invalid number entered.\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// this is the edit contact function
        /// </summary>
        public static void EditContact()
        {
            Output.Display("Editing contact");
            ViewContacts();
            List<ContactInfo> contacts = _service.View();
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            Output.Display("Enter the Sno: ");
            string? editContactindex = UserInput.Input();
            int index;
            if (int.TryParse(editContactindex, out index) && index > 0 && index <= _service.View().Count())
            {
                index = index - 1;
                Output.Display("Edit the ");
                Output.Display("[N]ame\n[E]mail\n[C]ontact\n[D]escription\n");
                string? choice = UserInput.Input();
                Output.Display("Enter new Value: ");
                string? value = UserInput.Input();
                bool edited = _service.Edit(choice, contacts[index].Id, value);
                if (edited)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Output.Display("Edited Succesfully\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Output.Display("Enter proper choice/value");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Output.Display("Enter a valid Sno\n");
                Console.ResetColor();
            }
        }

        private static void Main(string[] args)
        {
                bool endApp = false;
                Output.Display("Welcome to contact manager");
                while (!endApp)
                {
                    PrintOperationsAvailable();
                    Output.Display("Enter a Number of the choice : ");
                    string? choice = UserInput.Input();
                    if (choice == null)
                    {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Output.Display("Enter a valid choice");
                    Console.ResetColor();
                    continue;
                    }

                    int.TryParse(choice, out int index);
                    Operation operation = (Operation)index;
                    switch (operation)
                    {
                        case Operation.Add: AddContacts(); break;
                        case Operation.View: ViewContacts(); break;
                        case Operation.Search: SearchContact(); break;
                        case Operation.Edit: EditContact(); break;
                        case Operation.Delete: DeleteContact(); break;
                        case Operation.Exit: endApp = true; break;
                        default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red; ;
                            Output.Display("Enter a valid choice");
                            Console.ResetColor();
                            break;
                        }
                    }
                }
        }
    }
}