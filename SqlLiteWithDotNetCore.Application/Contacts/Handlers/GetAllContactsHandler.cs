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

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class GetAllContactsHandler: IGetAllContacts
    {
        private readonly ILogger<GetAllContactsHandler> _logger;
        private readonly IContactRepository _repo;

        public GetAllContactsHandler(ILogger<GetAllContactsHandler> logger, IContactRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<ContactsDto> HandleAsync(GetAllContactsQuery query)
        {
            var result = await _repo.GetAllContactsAsync();
            
            return new ContactsDto{
                Contacts = result.Select(x=> new ContactDto(
                    x.Id,
                    x.Forename,
                    x.Surname,
                    x.Email,
                    x.Telno,
                    x.CountryId,
                    x.Country.CountryCode
                    ))    
            };

        }
    }
}
