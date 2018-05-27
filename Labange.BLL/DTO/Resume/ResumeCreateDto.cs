using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.DTO.Resume
{
    public class ResumeCreateDto
    {
        public string About { get; set; }
        public int ExperienceYears { get; set; }
        public string Skills { get; set; }
        public string PlacesOfWork { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public int UnemployedId { get; set; }
    }
}
