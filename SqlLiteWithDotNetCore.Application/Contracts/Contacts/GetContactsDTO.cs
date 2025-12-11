using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Application.Contracts.Contacts
{
    public class GetContactsDto
    
    {
        public IEnumerable<ContactDto> Contacts { get; set; }

        public bool HasRecords => Contacts.Any();

        public GetContactsDto()
        {
            Contacts = new List<ContactDto>();
        }
    }
}
