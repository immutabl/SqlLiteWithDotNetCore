using Microsoft.AspNetCore.Mvc;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contacts;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;
using SqlLiteWithDotNetCore.Application.Contacts.Dto;
using SqlLiteWithDotNetCore.Application.Contacts.Queries;
using SqlLiteWithDotNetCore.Application.Country;
using SqlLiteWithDotNetCore.Application.Country.Queries;
using SqlLiteWithDotNetCore.Domain.Entities;
using IDeleteCountry = SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contacts.IDeleteCountry;

namespace SqlLiteWithDotNetCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        //private readonly IContactRepository _contactRepository;
        //private readonly ICountryRepository _countryRepository;
        private readonly ICreateContact _create;
        private readonly IUpdateContact _update;
        private readonly IDeleteContact _delete;
        private readonly IGetAllContacts _getAll;
        private readonly IGetContactById _getById;
        private readonly ILogger<ContactController> _logger;
        private readonly IGetCountryByCode _getCountryByCode;
        public ContactController(ILogger<ContactController> logger, ICreateContact createContact, 
                                    IUpdateContact updateContact, IDeleteContact delete, 
                                    IGetAllContacts getAllContacts, IGetContactById getById,
                                    IGetCountryByCode getCountryByCode)
        {
            _logger = logger;
            _getAll = getAllContacts;
            _getById = getById;
            _create = createContact;
            _update = updateContact;
            _delete = delete;
            _getById = getById;
            _getCountryByCode = getCountryByCode;
        }


        // GET: api/<Contact>
        [HttpGet]
        public async Task<ActionResult<ContactsDto>> Get()
        {
            return Ok(await _getAll.HandleAsync(new GetAllContactsQuery()));
        }

        // GET api/<Contact>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id must be positive.");
            }

            var c = await _getById.HandleAsync(new GetContactByIdQuery(id));

            if (c is null)
            {
                return NotFound($"Contact with Id:{id} was not found.");
            }

            return c;   //return the object directly as ActionResult<ContactDto> will handle wrapping it in Ok()
        }
    

        // POST api/<Contact>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateContactCommand cmd)
        {
            Console.WriteLine($"/Contact/[Post-endpoint] received an object: {cmd}");

            var country = await _getCountryByCode.HandleAsync(new GetCountryByCodeQuery(cmd.CountryCode));

            if (country is null)
            {
                return BadRequest($"Country code {cmd.CountryCode} not recognised.");
            }
                
            var contact = await _create.HandleAsync(cmd);

            Console.WriteLine($"Created Contact: {cmd.Forename} {contact.Surname} with Id: {contact.Id}");
            
            return CreatedAtAction(nameof(Get), new { id = contact.Id }, contact);
        }

        // PUT api/<Contact>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateContactCommand cmd)
        {
            await _update.HandleAsync(cmd);

            return Ok();
        }

        // DELETE api/<Contact>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
