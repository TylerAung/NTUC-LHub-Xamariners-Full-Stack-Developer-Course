using CustomerApp.DbContextCust;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //add in appsettings.json the connstring, environment, version tab
            Configuration = configuration;//Industry standard to config connection string
           
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //new customerController
            //services.AddScoped<CustomerDbContext>();

            //This line of code gives permission for remote access, SOLVE Cross Origin Resources Sharing(CORS)
            //require importing too
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //To preserve camelcase or pascal case sending data over
            services.AddControllers()
           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            //Responsible for connstring Pt 2
            services.AddDbContext<CustomerDbContext>(options =>
            options.UseSqlServer(Configuration["ConnString"]));

            //HTTP session
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1); 
            });
            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //HTTP SESSION
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            

            app.UseRouting();
            app.UseCors("MyPolicy"); //For CORS, Must be in between app.UseRouting() & app.UseAuthorization()
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
