using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Vacation
{
    public class VacationListItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        [Display(Name = "Category")]
        public SkillCategory SkillCategory { get; set; }
        public int CompanyId { get; set; }
        [Display(Name = "Company")]
        public string CompanyName { get; set; }
    }
}
