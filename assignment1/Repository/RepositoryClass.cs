using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Model;

namespace Assignment1.Repository
{
    /// <summary>
    /// this is a repository class
    /// </summary>
    public class RepositoryClass
    {
        private List<ContactInfo> _contactList = new List<ContactInfo>();

        /// <summary>
        /// This creates contact in the _contact list
        /// </summary>
        /// <param name="contact"> this is the contact that should bee added to the list</param>
        public void AddContact(ContactInfo contact)
        {
            this._contactList.Add(contact);
        }

        /// <summary>
        /// This updates the contact in the _contact list
        /// </summary>
        /// <param name="contact"> this is the contactName that should be updated to the list</param>
        public void DeleteContact(ContactInfo contact)
        {
                this._contactList.Remove(contact);
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
        /// <param name="index"> the index to be updated </param>
        public void UpdateContact(ContactInfo contact, int index)
        {
            this._contactList[index] = contact;
        }

        /// <summary>
        /// this Sorts the contacts of the contact list
        /// </summary>
        public void SortContact()
        {
            this._contactList.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
