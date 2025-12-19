using System.Collections;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Persistance
{
    public interface ICountryRepository
    {
        Task<Domain.Entities.Country?> Get(int id);
        Task<IEnumerable<Domain.Entities.Country>> GetAll();
        Task<Domain.Entities.Country?> GetByCodeAsync(string countryCode);

    }
}
