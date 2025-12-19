using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact
{
    public interface ICreateContact
    {
        Task<ContactDto> HandleAsync(CreateContactCommand cmd);
    }
}
