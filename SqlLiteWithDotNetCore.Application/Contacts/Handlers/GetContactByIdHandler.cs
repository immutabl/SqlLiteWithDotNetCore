using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;
using SqlLiteWithDotNetCore.Application.Contacts.Queries;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class GetContactByIdHandler: IGetContactById
    {
        private readonly ILogger<GetContactByIdHandler> _logger;
        private readonly IContactRepository _repo;

        public GetContactByIdHandler(ILogger<GetContactByIdHandler> logger, IContactRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<ContactDto?> HandleAsync(GetContactByIdQuery query)
        {
            var contact = await _repo.GetContactByIdAsync(query.Id);

            if (contact is null)
            {
                _logger.LogWarning("Contact with Id {Id} not found.", query.Id);
                return null;
            }

            return new ContactDto(contact.Id, contact.Forename, contact.Surname, contact.Email, contact.Telno,
                contact.CountryId, contact.Country.CountryCode);
        }
    }
}
