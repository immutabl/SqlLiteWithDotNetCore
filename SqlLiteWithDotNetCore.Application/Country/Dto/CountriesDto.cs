using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Country.Dto
{
    public sealed record CountriesDto
    {
        public List<CountryDto> Countries { get; init; } = new List<CountryDto>();

        public bool HasRecords => Countries.Any();
    }
}
