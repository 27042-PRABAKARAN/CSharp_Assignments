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
        private static List<ContactInfo> _contactList = new List<ContactInfo>();

        /// <summary>
        /// This creates contact in the _contact list
        /// </summary>
        /// <param name="contact"> this is the contact that should bee added to the list</param>
        public static void AddContact(ContactInfo contact)
        {
            _contactList.Add(contact);
        }

        /// <summary>
        /// This updates the contact in the _contact list
        /// </summary>
        /// <param name="index"> this is the contactName that should be updated to the list</param>
        public static void DeleteContact(int index)
        {
                _contactList.RemoveAt(index);
        }

        /// <summary>
        /// This updates the contact in the _contact list
        /// </summary>
        /// <param name="contactName"> this is the contactName that should be updated to the list</param>
        /// <returns>The contact list.</returns>
        public static List<ContactInfo> ViewContact()
        {
            return new List<ContactInfo>(_contactList);
        }

        /// <summary>
        /// This is update contact function that updates the specific entry
        /// </summary>
        /// <param name="contact"> the updated entry </param>
        /// <param name="index"> the index to be updated </param>
        public static void UpdateContact(ContactInfo contact, int index)
        {
            _contactList[index] = contact;
        }
    }
}
