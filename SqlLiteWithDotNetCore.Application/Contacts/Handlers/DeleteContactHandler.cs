using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact;
using SqlLiteWithDotNetCore.Application.Abstractions.Persistence;
using SqlLiteWithDotNetCore.Application.Contacts.Commands;

namespace SqlLiteWithDotNetCore.Application.Contacts.Handlers
{
    public class DeleteContactHandler: IDeleteContact
    {
        private readonly IContactRepository _repo;

        public DeleteContactHandler(IContactRepository repo)
        {
            _repo = repo;
        }

        public async Task HandleAsync(DeleteContactCommand cmd)
        {
            try
            {
                await _repo.DeleteContact(cmd.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting contact with ID {cmd.Id}: {ex.Message}", ex);
            }
        }
    }
}
