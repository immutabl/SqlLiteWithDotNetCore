using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;
using SqlLiteWithDotNetCore.Application.Contacts.Queries;
using SqlLiteWithDotNetCore.Application.Country.Dto;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contacts
{
    public interface IGetAllCountries
    {
        Task<CountriesDto> HandleAsync(GetAllContactsQuery query);
    }
}
