using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;
using SqlLiteWithDotNetCore.Application.Contacts.Queries;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact
{
    public interface IGetContactById
    {
        Task<ContactDto?> HandleAsync(GetContactByIdQuery query);
    }
}
