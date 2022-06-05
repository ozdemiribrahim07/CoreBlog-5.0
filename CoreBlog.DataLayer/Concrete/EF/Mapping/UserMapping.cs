using CoreBlog.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataLayer.Concrete.EF.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            // Primary key
            b.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("UserNameIndex").IsUnique();
            b.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex");

            // Maps to the AspNetUsers table
            

            // A concurrency token for use with the optimistic concurrency checking
            b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            b.Property(u => u.UserName).HasMaxLength(50);
            b.Property(u => u.NormalizedUserName).HasMaxLength(50);
            b.Property(u => u.Email).HasMaxLength(70);
            b.Property(u => u.NormalizedEmail).HasMaxLength(70);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            b.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            b.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();


            var admin = new User
            {
                Id = 1,
                Email = "ozdemiribrahim07@gmail.com",
                NormalizedEmail = "OZDEMIRIBRAHIM07@GMAIL.COM",
                UserName = "ozdemir07",
                NormalizedUserName = "OZDEMIR07",
                PhoneNumber = "05070356010",
                Picture = "adminresim.png",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")

            };

            admin.PasswordHash = PasswordHash(admin , "ozdemir123");


            var editor = new User
            {
                Id = 2,
                Email = "editor@gmail.com",
                NormalizedEmail = "EDITOR@GMAIL.COM",
                UserName = "editor",
                NormalizedUserName = "EDITOR",
                PhoneNumber = "05555555555",
                Picture = "editorresim.png",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")

            };

            editor.PasswordHash = PasswordHash(editor, "editor123");

            b.HasData(admin, editor);

            b.ToTable("AspNetUsers");
        }

        private string PasswordHash(User user , string password)
        {
            var passwordhash = new PasswordHasher<User>();
            return passwordhash.HashPassword(user, password);
        }

       
    }
}
