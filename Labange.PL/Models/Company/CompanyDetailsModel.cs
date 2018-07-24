using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Company
{
    public class CompanyDetailsModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }
        [Required]
        [Range(0, 500000)]
        public int Quantity { get; set; }
        public string About { get; set; }
        [Required]
        [Display(Name = "Area of business")]
        public BusinessArea BusinessArea { get; set; }
    }
}
