using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Contracts.Contacts
{
    public sealed record ContactDto(string Forename, string Surname, string Email, string Telno);



}