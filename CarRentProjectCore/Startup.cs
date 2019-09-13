using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CarRentProject.DBContext;
using CarRentProjectCore.Manager.Contract;
using CarRentProjectCore.Manager;
using CarRentProjectCore.Repository.Contract;
using CarRentProjectCore.Repository;
using AutoMapper;
using CarRentProjectCore.Utility.Customer;
using CarRentProjectCore.Utility;

namespace CarRentProjectCore
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IRentRequestManager, RentRequestManager>();
            services.AddTransient<IRentRequestRepository, RentRequestRepository>();
            services.AddTransient<IVehicleTypeManager, VehicleTypeManager>();
            services.AddTransient<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddTransient<IUtilityManager, DropDownUtility>();
            services.AddTransient<INotificationRepository,NotificationRepository>();
            services.AddTransient<IRentAssignRepository, RentAssignRepository>();
            services.AddTransient<INotificationManager, NotificationManager>();
            services.AddTransient<IRentAssignManager, RentAssignManager>();
            services.AddTransient<DbContext, CarRentDBContext>();
           
            services.AddDbContext<CarRentDBContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CarRentProjectCoreDB;Integrated Security=true;");
            });

            services.AddAutoMapper();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
