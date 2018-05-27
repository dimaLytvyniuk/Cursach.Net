using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.DAL.Entities
{
    public class Unemployed
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public DateTime Birthday { get; set; }
    }
}
