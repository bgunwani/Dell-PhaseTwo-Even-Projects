using coreMVCRepositoryDepdencyInjectionApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreMVCRepositoryDepdencyInjectionApplication
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
            services.AddControllersWithViews();

            // Application Service (By Default Singleton)
            // services.Add(new ServiceDescriptor(typeof(IEmployeeRepository), new EmployeeRepository()));

            // Application Service (Singleton, Transient, Scoped)
            //services.Add(new ServiceDescriptor(typeof(IEmployeeRepository), typeof(EmployeeRepository), ServiceLifetime.Singleton));
            //services.Add(new ServiceDescriptor(typeof(IEmployeeRepository), typeof(EmployeeRepository), ServiceLifetime.Transient));
            //services.Add(new ServiceDescriptor(typeof(IEmployeeRepository), typeof(EmployeeRepository), ServiceLifetime.Scoped));

            // Application Service using Lambda Methods
            //services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            //services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Application Service using Lambda Methods
            services.AddSingleton(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            //services.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            //services.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
