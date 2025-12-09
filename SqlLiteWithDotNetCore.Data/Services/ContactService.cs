using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Services.Interfaces.IContactService;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Data.Services
{
    public class ContactService: IContactService
    {
        private readonly SqlLiteWithDotNetCoreDbContext _dbContext;

        public ContactService(SqlLiteWithDotNetCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public Contact GetContactById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(int id)
        {
            throw new NotImplementedException();
        }
    }
}
