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
    public class VacationRepository : BaseEFRepository<Vacation>
    {
        public VacationRepository(LabangeContext dbContext) : base(dbContext)
        {

        }

        public override Vacation Find(Func<Vacation, bool> predicate)
        {
            return dbSet
                .Include(c => c.Company)
                .FirstOrDefault(predicate);
        }

        public override IEnumerable<Vacation> FindAll(Func<Vacation, bool> predicate)
        {
            return dbSet
                .Include(c => c.Company)
                .Where(predicate)
                .ToList();
        }

        public override async Task<Vacation> FindAsync(Expression<Func<Vacation, bool>> predicate)
        {
            return await dbSet
                .Include(c => c.Company)
                .FirstOrDefaultAsync(predicate);
        }

        public override IEnumerable<Vacation> GetAll()
        {
            return dbSet
                .Include(c => c.Company)
                .ToList();
        }

        public override async Task<IEnumerable<Vacation>> GetAllAsync()
        {
            return await dbSet
                .Include(c => c.Company)
                .ToListAsync();
        }
    }
}
