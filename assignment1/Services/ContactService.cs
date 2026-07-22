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
    public class ContactService
    {
        /// <summary>
        /// instance of the repository class
        /// </summary>
        private readonly ContactRepository _contactRepository = new ContactRepository();

        /// <summary>
        /// this is the method service to Add a contact.
        /// </summary>
        /// <param name="name">the name of the contact </param>
        /// <param name="email"> the email of the contact </param>
        /// <param name="contact"> the phone number of the contact </param>
        /// <param name="description"> the descripion of the contact</param>
        public void Create(string? name, string? email, string? contact, string? description)
        {
            ContactInfo newContactInfo = new ContactInfo();
            newContactInfo.Name = name;
            newContactInfo.Contact = contact;
            newContactInfo.Email = email;
            newContactInfo.Description = description;
            Guid id = Guid.NewGuid();
            newContactInfo.Id = id;
            this._contactRepository.Add(newContactInfo);
        }

        /// <summary>
        /// this is the view contacts service
        /// </summary>
        /// <returns> the list of the contacts </returns>
        public List<ContactInfo> Fetch()
        {
            List<ContactInfo> contacts = this._contactRepository.Fetch();
            return contacts;
        }

        /// <summary>
        /// This is the edit service
        /// </summary>
        /// <param name="choice"> which property is edited </param>
        /// <param name="id"> which is guid of the specific record </param>
        /// <param name="value"> what is the new value to be updated</param>
        /// <returns> boolean of successful edit or not </returns>
        public bool Edit(string? choice, Guid id, string? value)
        {
            ContactInfo? record = this.GetContactById(id);
            if (record == null)
            {
                return false;
            }

            if (choice != null)
            {
                int.TryParse(choice, out int index);
                Choice editChoice = (Choice)index;
                switch (editChoice)
                {
                    case Choice.Name:
                        record.Name = value;
                        return this._contactRepository.Update(record, record.Id);
                    case Choice.Email:
                        if (!Validation.IsValidEmail(value))
                        {
                            return false;
                        }

                        record.Email = value;
                        this._contactRepository.Update(record, record.Id);
                        return this._contactRepository.Update(record, record.Id);
                    case Choice.Contact:
                        if (!Validation.IsValidContact(value))
                        {
                            return false;
                        }

                        record.Contact = value;
                        return this._contactRepository.Update(record, record.Id);
                    case Choice.Description:
                        record.Description = value;
                        return this._contactRepository.Update(record, record.Id);
                    default: return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Search contact service method is here
        /// </summary>
        /// <param name="choice"> search by using name email or contact </param>
        /// <param name="value"> the value of the choice </param>
        /// <returns> return the entry found </returns>
        public List<ContactInfo>? Search(Choice choice, string? value)
        {
            return this._contactRepository.Search(choice, value);
        }

        /// <summary>
        /// this is the DeleteContact service which deletes the entry.
        /// </summary>
        /// <param name="id"> the guid of the contact to be deleted</param>
        /// <returns> returns boolean value</returns>
        public bool Delete(Guid id)
        {
            return this._contactRepository.Delete(id);
        }

        /// <summary>
        /// to get the object matching the id
        /// </summary>
        /// <param name="id"> the guid of the object </param>
        /// <returns> the object found </returns>
        private ContactInfo? GetContactById(Guid id)
        {
            foreach (var entry in this._contactRepository.Fetch())
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }

            return null;
        }
    }
}
