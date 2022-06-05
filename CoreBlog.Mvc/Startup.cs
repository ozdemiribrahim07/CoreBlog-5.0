using CoreBlog.Entities.Concrete;
using CoreBlog.Mvc.Areas.Admin.Models;
using CoreBlog.Mvc.Automapper.Profiles;
using CoreBlog.Mvc.Help;
using CoreBlog.Services.Extension;
using CoreBlog.Services.Mapper.Profiller;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoreBlog.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Smtpp>(Configuration.GetSection("Smtp"));

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; 

            }); // MVC

            services.AddSession();

            services.AddAutoMapper(typeof(CategoryProfile), typeof(BlogProfile) , typeof(UserProfile), typeof(BlogAddModel), typeof(CommentProfile));

            services.LoadServices(connectionString:Configuration.GetConnectionString("Coreblogcs"));
            services.AddScoped<IImageHelper, ImageHelper>();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Admin/Auth/Login");
                opt.LogoutPath = new PathString("/Admin/Auth/Logout");

                opt.Cookie = new CookieBuilder
                {
                    Name = "CoreBlog",
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest, //gerçek uygulamarda always olur.
                    HttpOnly = true,

                };

                opt.ExpireTimeSpan = System.TimeSpan.FromDays(1);
                opt.SlidingExpiration = true; // kullanýcýya zaman tanýma.
                opt.AccessDeniedPath = new PathString("/Admin/Auth/Denied/");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseStatusCodePages(); // Bulunmayan sayfaya gidildiðinide 404 verir.
            }

            app.UseSession();

            app.UseStaticFiles(); //Resim css dosyalarý için gereklidir.

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name:"Admin",
                    areaName:"Admin",
                    pattern:"Admin/{controller=Home}/{action=Index}/{id?}"

                    );

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
