using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Company
{
    public class CompanyListItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Quantity { get; set; }
        public BusinessArea BusinessArea { get; set; }
    }
}
