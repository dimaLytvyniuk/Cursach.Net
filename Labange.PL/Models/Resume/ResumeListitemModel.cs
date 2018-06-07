using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Resume
{
    public class ResumeListItemModel
    {
        public int Id { get; set; }
        [Display(Name = "Years of Experience")]
        public int ExperienceYears { get; set; }
        [Display(Name = "Category")]
        public SkillCategory SkillCategory { get; set; }
        public string Name { get; set; }
        public int UnemployedId { get; set; }
    }
}
