using Microsoft.AspNetCore.Mvc;
using SqlLiteWithDotNetCore.Application.DTO;
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

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        // GET: api/<Contact>
        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _contactService.GetAllContacts();
        }

        // GET api/<Contact>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"/Contact/{id}";
        }

        // POST api/<Contact>
        [HttpPost]
        public void Post([FromBody] CreateContactDTO dto)
        {
            Console.WriteLine($"/Contact/[Post-endpoint] received an object: {dto}");

            var contact = new Contact
            {
                Forename = dto.Forename,
                Surname = dto.Surname,
                Email = dto.Email,
                Telno = dto.Telno
            };

            _contactService.CreateContact(contact);

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
