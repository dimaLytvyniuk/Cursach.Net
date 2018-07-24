using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Company> CompanyRepository { get; }
        IRepository<Unemployed> UnemployedRepository { get; }
        IRepository<Vacation> VacationRepository { get; }
        IRepository<Resume> ResumeRepository { get; }

        void Save();
        Task SaveAsync();
    }
}
