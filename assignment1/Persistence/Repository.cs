using Assignment1.Model;

namespace Assignment1.Persistence
{
    /// <summary>
    /// this is a repository class
    /// </summary>
    public class Repository
    {
        private readonly List<ContactInfo> _contactList = new List<ContactInfo>();

        /// <summary>
        /// This creates contact in the _contact list
        /// </summary>
        /// <param name="contact"> this is the contact that should bee added to the list</param>
        public void AddContact(ContactInfo contact)
        {
            this._contactList.Add(contact);
        }

        /// <summary>
        /// This deletes the contact in the _contact list
        /// </summary>
        /// <param name="id"> this is the guid of the contactName that should be deleted to the list</param>
        public void DeleteContact(Guid id)
        {
            ContactInfo? record = null;
            foreach (ContactInfo contact in this._contactList)
            {
                if (contact.Id == id)
                {
                    record = contact;
                    break;
                }
            }

            if (record == null)
            {
                return;
            }

            this._contactList.Remove(record);
        }

        /// <summary>
        /// This updates the contact in the _contact list
        /// </summary>
        /// <param name="contactName"> this is the contactName that should be updated to the list</param>
        /// <returns>The contact list.</returns>
        public List<ContactInfo> ViewContact()
        {
            return this._contactList.Select(c => new ContactInfo
         {
             Name = c.Name,
             Email = c.Email,
             Contact = c.Contact,
             Description = c.Description,
             Id = c.Id,
         })
         .ToList();
        }

        /// <summary>
        /// This is update contact function that updates the specific entry
        /// </summary>
        /// <param name="contact"> the updated entry </param>
        /// <param name="id"> the guid to be updated </param>
        public void UpdateContact(ContactInfo contact, Guid id)
        {
            ContactInfo? record = null;
            foreach (var entry in this._contactList)
            {
                if (entry.Id == id)
                {
                    record = entry;
                }
            }

            if (record == null)
            {
                return;
            }

            record.Name = contact.Name;
            record.Contact = contact.Contact;
            record.Description = contact.Description;
            record.Email = contact.Email;
        }

        /// <summary>
        /// method to search
        /// </summary>
        /// <param name="choice"> using which parameter the search happens</param>
        /// <param name="value"> what is the value to be searched </param>
        /// <returns>list of found records </returns>
        public List<ContactInfo>? Search(string? choice, string? value)
        {
            List<ContactInfo> result = new List<ContactInfo>();
            if (choice == null || value == null || this._contactList == null)
            {
                return null;
            }

            switch (choice.ToLower())
                {
                    case "n":
                        {
                            foreach (var entry in this._contactList)
                            {
                                if (entry.Name != null && entry.Name.Contains(value, StringComparison.OrdinalIgnoreCase))
                                {
                                    result.Add(entry);
                                }
                            }

                            return result;
                        }

                    case "e":
                        {
                            foreach (var entry in this._contactList)
                            {
                                if (entry.Email != null && entry.Email.Contains(value, StringComparison.OrdinalIgnoreCase))
                            {
                                    result.Add(entry);
                                }
                            }

                            return result;
                        }

                    case "c":
                        {
                            foreach (var entry in this._contactList)
                            {
                                if (entry.Contact != null && entry.Contact.Contains(value, StringComparison.OrdinalIgnoreCase))
                            {
                                    result.Add(entry);
                                }
                            }

                            return result;
                        }

                    default: return null;
                }
        }
    }
}
