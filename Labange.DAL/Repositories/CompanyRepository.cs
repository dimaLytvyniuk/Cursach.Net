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
    public class CompanyRepository : BaseEFRepository<Company>
    {
        public CompanyRepository(LabangeContext dbContext) : base(dbContext)
        {

        }

        public override Company Find(Func<Company, bool> predicate)
        {
            return dbSet
                .Include(c => c.Vacations)
                .FirstOrDefault(predicate);
        }

        public override IEnumerable<Company> FindAll(Func<Company, bool> predicate)
        {
            return dbSet
                .Include(c => c.Vacations)
                .Where(predicate)
                .ToList();
        }

        public override async Task<Company> FindAsync(Expression<Func<Company, bool>> predicate)
        {
            return await dbSet
                .Include(c => c.Vacations)
                .FirstOrDefaultAsync(predicate);
        }

        public override IEnumerable<Company> GetAll()
        {
            return dbSet
                .Include(c => c.Vacations)
                .ToList();
        }

        public override async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await dbSet
                .Include(c => c.Vacations)
                .ToListAsync();
        }
    }
}
