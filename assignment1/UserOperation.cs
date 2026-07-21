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
        private readonly ContactService _contact = new ContactService();

        /// <summary>
        /// add contact
        /// </summary>
        public void AddContacts()
        {
            int tries = 3;
            while (tries-- > 0)
            {
                Output.Display("Enter Name: ");
                string? name = UserInput.ReadInput();
                Output.Display("Enter Email: ");
                string? email = UserInput.ReadInput();
                Output.Display("Enter Contact: ");
                string? contact = UserInput.ReadInput();
                Output.Display("Enter Description: ");
                string? description = UserInput.ReadInput();
                bool added = this._contact.Create(name, email, contact, description);
                if (added)
                {
                    Output.Success("Added Successfully\n");
                    return;
                }
                else
                {
                    Output.Error("Enter proper Name ,Contact and Email\n");
                    Output.Error($"{tries} attempts remaining\n");
                }
            }
        }

        /// <summary>
        /// created view Contacts function
        /// </summary>
        public void ViewContacts()
        {
            List<ContactInfo> contacts = this._contact.Fetch();
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            if (contacts.Count() <= 0)
            {
                Output.Error("Empty List Nothing to Display");
                return;
            }

            Output.Display("\nComplete contact list : ");
            Output.ShowList(contacts);
            Output.Display("end of list\n");
        }

        /// <summary>
        /// This is the Search Contact function.
        /// </summary>
        public void SearchContact()
        {
            List<ContactInfo> contacts = this._contact.Fetch();
            if (contacts.Count() <= 0)
            {
                Output.Error("Empty List Nothing to Search");
                return;
            }

            int tries = 3;
            while (tries-- > 0)
            {
                Output.Display("Searching Contact : ");
                Output.Display("Search using\n 1.Name \n 2.Contact \n 3.Email");
                string? choice = UserInput.ReadInput();
                int.TryParse(choice, out int index);
                Choice searchChoice = (Choice)index;
                if (choice != null)
                {
                    switch (searchChoice)
                    {
                        case Choice.Name:
                            {
                                Output.Display("Enter name : ");
                                this.SearchByChoice(Choice.Name);
                                return;
                            }

                        case Choice.Contact:
                            {
                                Output.Display("Enter Contact Number : ");
                                this.SearchByChoice(Choice.Contact);
                                return;
                            }

                        case Choice.Email:
                            {
                                Output.Display("Enter Email : ");
                                this.SearchByChoice(Choice.Email);
                                return;
                            }

                        default:
                            {
                                Output.Error("Enter a valid choice\n");
                                Output.Error($"{tries} attempts remaining\n");
                                break;
                            }
                    }
                }
                else
                {
                    Output.Error("Enter a valid choice\n");
                    Output.Error($"{tries} attempts remaining\n");
                }
            }
        }

        /// <summary>
        /// function to search;
        /// </summary>
        /// <param name="type">Type of Search</param>
        public void SearchByChoice(Choice type)
        {
            bool found = true;
            string? userchoice = UserInput.ReadInput();
            List<ContactInfo>? records = this._contact.Search(type, userchoice);
            if (records == null || records.Count() <= 0)
            {
                found = false;
            }

            if (found == false)
            {
                Output.Error("Not found");
            }
            else
            {
                Output.ShowList(records);
            }
        }

        /// <summary>
        /// edit contact
        /// </summary>
        public void EditContact()
        {
            List<ContactInfo> contacts = this._contact.Fetch();
            if (contacts.Count() <= 0)
            {
                Output.Error("Empty List Nothing to Edit");
                return;
            }

            Output.Display("Editing contact");
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            int tries = 3;
            while (tries-- > 0)
            {
                this.ViewContacts();
                Output.Display("Enter the S.No: ");
                string? editContactindex = UserInput.ReadInput();
                int index;
                if (int.TryParse(editContactindex, out index) && index > 0 && index <= contacts.Count())
                {
                    index--;
                    int j = 3;
                    while (j-- > 0)
                    {
                        Output.Display("Edit the (Enter the letter)");
                        Output.Display("1.Name\n2.Email\n3.Contact\n4.Description\n");
                        string? choice = UserInput.ReadInput();
                        Output.Display("Enter new Value: ");
                        string? value = UserInput.ReadInput();
                        bool edited = this._contact.Edit(choice, contacts[index].Id, value);
                        if (edited)
                        {
                            Output.Success("Edited Succesfully\n");
                            return;
                        }
                        else
                        {
                            Output.Error($"{j} attempts remaining\n");
                            Output.Error("Enter proper choice/value");
                        }
                    }
                }
                else
                {
                    Output.Error($"{tries} attempts remaining\n");
                    Output.Error("Enter a valid S.no\n");
                }
            }
        }

        /// <summary>
        /// Delete a contact.
        /// </summary>
        public void DeleteContact()
        {
            List<ContactInfo> contacts = this._contact.Fetch();
            if (contacts.Count() <= 0)
            {
                Output.Error("Empty List Nothing to Delete");
                return;
            }

            Output.Display("Deleting a contact");
            contacts.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            this.ViewContacts();
            int tries = 3;
            while (tries-- > 0)
            {
                Output.Display("Enter the S.no:");
                string? deleteContactindex = UserInput.ReadInput();
                int index;
                int length = contacts.Count();
                if (int.TryParse(deleteContactindex, out index) && index > 0 && index <= length)
                {
                    index--;

                    this._contact.Delete(contacts[index].Id);
                    Output.Success("Deleted Succesfully\n");
                    return;
                }
                else
                {
                    Output.Error($"{tries} attempts remaining\n");
                    Output.Error("Invalid number entered.\n");
                }
            }
        }

        /// <summary>
        /// print all the available operation.
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
