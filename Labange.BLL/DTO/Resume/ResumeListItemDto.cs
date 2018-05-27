using Labange.DAL.Entities;

namespace Labange.BLL.DTO.Resume
{
    public class ResumeListItemDto
    {
        public int Id { get; set; }
        public int ExperienceYears { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public string Name { get; set; }
        public int UnemployedId { get; set; }
    }
}
