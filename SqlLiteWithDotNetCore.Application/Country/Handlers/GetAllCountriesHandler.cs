using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contacts;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;
using SqlLiteWithDotNetCore.Application.Contacts.Queries;
using SqlLiteWithDotNetCore.Application.Country.Dto;

namespace SqlLiteWithDotNetCore.Application.Country.Handlers
{
    public class GetAllCountriesHandler: IGetAllCountries
    {
        private readonly ICountryRepository _repo;
        public async Task<CountriesDto> HandleAsync(GetAllContactsQuery query)
        {
            return new CountriesDto
            {
                Countries =(await _repo.GetAllAsync())
                    .Select(x=> new CountryDto(x.Id, 
                                                    x.CountryCode, 
                                                    x.Name, 
                                                    x.DialingCode, 
                                                    x.Capital
                                        )
                            )
                    .ToList()

            };
        }
    }
}
