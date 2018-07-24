using Labange.DAL.EF;
using Labange.DAL.Entities;
using Labange.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Labange.DAL.Repositories
{
    public class UnemployedRepository : BaseEFRepository<Unemployed>
    {
        public UnemployedRepository(LabangeContext dbContext) : base(dbContext)
        {
        }

        public override Unemployed Find(Func<Unemployed, bool> predicate)
        {
            return dbSet
                .Include(c => c.Resume)
                .FirstOrDefault(predicate);
        }

        public override IEnumerable<Unemployed> FindAll(Func<Unemployed, bool> predicate)
        {
            return dbSet
                .Include(c => c.Resume)
                .Where(predicate)
                .ToList();
        }

        public override async Task<Unemployed> FindAsync(Expression<Func<Unemployed, bool>> predicate)
        {
            return await dbSet
                .Include(c => c.Resume)
                .FirstOrDefaultAsync(predicate);
        }

        public override IEnumerable<Unemployed> GetAll()
        {
            return dbSet
                .Include(c => c.Resume)
                .ToList();
        }

        public override async Task<IEnumerable<Unemployed>> GetAllAsync()
        {
            return await dbSet
                .Include(c => c.Resume)
                .ToListAsync();
        }
    }
}
