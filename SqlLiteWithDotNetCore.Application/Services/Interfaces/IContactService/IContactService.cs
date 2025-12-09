using SqlLiteWithDotNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Services.Interfaces.IContactService
{
    public interface IContactService
    {
        Task CreateContact(Contact contact);

        Task UpdateContact(Contact contact);

        IEnumerable<Contact> GetAllContacts();

        Task<Contact> GetContactById(int id);

        Task DeleteContact(int id);
    }
}
