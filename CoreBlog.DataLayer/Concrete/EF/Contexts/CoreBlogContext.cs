using CoreBlog.DataLayer.Concrete.EF.Mapping;
using CoreBlog.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataLayer.Concrete.EF.Contexts
{
    public class CoreBlogContext:IdentityDbContext<User,Role,int,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Role> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-UHT205T\SQLEXPRESS;Database=CoreBlog;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        //}

        public CoreBlogContext(DbContextOptions<CoreBlogContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Fluent Api mappings
        {
            modelBuilder.ApplyConfiguration(new BlogMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            modelBuilder.ApplyConfiguration(new CommentMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserClaimMapping());
            modelBuilder.ApplyConfiguration(new RoleClaimMapping());
            modelBuilder.ApplyConfiguration(new UserLoginMapping());
            modelBuilder.ApplyConfiguration(new UserRoleMapping());
            modelBuilder.ApplyConfiguration(new UserTokenMapping());
        }


    }
}
