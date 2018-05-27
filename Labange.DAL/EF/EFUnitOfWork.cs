using Labange.DAL.Entities;
using Labange.DAL.Interfaces;
using Labange.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Labange.DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly LabangeContext dbContext;

        private CompanyRepository companyRepository;
        private UserRepository userRepository;
        private UnemployedRepository unemployedRepository;
        private VacationRepository vacationRepository;
        private ResumeRepository resumeRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            dbContext = new LabangeContext(options);
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(dbContext);
                }
                return userRepository;
            }
        }

        public IRepository<Company> CompanyRepository
        {
            get
            {
                if (companyRepository == null)
                {
                    companyRepository = new CompanyRepository(dbContext);
                }
                return companyRepository;
            }
        }

        public IRepository<Unemployed> UnemployedRepository
        {
            get
            {
                if (unemployedRepository == null)
                {
                    unemployedRepository = new UnemployedRepository(dbContext);
                }
                return unemployedRepository;
            }
        }

        public IRepository<Vacation> VacationRepository
        {
            get
            {
                if (vacationRepository == null)
                {
                    vacationRepository = new VacationRepository(dbContext);
                }
                return vacationRepository;
            }
        }

        public IRepository<Resume> ResumeRepository
        {
            get
            {
                if (resumeRepository == null)
                {
                    resumeRepository = new ResumeRepository(dbContext);
                }
                return resumeRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
