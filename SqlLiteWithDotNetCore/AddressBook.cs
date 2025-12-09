using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore
{
    public class AddressBook
    {
        public IEnumerable<Contact> Contacts { get; set; } = new List<Contact>();

        internal static void UpdateContact()
        {
            throw new NotImplementedException();
        }

        public static void AddContact()
        {
            throw new NotImplementedException();
        }

        internal static void DeleteContact()
        {
            throw new NotImplementedException();
        }

        internal static void NewContact()
        {
            throw new NotImplementedException();
        }

        internal static void ViewAllContacts()
        {
            throw new NotImplementedException();
        }
    }
}
