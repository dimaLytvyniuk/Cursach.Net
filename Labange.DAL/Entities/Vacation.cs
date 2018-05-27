using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.DAL.Entities
{
    public class Vacation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Responsibilities { get; set; }
        public SkillCategory SkillCategory { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
