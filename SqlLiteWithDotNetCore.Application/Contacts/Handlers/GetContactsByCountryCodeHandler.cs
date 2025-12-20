using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class GetContactsByCountryCodeHandler
    {
        private readonly ILogger<GetContactsByCountryCodeHandler> _logger;
        private readonly ICountryRepository _repo;

        public GetContactsByCountryCodeHandler(ILogger<GetContactsByCountryCodeHandler> logger, ICountryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        public async Task<ContactDto> HandleAsync(string countryCode)
        {
            throw new NotImplementedException();
        }
    }
}
