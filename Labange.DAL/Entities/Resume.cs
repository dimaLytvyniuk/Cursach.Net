using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.DAL.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public string About { get; set; }
        public int ExperienceYears { get; set; }
        public string Skills { get; set; }
        public string PlacesOfWork { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public int UnemployedId { get; set; }
        public Unemployed Unemployed { get; set; }
    }
}
