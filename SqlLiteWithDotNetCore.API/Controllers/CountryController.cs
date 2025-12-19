using Microsoft.AspNetCore.Mvc;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistance;
using SqlLiteWithDotNetCore.Application.Country.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SqlLiteWithDotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IGetCountryByCode _getCountryByCode;

        public CountryController(IGetCountryByCode getCountryByCode)
        {
            _getCountryByCode = getCountryByCode;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException();
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
