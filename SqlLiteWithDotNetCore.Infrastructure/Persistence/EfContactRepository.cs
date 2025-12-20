using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Infrastructure.Persistence
{
    public class EfContactRepository : IContactRepository
    {
        private readonly SqlLiteWithDotNetCoreDbContext _dbContext;
        private readonly ILogger<EfContactRepository> _logger;

        public EfContactRepository(SqlLiteWithDotNetCoreDbContext dbContext, ILogger<EfContactRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #region Create
        public async Task CreateContactAsync(Contact contact)
        {
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task UpdateContactAsync(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Delete

        public async Task DeleteContact(int id)
        {
            var contact = await _dbContext.Contacts.AsNoTracking().AnyAsync(x => x.Id == id);

            if (contact != null)
            {
                _dbContext.Remove(id);
                await _dbContext.SaveChangesAsync();
            }
        }

        #endregion

        #region Gets
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _dbContext
                .Contacts
                .Include(x=> x.Country)
                .AsNoTracking()
                .ToListAsync();
        }
        #endregion

        #region GetById
        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            var contact = await _dbContext.Contacts
                                        .AsNoTracking()
                                        .Include(x => x.Country)
                                        .FirstOrDefaultAsync(x => x.Id == id);
                                        
            if (contact is null)
            {
                _logger.LogWarning($"No contact found with Id: {id}");
            }

            return contact;
        }
        #endregion
    }
}
