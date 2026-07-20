using Assignment1.Helper;
using Assignment1.Model;
using Assignment1.Services;

namespace Assignment1
{
    /// <summary>
    /// the class where user operations are placed
    /// </summary>
    internal class UserOperation
    {
        /// <summary>
        /// Service object for service class
        /// </summary>
        private readonly Service _service = new Service();

        /// <summary>
        /// method to add contact
        /// </summary>
        public void AddContacts()
        {
            Output.Display("Enter Name: ");
            string? name = UserInput.ReadInput();
            Output.Display("Enter Email: ");
            string? email = UserInput.ReadInput();
            Output.Display("Enter Contact: ");
            string? contact = UserInput.ReadInput();
            Output.Display("Enter Description: ");
            string? description = UserInput.ReadInput();
            bool added = this._service.CreateContact(name, email, contact, description);
            if (added)
            {
                Output.PrintGreen("Added Successfully\n");
            }
            else
            {
                Output.PrintRed("Enter proper Name ,Contact and Email\n");
            }
        }

        /// <summary>
        /// created view Contacts function
        /// </summary>
        public void ViewContacts()
        {
            List<ContactInfo> contacts = this._service.ViewContact();
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            Output.Display("\nComplete contact list : ");
            Output.ShowList(contacts);
            Output.Display("end of list\n");
        }

        /// <summary>
        /// This is the Search Contact function.
        /// </summary>
        public void SearchContact()
        {
            Output.Display("Searching Contact : (Enter the letter) ");
            Output.Display("Search using\n [N]ame \n [C]ontact \n [E]mail");
            string? choice = UserInput.ReadInput();
            if (choice != null)
            {
                switch (choice.ToLower())
                {
                    case "n":
                        {
                            Output.Display("Enter name : ");
                            this.SearchByChoice("n");
                            break;
                        }

                    case "c":
                        {
                            Output.Display("Enter Contact Number : ");
                            this.SearchByChoice("c");
                            break;
                        }

                    case "e":
                        {
                            Output.Display("Enter Email : ");
                            this.SearchByChoice("e");
                            break;
                        }

                    default:
                        {
                            Output.PrintRed("Enter a valid choice\n");
                            break;
                        }
                }
            }
            else
            {
                Output.PrintRed("Enter a valid choice\n");
            }
        }

        /// <summary>
        /// function to search;
        /// </summary>
        /// <param name="type">Type of Search</param>
        public void SearchByChoice(string? type)
        {
            bool found = true;
            string? userchoice = UserInput.ReadInput();
            List<ContactInfo>? records = this._service.SearchContact(type, userchoice);
            if (records == null)
            {
                found = false;
            }

            if (found == false)
            {
                Output.PrintRed("Not found");
            }
            else
            {
                Output.ShowList(records);
            }
        }

        /// <summary>
        /// this is the edit contact function
        /// </summary>
        public void EditContact()
        {
            Output.Display("Editing contact");
            this.ViewContacts();
            List<ContactInfo> contacts = this._service.ViewContact();
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            Output.Display("Enter the Sno: ");
            string? editContactindex = UserInput.ReadInput();
            int index;
            if (int.TryParse(editContactindex, out index) && index > 0 && index <= contacts.Count())
            {
                index--;
                Output.Display("Edit the (Enter the letter)");
                Output.Display("[N]ame\n[E]mail\n[C]ontact\n[D]escription\n");
                string? choice = UserInput.ReadInput();
                Output.Display("Enter new Value: ");
                string? value = UserInput.ReadInput();
                bool edited = this._service.EditContact(choice, contacts[index].Id, value);
                if (edited)
                {
                    Output.PrintGreen("Edited Succesfully\n");
                }
                else
                {
                    Output.PrintRed("Enter proper choice/value");
                }
            }
            else
            {
                Output.PrintRed("Enter a valid Sno\n");
            }
        }

        /// <summary>
        /// funtion to Delete a contact.
        /// </summary>
        public void DeleteContact()
        {
            Output.Display("Deleting a contact");
            List<ContactInfo> contact = this._service.ViewContact();
            contact.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            this.ViewContacts();
            Output.Display("Enter the Sno:");
            string? deleteContactindex = UserInput.ReadInput();
            int index;
            int length = contact.Count();
            if (int.TryParse(deleteContactindex, out index) && index > 0 && index <= length)
            {
                index--;

                this._service.DeleteContact(contact[index].Id);
                Output.PrintGreen("Deleted Succesfully\n");
            }
            else
            {
                Output.PrintRed("Invalid number entered.\n");
            }
        }

        /// <summary>
        /// funtion to print all the available operation.
        /// </summary>
        public void PrintOperationsAvailable()
        {
            Output.Display(
                "\n1. Add a contact.\n" +
                "2. View all contacts.\n" +
                "3. Search a contact.\n" +
                "4. Edit a contact.\n" +
                "5. Delete a contact.\n" +
                "6. exit the app.\n");
        }
    }
}
