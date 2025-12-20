using System.Collections;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Persistence
{
    public interface ICountryRepository
    {
        Task<Domain.Entities.Country?> Get(int id);
        Task<IEnumerable<Domain.Entities.Country>> GetAllAsync();
        Task<Domain.Entities.Country?> GetByCodeAsync(string countryCode);

    }
}
