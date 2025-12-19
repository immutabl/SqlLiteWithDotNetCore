using SqlLiteWithDotNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Persistence
{
    public interface IContactRepository
    {
        Task CreateContactAsync(Contact contact);

        Task UpdateContactAsync(Contact contact);

        Task<IEnumerable<Contact>> GetAllContactsAsync();

        Task<Contact?> GetContactByIdAsync(int id);

        Task DeleteContact(int id);
    }
}
