using CoreBlog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataLayer.Concrete.EF.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.CategoryName).IsRequired();
            builder.Property(c => c.CategoryName).HasMaxLength(60);
            builder.Property(c => c.CategoryDesc).IsRequired();
            builder.Property(c => c.CategoryDesc).HasMaxLength(400);
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.CreatedName).HasMaxLength(60);
            builder.Property(c => c.EditedName).HasMaxLength(60);
            builder.Property(c => c.DateCreated).IsRequired();
            builder.Property(c => c.EditDate).IsRequired();
            builder.Property(c => c.EditedName).IsRequired();

            builder.ToTable("Categories");

            builder.HasData(new Category
            {
                Id = 1,
                CategoryName = ".NET 5.0",
                CategoryDesc = ".NET 5.0 ile İlgili En Son Haberler",
                IsActive = true,
                IsDeleted = false,
                CreatedName = "InitFirst",
                DateCreated = DateTime.Now,
                EditDate = DateTime.Now,
                EditedName = "InitFirst"

            },
                new Category
                {
                    Id = 2,
                    CategoryName = "Python",
                    CategoryDesc = "Python ile İlgili En Son Haberler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedName = "InitFirst",
                    DateCreated = DateTime.Now,
                    EditDate = DateTime.Now,
                    EditedName = "InitFirst"
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Java",
                    CategoryDesc = "Java ile İlgili En Son Haberler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedName = "InitFirst",
                    DateCreated = DateTime.Now,
                    EditDate = DateTime.Now,
                    EditedName = "InitFirst"

                }


            );

        }
    }
}
