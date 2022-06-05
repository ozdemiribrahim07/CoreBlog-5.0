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
    public class BlogMapping : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(a => a.Id); //primary key
            builder.Property(a => a.Id).ValueGeneratedOnAdd(); // id alanı bir bir artıyor.


            builder.Property(a => a.BlogTitle).HasMaxLength(120);
            builder.Property(a => a.BlogTitle).IsRequired(); // zorunlu.
            builder.Property(a => a.BlogContent).IsRequired();
            builder.Property(a => a.BlogContent).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.BlogImage).IsRequired();
            builder.Property(a => a.BlogImage).HasMaxLength(200);
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.CreatedName).HasMaxLength(60);
            builder.Property(a => a.EditedName).HasMaxLength(60);
            builder.Property(a => a.DateCreated).IsRequired();
            builder.Property(a => a.EditDate).IsRequired();
            builder.Property(a => a.EditedName).IsRequired();
            builder.Property(a => a.ViewCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();



            builder.HasOne<Category>(b =>b.Category).WithMany(c => c.Blogs).HasForeignKey(b => b.CategoryId); // Bire Çok İlişki
            builder.HasOne<User>(b => b.User).WithMany(u => u.Blogs).HasForeignKey(b => b.UserId);

            builder.ToTable("Blogs");


            builder.HasData(new Blog
            {
                Id = 1,
                CategoryId = 1,
                UserId = 1,
                BlogTitle = ".NET 5.0 Çıktı!",
                BlogContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 50,
                CommentCount = 1,
                BlogImage = "first.jpg",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedName = "InitFirst",
                DateCreated = DateTime.Now,
                EditDate = DateTime.Now,
                EditedName = "InitFirst"

            },

            new Blog
            {
                Id = 2,
                CategoryId = 2,
                UserId = 1,
                BlogTitle = "Python",
                BlogContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 75,
                CommentCount = 1,
                BlogImage = "first.jpg",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedName = "InitFirst",
                DateCreated = DateTime.Now,
                EditDate = DateTime.Now,
                EditedName = "InitFirst"

            },
            new Blog
            {
                Id = 3,
                CategoryId = 3,
                UserId = 1,
                BlogTitle = "Java",
                BlogContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                ViewCount = 100,
                CommentCount = 1,
                BlogImage = "first.jpg",
                Date = DateTime.Now,
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
