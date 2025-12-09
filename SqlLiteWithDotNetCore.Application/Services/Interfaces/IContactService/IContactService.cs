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
        void CreateContact(Contact contact);

        void UpdateContact(Contact contact);

        IEnumerable<Contact> GetAllContacts();

        Contact GetContactById(int id);

        void DeleteContact(int id);
    }
}
