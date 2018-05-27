using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.DTO.Vacation
{
    public class VacationListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
