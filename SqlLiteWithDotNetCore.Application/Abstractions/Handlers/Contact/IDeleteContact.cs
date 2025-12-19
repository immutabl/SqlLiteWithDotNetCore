using SqlLiteWithDotNetCore.Application.Contacts.Commands;

namespace SqlLiteWithDotNetCore.Application.Abstractions.Handlers.Contact
{
    public interface IDeleteContact
    {
        Task HandleAsync(DeleteContactCommand cmd);
    }
}
