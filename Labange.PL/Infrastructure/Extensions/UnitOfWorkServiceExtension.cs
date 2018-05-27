using Labange.DAL.EF;
using Labange.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Infrastructure
{
    public static class UnitOfWorkServiceExtension
    {
        public static IServiceCollection AddEFUnitOfWork(this IServiceCollection services, string connection)
        {
            var builder = new DbContextOptionsBuilder<LabangeContext>()
                .UseSqlServer(connection);
            services.AddTransient<IUnitOfWork>(provider => new EFUnitOfWork(builder.Options));

            return services;
        }
    }
}
