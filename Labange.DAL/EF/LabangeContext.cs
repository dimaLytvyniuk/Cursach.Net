using Labange.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.DAL.EF
{
    public class LabangeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Unemployed> Unemployeds { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Resume> Resumes { get; set; }

        public LabangeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
