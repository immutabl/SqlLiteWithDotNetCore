using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Country.Commands
{
    /// Request shape; class for model binding + validation
    public sealed record CreateCountryCommand
    {
        [Required, StringLength(50, MinimumLength = 1)] 
        public required string Name { get; init; }
        
        [Required, StringLength(50, MinimumLength = 1)]
        public required string Capital { get; init; }
        
        [Required, StringLength(50, MinimumLength = 1)] 
        public required string DialingCode { get; init; }
        
    }
}
