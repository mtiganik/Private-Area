using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.App.EF;
using DAL.App.EF.Helpers;
using DAL.App.Interfaces;
using DAL.Interfaces;
using DAL.Interfaces.Helpers;
using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Models;
using WebApp.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace WebApp
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // transient - object is created new on every request
            // singleton - object is alive for lifetime of application
            // scoped - object is alive for duration of web request
            services.AddScoped<IDataContext, ApplicationDbContext>();
            services.AddSingleton<IRepositoryFactoryProvider, EFRepositoryFactoryProvider>();
            services.AddScoped<IRepositoryProvider, EFRepositoryProvider>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-GB"),
                    new CultureInfo("et-EE"),
                };

                options.DefaultRequestCulture = new RequestCulture("et-EE");

                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            var localizationOptions =
                 app.ApplicationServices
                       .GetService<IOptions<RequestLocalizationOptions>>();

            app.UseRequestLocalization(localizationOptions.Value);


            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                             name: "areas",
                             template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                              name: "default",
                              template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
