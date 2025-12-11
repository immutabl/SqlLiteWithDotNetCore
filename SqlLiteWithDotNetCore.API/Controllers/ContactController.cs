using Microsoft.AspNetCore.Mvc;
using SqlLiteWithDotNetCore.Application.Contracts.Contacts;
using SqlLiteWithDotNetCore.Application.Services.Interfaces.IContactService;
using SqlLiteWithDotNetCore.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SqlLiteWithDotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger _logger;

        public ContactController(IContactService contactService, ILogger logger)
        {
            _contactService = contactService;
            _logger = logger;
        }


        // GET: api/<Contact>
        [HttpGet]
        public async Task<GetContactsDto> Get()
        {
            return await _contactService.GetAllContactsAsync();
        }

        // GET api/<Contact>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be positive.");
            }

            var c = await _contactService.GetContactByIdAsync(id);
            return c;
        }
    

        // POST api/<Contact>
        [HttpPost]
        public void Post([FromBody] CreateContactRequest dto)
        {
            Console.WriteLine($"/Contact/[Post-endpoint] received an object: {dto}");

            var contact = new Contact
            {
                Forename = dto.Forename,
                Surname = dto.Surname,
                Email = dto.Email,
                Telno = dto.Telno
            };

            _contactService.CreateContactAsync(contact);

            Console.WriteLine($"Created Contact: {contact.Forename} {contact.Surname} with Id: {contact.Id}");
        }

        // PUT api/<Contact>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Contact>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
