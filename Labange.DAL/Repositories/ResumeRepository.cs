using Labange.DAL.EF;
using Labange.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Labange.DAL.Repositories
{
    public class ResumeRepository : BaseEFRepository<Resume> 
    {
        public ResumeRepository(LabangeContext dbContext) : base(dbContext)
        {

        }

        public override Resume Find(Func<Resume, bool> predicate)
        {
            return dbSet
                .Include(c => c.Unemployed)
                .FirstOrDefault(predicate);
        }

        public override IEnumerable<Resume> FindAll(Func<Resume, bool> predicate)
        {
            return dbSet
                .Include(c => c.Unemployed)
                .Where(predicate)
                .ToList();
        }

        public override async Task<Resume> FindAsync(Expression<Func<Resume, bool>> predicate)
        {
            return await dbSet
                .Include(c => c.Unemployed)
                .FirstOrDefaultAsync(predicate);
        }

        public override IEnumerable<Resume> GetAll()
        {
            return dbSet
                .Include(c => c.Unemployed)
                .ToList();
        }

        public override async Task<IEnumerable<Resume>> GetAllAsync()
        {
            return await dbSet
                .Include(c => c.Unemployed)
                .ToListAsync();
        }
    }
}
