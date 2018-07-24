using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.DTO.Vacation
{
    public class VacationCreateDto
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Responsibilities { get; set; }
        public SkillCategory SkillCategory { get; set; }
        public int CompanyId { get; set; }
    }
}
