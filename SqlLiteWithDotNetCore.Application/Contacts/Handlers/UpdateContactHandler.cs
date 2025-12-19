using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class UpdateContactHandler: IUpdateContact
    {
        public Task HandleAsync(UpdateContactCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
