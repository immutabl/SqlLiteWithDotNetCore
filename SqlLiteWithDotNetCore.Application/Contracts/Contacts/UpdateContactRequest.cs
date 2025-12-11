using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Contracts.Contacts
{
    public sealed class UpdateContactRequest
    {
        [Required] public int Id { get; init; }
        [Required, StringLength(50)] public required string Forename { get; init; }
        [Required, StringLength(50)] public required string Surname  { get; init; }
        [Required, EmailAddress, StringLength(100)] public required string Email { get; init; }
        [Required, StringLength(50)] public required string Telno    { get; init; }
    }
}
