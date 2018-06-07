using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Resume
{
    public class ResumeCreateModel
    {
        [Required]
        public string About { get; set; }
        [Required]
        [Range(0, 60)]
        [Display(Name = "Years of Experience")]
        public int ExperienceYears { get; set; }
        [Required]
        public string Skills { get; set; }
        [Display(Name = "Previous places of work")]
        public string PlacesOfWork { get; set; }
        [Required]
        [Display(Name = "Category")]
        public SkillCategory SkillCategory { get; set; }
        public int UnemployedId { get; set; }
    }
}
