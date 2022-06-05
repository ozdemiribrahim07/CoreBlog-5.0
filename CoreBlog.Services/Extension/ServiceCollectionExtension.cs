using CoreBlog.DataLayer.Abstract;
using CoreBlog.DataLayer.Concrete;
using CoreBlog.DataLayer.Concrete.EF.Contexts;
using CoreBlog.Entities.Concrete;
using CoreBlog.Services.Abstract;
using CoreBlog.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadServices(this IServiceCollection serviceCollection , string connectionString)
        {

            serviceCollection.AddDbContext<CoreBlogContext>(opt => opt.UseSqlServer(connectionString)); 

            serviceCollection.AddIdentity<User, Role>(opt =>  //identity mail ve password özellikleri
            {
                opt.Password.RequiredUniqueChars = 0;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 5;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false; // ünlem,soru işareti

                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";



            }).AddEntityFrameworkStores<CoreBlogContext>();

            serviceCollection.AddSingleton<IEMailService, MailManager>(); //AddSingleton tek nesne oluşturur

            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();  //AddScoped bağımlılık yaratır. yeni nesne oluşturabilir.

            serviceCollection.AddScoped<ICategoryService, CategoryManager>(); // CategoryService istenirse Category Manager getir.

            serviceCollection.AddScoped<IBlogService, BlogManager>();

            serviceCollection.AddScoped<ICommentService, CommentManager>();

            return serviceCollection;

        }

    }
}
