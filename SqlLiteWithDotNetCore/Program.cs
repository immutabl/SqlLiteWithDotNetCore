namespace SqlLiteWithDotNetCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Address Book. To continue please select a function:");


                Console.WriteLine("A - Add Contact\tD - Delete Contact\tU - Update Contact\nN - New Contact\tV - View All Contacts");

                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "A":
                        AddressBook.AddContact();
                        break;
                    case "D":
                        AddressBook.DeleteContact();
                        break;
                    case "U":
                        AddressBook.UpdateContact();
                        break;
                    case "N":
                        AddressBook.NewContact();
                        break;
                    case "V":
                        AddressBook.ViewAllContacts();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }

            }

            
        }
    }
}
