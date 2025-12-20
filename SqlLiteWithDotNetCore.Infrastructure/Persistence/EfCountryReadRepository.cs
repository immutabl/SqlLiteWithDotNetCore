using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Infrastructure.Persistence
{
    public class EfCountryReadRepository: ICountryRepository
    {
        private readonly ILogger<EfCountryReadRepository> _logger; //unnecessary in a repo?
        private readonly SqlLiteWithDotNetCoreDbContext _db;

        public EfCountryReadRepository(ILogger<EfCountryReadRepository> logger, SqlLiteWithDotNetCoreDbContext db)
        {
            _logger = logger; //unnecessary in a repo?
            _db = db;
        }

        public async Task<Country?> Get(int id)
        {
            var country = await _db.Countries.FindAsync(id);

            if (country is null)
            {
                _logger.LogWarning("Country with Id:{Id} was not found.", id);
                
            }

            return country;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _db.Countries
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<Country?> GetByCodeAsync(string countryCode)
        {
            var c = await _db.Countries.AsNoTracking()
                .Where(x =>
                x.CountryCode.ToLower().Equals(countryCode.ToLower())).FirstOrDefaultAsync();

            if (c != null)
            {
                return c;
            }

            return null;
        }
    }
}
