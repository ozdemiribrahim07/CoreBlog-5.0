using AutoMapper;
using CoreBlog.DataLayer.Abstract;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Services.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Concrete
{
    public class BlogManager : ManagerBase , IBlogService
    {
        public BlogManager(  IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper )
        {
            
        }

        public async Task<ISonuc> Add(BlogAddDto blogAddDto, string createdName ,int userid)
        {
            var blog = Mapper.Map<Blog>(blogAddDto);  // mapping yaparak blog içerisine blogadddto bilgilerini aktarabiliyoruz.

            blog.UserId = userid;
            blog.CreatedName = createdName;
            blog.EditedName = createdName;

            await UnitOfWork.Blogs.AddAsync(blog);
            await UnitOfWork.SaveAsync();

            return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, $"{blogAddDto.BlogTitle} başarıyla ekleniştir.");

        }


        public async Task<ISonuc> Delete(int blogId, string editedName)
        {
            var result = await UnitOfWork.Blogs.AnyAsync(b => b.Id == blogId);

            if (result)
            {
                var blog = await UnitOfWork.Blogs.GetAsync(b => b.Id == blogId);
                blog.EditedName = editedName;
                blog.EditDate = DateTime.Now;
                blog.IsDeleted = true;

                await UnitOfWork.Blogs.DeleteAsync(blog);
                await UnitOfWork.SaveAsync();
                return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, $"{blog.BlogTitle} başarıyla silinmiştir.");

            }

            return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Blog Yok");
        }


        public async Task<ISonuc> HardDelete(int blogId)
        {

            var result = await UnitOfWork.Blogs.AnyAsync(b => b.Id == blogId);

            if (result)
            {
                var blog = await UnitOfWork.Blogs.GetAsync(b => b.Id == blogId);

                await UnitOfWork.Blogs.DeleteAsync(blog);
                await UnitOfWork.SaveAsync();

                return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, $"{blog.BlogTitle} başarıyla veritabanından silinmiştir.");


            }

            return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Blog Yok");
        }

        public async Task<ISonuc> Update(BlogUpdateDto blogUpdateDto, string editedName )
        {
            var old = await UnitOfWork.Blogs.GetAsync(b => b.Id == blogUpdateDto.Id);
            var blog = Mapper.Map<BlogUpdateDto,Blog>(blogUpdateDto,old);

            blog.EditedName = editedName;

            await UnitOfWork.Blogs.UpdateAsync(blog);
            await UnitOfWork.SaveAsync();

            return new Sonuc(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, $"{blogUpdateDto.BlogTitle} başarıyla güncellenmiştir.");

        }





        public async Task<IDataSonuc<BlogDto>> Get(int blogId)
        {
            var blog = await UnitOfWork.Blogs.GetAsync(b => b.Id == blogId, b => b.User, b => b.Category);


            if (blog != null)
            {
                blog.Comments = await UnitOfWork.Comments.GetAllAsync(c => c.BlogId == blogId);

                return new DataSonuc<BlogDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new BlogDto
                {
                    Blog = blog,
                    SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success
                });
            }

            return new DataSonuc<BlogDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Blog Yok.", null);
        }

        public async Task<IDataSonuc<BlogListDto>> GetAll()
        {
            var blogs = await UnitOfWork.Blogs.GetAllAsync(null, b => b.User, b => b.Category);

            if (blogs.Count > -1)
            {
                return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new BlogListDto
                {
                    Blogs = blogs,
                    SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success
                });

            }

            return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Blog Bulunamadı.", null);
        }



        public async Task<IDataSonuc<BlogListDto>> GetAllByCategory(int categoryId)
        {
            var result = await UnitOfWork.Categories.AnyAsync(c => c.Id == categoryId);

            if (result)
            {
                var blogs = await UnitOfWork.Blogs.GetAllAsync(b => b.CategoryId == categoryId && b.IsDeleted == false && b.IsActive == true, b => b.User, b => b.Category);

                if (blogs.Count > -1)
                {
                    return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new BlogListDto
                    {
                        Blogs = blogs,
                        SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success
                    });

                }

                return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Blog Bulunamadı.", null);
            }

            return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Kategori Bulunamadı.", null);

        }


        public async Task<IDataSonuc<BlogListDto>> GetAllNotDeleted()
        {
            var blogs = await UnitOfWork.Blogs.GetAllAsync(b => b.IsDeleted == false, b => b.User, b => b.Category);

            if (blogs.Count > -1)
            {
                return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new BlogListDto
                {
                    Blogs = blogs,
                    SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success
                });

            }

            return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Blog Bulunamadı.", null);
        }



        public async Task<IDataSonuc<BlogListDto>> GetAllNotDeletedAndActive()
        {
            var blogs = await UnitOfWork.Blogs.GetAllAsync(b => b.IsDeleted == false && b.IsActive, b => b.User, b => b.Category);


            if (blogs.Count > -1)
            {
                return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, new BlogListDto
                {
                    Blogs = blogs,
                    SonucStatus = Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success
                });

            }

            return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, "Blog Bulunamadı.", null);
        }



        public async Task<IDataSonuc<int>> Count()
        {
            var blogs = await UnitOfWork.Blogs.CountAsync();
            if (blogs > -1) 
            {
                return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, blogs);
            }
            return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, message: "HATA", -1);
        }



        public async Task<IDataSonuc<int>> CountIsdeleted()
        {
            var blog = await UnitOfWork.Blogs.CountAsync(b=> b.IsDeleted == false);
            if (blog > -1)
            {
                return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, blog);
            }
            return new DataSonuc<int>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, message: "HATA", -1);
        }


        public async Task<IDataSonuc<BlogUpdateDto>> GetBlogUpdate(int blogId)
        {

            var result = await UnitOfWork.Blogs.AnyAsync(a => a.Id == blogId);
            if (result)
            {
                var blog = await UnitOfWork.Blogs.GetAsync(a => a.Id == blogId);
                var updatedto = Mapper.Map<BlogUpdateDto>(blog);

                return new DataSonuc<BlogUpdateDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success, updatedto);
            }
            return new DataSonuc<BlogUpdateDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Error, message: "Blog bulunamadı.", null);

        }


        public async Task<IDataSonuc<BlogListDto>> GetAllViewCount(bool desc, int? size)
        {

            var blog = await UnitOfWork.Blogs.GetAllAsync(b => b.IsActive == true, b => b.IsDeleted == false, b => b.Category);

            var blogsıra = desc ? blog.OrderByDescending(b => b.ViewCount) : blog.OrderBy(b => b.ViewCount);

            return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success,
                new BlogListDto
                { 
                    Blogs = size == null ? blogsıra.ToList() : blogsıra.Take(size.Value).ToList()
                });


        }

        public async Task<IDataSonuc<BlogListDto>> GetAllLast3()
        {

            var blog = await UnitOfWork.Blogs.GetAllAsync(); // son 5 blog getirir.

            return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success,

                new BlogListDto
                {
                    Blogs = blog.Take(5).ToList()
                }); 


        }

        public async Task<IDataSonuc<BlogListDto>> GetAllPageAsync(int current = 1, int pagesize = 6)  //Anasayfa için pagination 
        {
            var blog = await UnitOfWork.Blogs.GetAllAsync(b => b.IsActive == true);

            var blogsıra =  blog.OrderByDescending(b => b.Date).Skip((current - 1) * pagesize).Take(pagesize).ToList();
            // current-1 algoritaması ile ikinci sayfada diğer 6 blog gelmesini sağlar

                return new DataSonuc<BlogListDto>(Shared.Utilitie.Sonuc.ComplexType.SonucStatus.Success,
                    new BlogListDto
                    {
                        Blogs = blogsıra,
                        Current = current,
                        PageSize = pagesize,
                        TotalBlog = blog.Count
                        

                    });

        }
    }
}
