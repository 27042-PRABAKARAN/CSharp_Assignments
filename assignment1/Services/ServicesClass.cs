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
    public class ServicesClass
    {
        /// <summary>
        /// instance of the repository class
        /// </summary>
        private RepositoryClass _repository = new RepositoryClass();

        /// <summary>
        /// this is the method service to Add a contact.
        /// </summary>
        /// <param name="name">the name of the contact </param>
        /// <param name="email"> the email of the contact </param>
        /// <param name="contact"> the phone number of the contact </param>
        /// <param name="description"> the descripion of the contact</param>
        /// <returns> return the boolean of has added or not</returns>
        public bool AddContacts(string name, string email, string contact, string description)
        {
            ContactInfo newContactInfo = new ContactInfo();
            newContactInfo.Name = name;
            if (Validation.IsValidEmail(email))
            {
                newContactInfo.Email = email;
            }

            if (Validation.ValidatingContact(contact))
            {
                newContactInfo.Contact = contact;
            }
            else
            {
                return false;
            }

            newContactInfo.Description = description;
            Guid id = Guid.NewGuid();
            newContactInfo.Id = id;
            this._repository.AddContact(newContactInfo);
            return true;
        }

        /// <summary>
        /// this is the view contacts service method.
        /// </summary>
        /// <returns> the list of the contacts </returns>
        public List<ContactInfo> ViewContacts()
        {
            List<ContactInfo> contacts = this._repository.ViewContact();
            return contacts;
        }

        /// <summary>
        /// This is the edit service
        /// </summary>
        /// <param name="choice"> which property is edited </param>
        /// <param name="index"> which is index </param>
        /// <param name="value"> what is the new value to be updated</param>
        /// <returns> boolean of successful edit or not </returns>
        public bool EditContact(string choice, int index, string value)
        {
            List<ContactInfo> contacts = this._repository.ViewContact();
            switch (choice.ToLower())
            {
                case "n":
                    contacts[index].Name = value; this._repository.UpdateContact(contacts[index], index); return true;
                case "e":
                    if (!Validation.IsValidEmail(value))
                    {
                        return false;
                    }

                    contacts[index].Email = value; this._repository.UpdateContact(contacts[index], index); return true;
                case "c":
                    if (!Validation.ValidatingContact(value))
                    {
                        return false;
                    }

                    contacts[index].Name = value; this._repository.UpdateContact(contacts[index], index); return true;
                case "d":
                    contacts[index].Description = value; this._repository.UpdateContact(contacts[index], index); return true;
                default: return false;
            }
        }

        /// <summary>
        /// Search contact service method is here
        /// </summary>
        /// <param name="choice"> search by using name email or contact </param>
        /// <param name="value"> the value of the choice </param>
        /// <returns> return the entry found </returns>
        public ContactInfo SearchContact(string choice, string value)
        {
            List<ContactInfo> contact = this.ViewContacts();
            switch (choice.ToLower())
            {
                case "n":
                    {
                        foreach (var entry in contact)
                        {
                            if (entry.Name == value)
                            {
                                return entry;
                            }
                        }
                    }

                    break;
                case "e":
                    {
                        foreach (var entry in contact)
                        {
                            if (entry.Email == value)
                            {
                                return entry;
                            }
                        }
                    }

                    break;
                case "c":
                    {
                        foreach (var entry in contact)
                        {
                            if (entry.Contact == value)
                            {
                                return entry;
                            }
                        }
                    }

                    break;
                default: return new ContactInfo();
            }

            return new ContactInfo();
        }

        /// <summary>
        /// this is the Sort Contact Method to sort the contacts.
        /// </summary>
        public void SortContacts()
        {
            this._repository.SortContact();
        }

        /// <summary>
        /// this is the DeleteContact service which deletes the entry.
        /// </summary>
        /// <param name="id"> the Guid of the contact to be deleted</param>
        public void DeleteContact(Guid id)
        {// Deleting a contact using the Sno of displayed list
            List<ContactInfo> contacts = this.ViewContacts();
            ContactInfo deleteContact = new ContactInfo();
            foreach (ContactInfo entry in contacts)
            {
                if (entry.Id == id)
                {
                    deleteContact = entry;
                    break;
                }
            }

            this._repository.DeleteContact(deleteContact);
        }
    }
}
