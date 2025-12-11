using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SqlLiteWithDotNetCore.Application.Contracts.Contacts;
using SqlLiteWithDotNetCore.Application.Services.Interfaces.IContactService;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Data.Services
{
    public class ContactService: IContactService
    {
        private readonly SqlLiteWithDotNetCoreDbContext _dbContext;
        private readonly ILogger<ContactService> _logger;

        public ContactService(SqlLiteWithDotNetCoreDbContext dbContext, ILogger<ContactService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<GetContactsDto> GetAllContactsAsync()
        {
            var contacts = await _dbContext
                                            .Contacts
                                            .AsNoTracking()
                                            .ToListAsync(); 


            var dto = new GetContactsDto
            {
                Contacts = contacts.Select(x => new ContactDto
                (
                    x.Forename,
                    x.Surname,
                    x.Email,
                    x.Telno
                ))
            };
            
            return dto;
        }

        public async Task<ContactDto?> GetContactByIdAsync(int id)
        {
            var contact = await _dbContext.Contacts.AsNoTracking()
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
            
            if (contact != null) return new ContactDto(contact.Forename, contact.Surname, contact.Email, contact.Telno);
            
            _logger.LogWarning($"No contact found with Id: {id}");

            return null;

        }

        public async Task DeleteContact(int id)
        {
            var contact = await _dbContext.Contacts.AsNoTracking().AnyAsync(x => x.Id == id);
            
            if (contact != null)
            {
                //contact.RemovedAt = new DateTimeOffset(DateTime.UtcNow);
            }

            _dbContext.Remove(id);
            await _dbContext.SaveChangesAsync();
        }
    }
}
