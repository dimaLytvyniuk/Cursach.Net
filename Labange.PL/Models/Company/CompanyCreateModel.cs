using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Company
{
    public class CompanyCreateModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Quantity { get; set; }
        public string About { get; set; }
        public BusinessArea BusinessArea { get; set; }
    }
}
