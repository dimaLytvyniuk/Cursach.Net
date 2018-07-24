using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.DTO.Unemployed
{
    public class UnemployedCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; }
    }
}
