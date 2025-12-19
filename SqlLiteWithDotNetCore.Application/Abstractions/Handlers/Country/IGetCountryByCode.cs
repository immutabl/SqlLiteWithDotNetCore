using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;
using SqlLiteWithDotNetCore.Application.Contacts.Queries;
using SqlLiteWithDotNetCore.Application.Country;
using SqlLiteWithDotNetCore.Application.Country.Dto;
using SqlLiteWithDotNetCore.Application.Country.Queries;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact
{
    public interface IGetCountryByCode
    {
        Task<CountryDto?> HandleAsync(GetCountryByCodeQuery query);
    }
}
