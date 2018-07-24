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
    public class UserRepository : BaseEFRepository<User>
    {
        public UserRepository(LabangeContext dbContext) : base(dbContext)
        {
        }
    }
}
