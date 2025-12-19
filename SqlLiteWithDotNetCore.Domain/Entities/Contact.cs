namespace SqlLiteWithDotNetCore.Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Telno { get; set; }

        public int CountryId { get; set; }    //Foreign Key
        public Country Country { get; set; }
    }
}
