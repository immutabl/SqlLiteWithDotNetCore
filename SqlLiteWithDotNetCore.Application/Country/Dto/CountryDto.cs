using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Country.Dto
{
    public sealed record CountryDto(int Id, string CountryCode, string Name, string DialingCode, string Capital);

}
