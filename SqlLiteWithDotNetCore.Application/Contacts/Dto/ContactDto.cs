using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Contacts.Dto
{
    public record ContactDto(int Id, string Forename, string Surname, string Email, string Telno, int CountryId, string CountryCode);

}