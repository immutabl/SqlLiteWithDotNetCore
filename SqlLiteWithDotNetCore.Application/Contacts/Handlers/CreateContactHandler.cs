using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class CreateContactHandler : ICreateContact
    {
        private readonly ILogger<CreateContactHandler> _logger;
        private readonly IContactRepository _contactRepository;
        private readonly ICountryRepository _countryRepository;

        public CreateContactHandler(ILogger<CreateContactHandler> logger, IContactRepository repo,
            ICountryRepository countryRepository)
        {
            _logger = logger;
            _contactRepository = repo;
            _countryRepository = countryRepository;
        }

        public async Task<ContactDto> HandleAsync(CreateContactCommand cmd)
        {
            var country = await _countryRepository.GetByCodeAsync(cmd.CountryCode);

            if (country == null)
            {
                throw new ValidationException("Invalid Country");
            }

            var contact = new Contact
            {
                Forename = cmd.Forename,
                Surname = cmd.Surname,
                Email = cmd.Email,
                Telno = cmd.Telno,
                CountryId = country.Id
            };

            await _contactRepository.CreateContactAsync(contact);

            return new ContactDto(contact.Id, contact.Forename, contact.Surname, contact.Email, contact.Telno,
                contact.CountryId, country.CountryCode);
        }
    }
}
