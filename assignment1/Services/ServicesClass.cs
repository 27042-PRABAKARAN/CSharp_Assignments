using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Helper;
using Assignment1.Model;
using Assignment1.Repository;

namespace Assignment1.Services
{
    /// <summary>
    /// Service class is for manipulating on list.
    /// </summary>
    public static class ServicesClass
    {
        /// <summary>
        /// Contact Management starts the program to run
        /// </summary>
        public static void ContactManagement()
        {
            bool endApp = false;
            DisplayClass.Display("Welcome to contact manager");
            while (!endApp)
            {
                PrintOperationsAvailable();
                string? choice = InputClass.Input();
                switch (choice.ToLower())
                {
                    case "a": AddContacts(); break;
                    case "v": ViewContacts(); break;
                    case "s": SearchContact(); break;
                    case "e": EditContact(); break;
                    case "d": DeleteContact(); break;
                    //case "o": SortContact(); break;
                    case "exit": endApp = true; break;
                    default: DisplayClass.Display("Enter a valid choice"); break;
                }
            }
        }

        /// <summary>
        /// funtion to print all the available operation.
        /// </summary>
        public static void PrintOperationsAvailable()
        {
            DisplayClass.Display(
                "1. [A]dd a contact.\n" +
                "2. [V]iew all contacts.\n" +
                "3. [S]earch a contact.\n" +
                "4. [E]dit a contact.\n" +
                "5. [D]elete a contact.\n" +
                "6. [O]rder the contacts.\n" +
                "7. type exit to exit the app.");
        }

        /// <summary>
        /// method to add contact
        /// </summary>
        public static void AddContacts()
        {
            ContactInfo newContactInfo = new ContactInfo();
            DisplayClass.Display("Enter Name: ");
            newContactInfo.Name = InputClass.Input();
            DisplayClass.Display("Enter Email: ");
            newContactInfo.Email = InputClass.Input();
            DisplayClass.Display("Enter Contact: ");
            newContactInfo.Contact = InputClass.Input();
            DisplayClass.Display("Enter Description: ");
            newContactInfo.Description = InputClass.Input();
            newContactInfo.Id = Guid.NewGuid();
            RepositoryClass.AddContact(newContactInfo);
            DisplayClass.Display("Added Successfully");
        }

        /// <summary>
        /// created view Contacts function
        /// </summary>
        public static void ViewContacts()
        {
            List<ContactInfo> contacts = RepositoryClass.ViewContact();
            DisplayClass.ShowList(contacts);
        }

        /// <summary>
        /// SearchContact function is here 
        /// </summary>
        public static void SearchContact()
        {
            DisplayClass.Display("Searching Contact");
            DisplayClass.Display("Search using\n [N]ame \n [C]ontact \n [E]mail");
            string? choice = InputClass.Input();
            List<ContactInfo> contacts = RepositoryClass.ViewContact();
            switch (choice.ToLower())
            {
                case "n":
                    {
                        bool found = false;
                        DisplayClass.Display("Enter name : ");
                        string? userchoice = InputClass.Input();
                        foreach (var entry in contacts)
                        {
                            if (entry.Name == userchoice)
                            {
                                found = true;
                                DisplayClass.Display("Name : " + entry.Name + " Email : " + entry.Email + " Contact :" + entry.Contact + " Description :" + entry.Description + "\n");
                            }
                        }

                        if (found == false)
                        {
                            DisplayClass.Display("Not found");
                        }

                        break;
                    }

                case "c":
                    {
                        bool found = false;
                        DisplayClass.Display("Enter Contact Number : ");
                        string? userchoice = InputClass.Input();
                        foreach (var entry in contacts)
                        {
                            if (entry.Contact == userchoice)
                            {
                                found = true;
                                DisplayClass.Display("Name : " + entry.Name + " Email : " + entry.Email + " Contact :" + entry.Contact + " Description :" + entry.Description + "\n");
                            }
                        }

                        if (found == false)
                        {
                            DisplayClass.Display("Not found");
                        }

                        break;
                    }

                case "e":
                    {
                        bool found = false;
                        DisplayClass.Display("Enter Email : ");
                        string? userchoice = InputClass.Input();
                        foreach (var entry in contacts)
                        {
                            if (entry.Email == userchoice)
                            {
                                found = true;
                                DisplayClass.Display("Name : " + entry.Name + " Email : " + entry.Email + " Contact :" + entry.Contact + " Description :" + entry.Description + "\n");
                            }
                        }

                        if (found == false)
                        {
                            DisplayClass.Display("Not found");
                        }

                        break;
                    }

                default: DisplayClass.Display("Enter a valid choice"); break;
            }
        }

        /// <summary>
        /// this is the edit contact function
        /// </summary>
        public static void EditContact()
        {
            DisplayClass.Display("Editing contact");
            ViewContacts();
            DisplayClass.Display("Enter the Sno: ");
            string editContactindex = InputClass.Input();
            int index;
            if (int.TryParse(editContactindex, out index) && index > 0 && index <= RepositoryClass.ViewContact().Count())
            {
                index = index - 1;
                DisplayClass.Display("Enter name: ");
                string? name = Console.ReadLine();
                DisplayClass.Display("Enter Email: ");
                string? email = Console.ReadLine();
                DisplayClass.Display("Enter contact: ");
                string? contact = Console.ReadLine();
                DisplayClass.Display("Enter Other details");
                string? otherDetails = Console.ReadLine();
                ContactInfo update = new ContactInfo();
                update.Name = name;
                update.Email = email;
                update.Contact = contact;
                update.Description = otherDetails;
                RepositoryClass.UpdateContact(update, index);
                DisplayClass.Display("Edited Succesfully");
            }
            else
            {
                DisplayClass.Display("Enter a valid Sno");
            }
        }

        /// <summary>
        /// funtion to Delete a contact.
        /// </summary>
        public static void DeleteContact()
        {// Deleting a contact using the Sno of displayed list
            DisplayClass.Display("Deleting a contact");
            ViewContacts();
            DisplayClass.Display("Enter the Sno:");
            string? deleteContactindex = InputClass.Input();
            int index;
            int length = RepositoryClass.ViewContact().Count();
            if (int.TryParse(deleteContactindex, out index) && index > 0 && index <= length)
            {
               index = index - 1;
               RepositoryClass.DeleteContact(index);
               DisplayClass.Display("Deleted Succesfully");
            }
            else
            {
                DisplayClass.Display("Invalid number entered.");
            }
        }
    }
}
