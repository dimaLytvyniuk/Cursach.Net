using Labange.BLL.Interfaces;
using Labange.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Infrastructure
{
    public static class BLLServicesExtention
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUnemployedService, UnemployedService>();
            services.AddScoped<IVacationService, VacationService>();
            services.AddScoped<IResumeService, ResumeService>();

            return services;
        }
    }
}
