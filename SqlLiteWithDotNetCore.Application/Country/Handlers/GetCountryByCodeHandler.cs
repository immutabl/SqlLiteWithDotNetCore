using Microsoft.Extensions.Logging;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistance;
using SqlLiteWithDotNetCore.Application.Country.Dto;
using SqlLiteWithDotNetCore.Application.Country.Queries;

namespace SqlLiteWithDotNetCore.Application.Country.Handlers
{
    public class GetCountryByCodeHandler : IGetCountryByCode
    {
        private readonly ILogger<GetCountryByCodeHandler> _logger;
        private readonly ICountryRepository _countryRepository;

        public GetCountryByCodeHandler(ILogger<GetCountryByCodeHandler> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }
        public async Task<CountryDto?> HandleAsync(GetCountryByCodeQuery query)
        {
            var c = await _countryRepository.GetByCodeAsync(query.CountryCode);

            if (c == null)
            {
                _logger.LogWarning($"Country with code: {query.CountryCode} was not found.");
                return null;
            }

            return new CountryDto(c.Id, c.CountryCode, c.Name, c.DialingCode, c.Capital);
        }
    }
}
