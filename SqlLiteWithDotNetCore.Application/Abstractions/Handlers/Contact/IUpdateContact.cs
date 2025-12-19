using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact
{
    public interface IUpdateContact
    {
        Task HandleAsync(UpdateContactCommand cmd);
    }
}
