using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class UpdateContactHandler: IUpdateContact
    {
        private readonly IContactRepository _contactRepo;
        private readonly ICountryRepository _countryRepo;
        public UpdateContactHandler(IContactRepository contactRepo, ICountryRepository countryRepo)
        {
            _contactRepo = contactRepo;
            _countryRepo = countryRepo;
        }

        public async Task HandleAsync(UpdateContactCommand cmd)
        {
            var contact = await _contactRepo.GetContactByIdAsync(cmd.Id);
            var country = await _countryRepo.GetByCodeAsync(cmd.CountryCode);

            if (contact is null || country is null)
            {
                throw new Exception("Invalid command parameters were supplied");
            }

            contact.Forename = cmd.Forename;
            contact.Surname = cmd.Surname;
            contact.Email = cmd.Email;
            contact.Telno = cmd.Telno;
            contact.CountryId = country.Id;

            await _contactRepo.UpdateContactAsync(contact);
        }
    }
}
