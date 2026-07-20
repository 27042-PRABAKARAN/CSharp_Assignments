namespace Assignment1.Services
{
    using System;
    using System.Collections.Generic;
    using Assignment1.Helper;
    using Assignment1.Model;
    using Assignment1.Persistence;

    /// <summary>
    /// Service class is for manipulating on list.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// instance of the repository class
        /// </summary>
        private readonly Repository _repository = new Repository();

        /// <summary>
        /// this is the method service to Add a contact.
        /// </summary>
        /// <param name="name">the name of the contact </param>
        /// <param name="email"> the email of the contact </param>
        /// <param name="contact"> the phone number of the contact </param>
        /// <param name="description"> the descripion of the contact</param>
        /// <returns> return the boolean of has added or not</returns>
        public bool CreateContact(string? name, string? email, string? contact, string? description)
        {
            ContactInfo newContactInfo = new ContactInfo();
            newContactInfo.Name = name;
            if (Validation.IsValidEmail(email))
            {
                newContactInfo.Email = email;
            }
            else
            {
                return false;
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
        public List<ContactInfo> ViewContact()
        {
            List<ContactInfo> contacts = this._repository.ViewContact();
            return contacts;
        }

        /// <summary>
        /// This is the edit service
        /// </summary>
        /// <param name="choice"> which property is edited </param>
        /// <param name="id"> which is guid of the specific record </param>
        /// <param name="value"> what is the new value to be updated</param>
        /// <returns> boolean of successful edit or not </returns>
        public bool EditContact(string? choice, Guid id, string? value)
        {
            ContactInfo? record = this.GetContactById(id);
            if (record == null)
            {
                return false;
            }

            if (choice != null)
            {
                switch (choice.ToLower())
                {
                    case "n":
                        record.Name = value;
                        this._repository.UpdateContact(record, record.Id);
                        return true;
                    case "e":
                        if (!Validation.IsValidEmail(value))
                        {
                            return false;
                        }

                        record.Email = value;
                        this._repository.UpdateContact(record, record.Id);
                        return true;
                    case "c":
                        if (!Validation.ValidatingContact(value))
                        {
                            return false;
                        }

                        record.Contact = value;
                        this._repository.UpdateContact(record, record.Id);
                        return true;
                    case "d":
                        record.Description = value;
                        this._repository.UpdateContact(record, record.Id);
                        return true;
                    default: return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// to get the object matching the id
        /// </summary>
        /// <param name="id"> the guid of the object </param>
        /// <returns> the object found </returns>
        public ContactInfo? GetContactById(Guid id)
        {
            foreach (var entry in this._repository.ViewContact())
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return null;
        }

        /// <summary>
        /// Search contact service method is here
        /// </summary>
        /// <param name="choice"> search by using name email or contact </param>
        /// <param name="value"> the value of the choice </param>
        /// <returns> return the entry found </returns>
        public List<ContactInfo>? SearchContact(string? choice, string? value)
        {
            return this._repository.Search(choice, value);
        }

        /// <summary>
        /// this is the DeleteContact service which deletes the entry.
        /// </summary>
        /// <param name="id"> the guid of the contact to be deleted</param>
        public void DeleteContact(Guid id)
        {
            this._repository.DeleteContact(id);
        }
    }
}
