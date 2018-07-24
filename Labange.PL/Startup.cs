﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labange.DAL.EF;
using Labange.PL.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Labange.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCookieAuthorization();
            services.AddBLLServices();
            services.AddEFUnitOfWork(Configuration.GetConnectionString("DockerComposeConnection"));
            services.AddMvc();

            services.AddDbContext<LabangeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DockerComposeConnection"), b => b.MigrationsAssembly("Labange.PL")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
