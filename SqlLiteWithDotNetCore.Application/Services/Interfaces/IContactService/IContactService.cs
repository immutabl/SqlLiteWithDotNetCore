using SqlLiteWithDotNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contracts.Contacts;

namespace SqlLiteWithDotNetCore.Application.Services.Interfaces.IContactService
{
    public interface IContactService
    {
        Task CreateContactAsync(Contact contact);

        Task UpdateContactAsync(Contact contact);

        Task<GetContactsDto> GetAllContactsAsync();

        Task<ContactDto?> GetContactByIdAsync(int id);

        Task DeleteContact(int id);
    }
}
