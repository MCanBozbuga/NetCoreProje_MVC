using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Data;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Veritabaný
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProjectContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
       
           

            // Kimlik Yönetimi
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ProjectContext>();
            // MVC
            services.AddControllersWithViews();


            //#region //IdentityUser nesnesi içerisinde bulunan varsayýlan þifre tanýmlamalarýný deðiþtirdik.
            //services.Configure<IdentityOptions>(x =>
            //{
            //    x.Password.RequireDigit = false;
            //    x.Password.RequiredLength = 6;
            //    x.Password.RequireNonAlphanumeric = false;
            //    x.Password.RequireUppercase = false;
            //    x.Password.RequireLowercase = false;
            //});
            //#endregion


            services.ConfigureApplicationCookie(x =>
            {

                x.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Index");
                x.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Home/Privacy");
                x.Cookie = new Microsoft.AspNetCore.Http.CookieBuilder
                {
                    Name = "YZL3159_cookie"
                };
                x.SlidingExpiration = true;
                x.ExpireTimeSpan = TimeSpan.FromMinutes(100);
            });

            // Servisler  
            //todo: IoC Container ile düzeltilecek.
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            // Session
            services.AddSession(x =>
            {
                x.Cookie.Name = "project_cart";
                x.IdleTimeout = TimeSpan.FromMinutes(100);
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
