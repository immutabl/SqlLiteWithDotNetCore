using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteWithDotNetCore.Application.DTO
{
    public class CreateContactDTO
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Telno{ get; set; }


    }
}
