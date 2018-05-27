using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.DTO.Unemployed
{
    public class UnemployedDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; }
    }
}
