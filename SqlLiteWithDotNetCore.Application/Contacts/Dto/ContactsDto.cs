using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Domain.Entities;

namespace SqlLiteWithDotNetCore.Application.Contacts.Dto
{
    public sealed class ContactsDto
    
    {
        public IEnumerable<ContactDto> Contacts { get; init; }

        public bool HasRecords => Contacts.Any();

        public ContactsDto()
        {
            Contacts = new List<ContactDto>();
        }
    }
}
