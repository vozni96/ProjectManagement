using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Data;
using ProjectManagement.Infrastructure;
using ProjectManagement.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options => {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.AddScoped<BoardService>();
            services.AddScoped<CardService>();

            services.AddIdentity<AppUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ProjectManagementDbContext>();

            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/User/Login";
            });

            services.AddDbContext<ProjectManagementDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "ProjectManagement")); //_config.GetConnectionString("DefaultConnection")
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
