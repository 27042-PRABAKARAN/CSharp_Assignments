using System;
using System.Collections.Generic;
using Assignment1.Helper;
using Assignment1.Model;
using Assignment1.Repository;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Service object for service class
        /// </summary>
        private static ServicesClass _service = new ServicesClass();

        /// <summary>
        /// funtion to print all the available operation.
        /// </summary>
        public static void PrintOperationsAvailable()
        {
            DisplayClass.Display(
                "\n1. [A]dd a contact.\n" +
                "2. [V]iew all contacts.\n" +
                "3. [S]earch a contact.\n" +
                "4. [E]dit a contact.\n" +
                "5. [D]elete a contact.\n" +
                "6. type exit to exit the app.\n");
        }

        /// <summary>
        /// method to add contact
        /// </summary>
        public static void AddContacts()
        {
            DisplayClass.Display("Enter Name: ");
            string? name = InputClass.Input();
            DisplayClass.Display("Enter Email: ");
            string? email = InputClass.Input();
            DisplayClass.Display("Enter Contact: ");
            string? contact = InputClass.Input();
            DisplayClass.Display("Enter Description: ");
            string? description = InputClass.Input();
            bool added = _service.AddContacts(name, email, contact, description);
            if (added)
            {
                DisplayClass.Display("Added Successfully\n");
            }
            else
            {
                DisplayClass.Display("Enter proper Name ,Contact and Email\n");
            }
        }

        /// <summary>
        /// created view Contacts function
        /// </summary>
        public static void ViewContacts()
        {
            List<ContactInfo> contacts = _service.ViewContacts();
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            DisplayClass.Display("\nComplete contact list : ");
            DisplayClass.ShowList(contacts);
            DisplayClass.Display("end of list\n");
        }

        /// <summary>
        /// This is the Search Contact function.
        /// </summary>
        public static void SearchContact()
        {
            DisplayClass.Display("Searching Contact");
            DisplayClass.Display("Search using\n [N]ame \n [C]ontact \n [E]mail");
            string? choice = InputClass.Input();
            if (choice != null)
            {
                switch (choice.ToLower())
                {
                    case "n":
                        {
                            bool found = true;
                            DisplayClass.Display("Enter name : ");
                            string? userchoice = InputClass.Input();
                            List<ContactInfo>? records = _service.SearchContact("n", userchoice);
                            if (records == null)
                            {
                                found = false;
                            }

                            if (found == false)
                            {
                                DisplayClass.Display("Not found");
                            }
                            else
                            {
                                DisplayClass.ShowList(records);
                            }

                            break;
                        }

                    case "c":
                        {
                            bool found = true;
                            DisplayClass.Display("Enter Contact Number : ");
                            string? userchoice = InputClass.Input();
                            List<ContactInfo>? records = _service.SearchContact("c", userchoice);
                            if (records == null)
                            {
                                found = false;
                            }

                            if (found == false)
                            {
                                DisplayClass.Display("Not found");
                            }
                            else
                            {
                                DisplayClass.ShowList(records);
                            }

                            break;
                        }

                    case "e":
                        {
                            bool found = true;
                            DisplayClass.Display("Enter Email : ");
                            string? userchoice = InputClass.Input();
                            List<ContactInfo>? records = _service.SearchContact("e", userchoice);
                            if (records == null)
                            {
                                found = false;
                            }

                            if (found == false)
                            {
                                DisplayClass.Display("Not found");
                            }
                            else
                            {
                                DisplayClass.ShowList(records);
                            }

                            break;
                        }

                    default: DisplayClass.Display("Enter a valid choice\n"); break;
                }
            }
            else
            {
                DisplayClass.Display("Enter a valid choice\n");
            }
        }

        /// <summary>
        /// funtion to Delete a contact.
        /// </summary>
        public static void DeleteContact()
        {
            DisplayClass.Display("Deleting a contact");
            List<ContactInfo> contact = _service.ViewContacts();
            contact.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            ViewContacts();
            DisplayClass.Display("Enter the Sno:");
            string? deleteContactindex = InputClass.Input();
            int index;
            int length = contact.Count();
            if (int.TryParse(deleteContactindex, out index) && index > 0 && index <= length)
            {
                index = index - 1;

                _service.DeleteContact(contact[index].Id);
                DisplayClass.Display("Deleted Succesfully\n");
            }
            else
            {
                DisplayClass.Display("Invalid number entered.\n");
            }
        }

        /// <summary>
        /// this is the edit contact function
        /// </summary>
        public static void EditContact()
        {
            DisplayClass.Display("Editing contact");
            ViewContacts();
            List<ContactInfo> contacts = _service.ViewContacts();
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            DisplayClass.Display("Enter the Sno: ");
            string? editContactindex = InputClass.Input();
            int index;
            if (int.TryParse(editContactindex, out index) && index > 0 && index <= _service.ViewContacts().Count())
            {
                index = index - 1;
                DisplayClass.Display("Edit the ");
                DisplayClass.Display("[N]ame\n[E]mail\n[C]ontact\n[D]escription\n");
                string? choice = InputClass.Input();
                DisplayClass.Display("Enter new Value: ");
                string? value = InputClass.Input();
                bool edited = _service.EditContact(choice, contacts[index].Id, value);
                if (edited)
                {
                    DisplayClass.Display("Edited Succesfully\n");
                }
                else
                {
                    DisplayClass.Display("Enter proper choice/value");
                }
            }
            else
            {
                DisplayClass.Display("Enter a valid Sno\n");
            }
        }

        private static void Main(string[] args)
        {
                bool endApp = false;
                DisplayClass.Display("Welcome to contact manager");
                while (!endApp)
                {
                    PrintOperationsAvailable();
                    DisplayClass.Display("Enter a choice : ");
                    string? choice = InputClass.Input();
                    if (choice == null)
                    {
                        DisplayClass.Display("Enter a valid choice");
                        continue;
                    }

                    switch (choice.ToLower())
                    {
                        case "a": AddContacts(); break;
                        case "v": ViewContacts(); break;
                        case "s": SearchContact(); break;
                        case "e": EditContact(); break;
                        case "d": DeleteContact(); break;
                        case "exit": endApp = true; break;
                        default: DisplayClass.Display("Enter a valid choice"); break;
                    }
                }
        }
    }
}