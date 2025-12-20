using Microsoft.AspNetCore.Mvc;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contacts;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Queries;
using SqlLiteWithDotNetCore.Application.Country.Dto;
using SqlLiteWithDotNetCore.Application.Country.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SqlLiteWithDotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IGetCountryByCode _getCountryByCode;
        private readonly IGetAllCountries _getAllCountries;

        public CountryController(IGetCountryByCode getCountryByCode,
                                    IGetAllCountries getAllCountries)
        {
            _getCountryByCode = getCountryByCode;
            _getAllCountries = getAllCountries;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
        {
            return Ok(await _getAllCountries.HandleAsync(new GetAllContactsQuery()));
        }

        // GET api/<CountryController>/5
        [HttpGet("{id:int}")]
        public string Get(int id)
        {
        //    var country = await getCountryByCode.HandleAsync()
            throw new NotImplementedException();
        }
        
        // GET api/<CountryController>/gb
        [HttpGet("by-code/{countryCode}")]
        
        public async Task<IActionResult> GetCountryByCode (string countryCode)
        {
            var country = await _getCountryByCode.HandleAsync(new GetCountryByCodeQuery(countryCode = countryCode));

            if (country is null)
            {
                return NotFound($"Country with code {countryCode} was not found.");
            }

            return Ok(country);
        }
        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
