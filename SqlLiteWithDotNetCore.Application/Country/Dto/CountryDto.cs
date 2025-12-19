using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.Country.Dto
{
    public sealed record CountryDto
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string DialingCode { get; set; }
        public string Capital { get; set; }
        
           
    }

}
