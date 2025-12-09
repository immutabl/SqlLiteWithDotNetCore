using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateContact(Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateContact(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public async Task<Contact> GetContactById(int id)
        {
            var contact = await _dbContext.Contacts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (contact != null)
            {
                return contact;
            }

            Console.WriteLine($"No contact found with Id: {id}");
            return new Contact();
            
        }

        public async Task DeleteContact(int id)
        {
            _dbContext.Remove(id);
            await _dbContext.SaveChangesAsync();
        }
    }
}
