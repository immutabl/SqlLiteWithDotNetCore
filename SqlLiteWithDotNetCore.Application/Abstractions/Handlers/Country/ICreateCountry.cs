using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contacts
{
    public interface ICreateCountry
    {
        Task HandleAsync(CreateContactCommand cmd);
    }
}
