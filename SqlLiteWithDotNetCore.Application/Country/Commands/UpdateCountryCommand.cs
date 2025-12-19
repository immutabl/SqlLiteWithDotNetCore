using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Country.Commands
{
    public sealed record UpdateCountryCommand
    {
        [Required] public int Id { get; init; }
        [Required, StringLength(50)] public required string Name { get; init; }
        [Required, StringLength(50)] public required string CountryCode{ get; init; }
        [Required, StringLength(3)] public required string DialingCode { get; init; }
        [Required, StringLength(50)] public required string Capital { get; init; }
    }
}
