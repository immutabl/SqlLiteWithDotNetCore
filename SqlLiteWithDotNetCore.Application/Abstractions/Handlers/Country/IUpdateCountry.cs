using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;
using SqlLiteWithDotNetCore.Application.Country.Commands;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contacts
{
    public interface IUpdateCountry
    {
        Task HandleAsync(UpdateCountryCommand cmd);
    }
}
