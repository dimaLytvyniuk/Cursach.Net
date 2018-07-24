using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.DAL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Quantity { get; set; }
        public string About { get; set; }
        public BusinessArea BusinessArea { get; set; }

        public ICollection<Vacation> Vacations { get; set; }
    }
}
