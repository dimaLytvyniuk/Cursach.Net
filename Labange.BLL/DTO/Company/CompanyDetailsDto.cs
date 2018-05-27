using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.DTO.Company
{
    public class CompanyDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Quantity { get; set; }
        public string About { get; set; }
        public BusinessArea BusinessArea { get; set; }
    }
}
