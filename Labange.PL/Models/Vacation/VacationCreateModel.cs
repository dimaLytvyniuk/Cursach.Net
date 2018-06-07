using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Vacation
{
    public class VacationCreateModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [Range(0, 500000)]
        public int Salary { get; set; }
        [Required]
        public string Responsibilities { get; set; }
        [Required]
        [Display(Name = "Category")]
        public SkillCategory SkillCategory { get; set; }
        public int CompanyId { get; set; }
    }
}
