
namespace SqlLiteWithDotNetCore.Domain.Entities
{

    public class Country 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Capital { get; set; }
        public string DialingCode { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        public Country()
        {
            Contacts = new List<Contact>();
        }
    }
}
