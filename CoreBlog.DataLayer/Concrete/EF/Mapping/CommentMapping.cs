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
    public class CommentMapping : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.CommentText).IsRequired();
            builder.Property(c => c.CommentText).HasMaxLength(1500);
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.CreatedName).HasMaxLength(60);
            builder.Property(c => c.EditedName).HasMaxLength(60);
            builder.Property(c => c.DateCreated).IsRequired();
            builder.Property(c => c.EditDate).IsRequired();
            builder.Property(c => c.EditedName).IsRequired();

            builder.HasOne<Blog>(c => c.Blog).WithMany(b => b.Comments).HasForeignKey(c => c.BlogId);

            builder.ToTable("Comments");


            //builder.HasData(new Comment
            //{
            //    Id = 1,
            //    BlogId=1,
            //    CommentText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedName = "InitFirst",
            //    DateCreated = DateTime.Now,
            //    EditDate = DateTime.Now,
            //    EditedName = "InitFirst"



            //},
            //new Comment
            //{
            //    Id = 2,
            //    BlogId = 2,
            //    CommentText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedName = "InitFirst",
            //    DateCreated = DateTime.Now,
            //    EditDate = DateTime.Now,
            //    EditedName = "InitFirst"
            //},
            // new Comment
            // {
            //     Id = 3,
            //     BlogId = 3,
            //     CommentText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
            //     IsActive = true,
            //     IsDeleted = false,
            //     CreatedName = "InitFirst",
            //     DateCreated = DateTime.Now,
            //     EditDate = DateTime.Now,
            //     EditedName = "InitFirst"
            // }
            //);

        }
    }
}
