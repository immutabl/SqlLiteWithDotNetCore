using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Contacts.Commands
{
    public sealed class UpdateContactCommand
    {
        [Required] 
        public int Id { get; init; }

        [Required, StringLength(50, MinimumLength = 1)]
        public required string Forename { get; init; }
        
        [Required, StringLength(50, MinimumLength = 1)]
        public required string Surname  { get; init; }
        
        [Required, EmailAddress, StringLength(100, MinimumLength = 6)] 
        public required string Email { get; init; }
        
        [Required, StringLength(50)] 
        public required string Telno    { get; init; }
    }
}
