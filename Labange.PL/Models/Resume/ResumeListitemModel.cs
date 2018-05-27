using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Models.Resume
{
    public class ResumeListItemModel
    {
        public int Id { get; set; }
        public int ExperienceYears { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public string Name { get; set; }
        public int UnemployedId { get; set; }
    }
}
