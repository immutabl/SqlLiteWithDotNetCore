using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class DeleteContactHandler: IDeleteContact
    {
        public Task HandleAsync(DeleteContactCommand cmd)
        {
            throw new NotImplementedException();
        }
    }
}
