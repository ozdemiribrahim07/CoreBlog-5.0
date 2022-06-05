using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Abstract
{
    public interface IBlogService
    {
        
        Task<ISonuc> Add(BlogAddDto blogAddDto, string createdName, int userid); // Dto sadece gerekli olan bilgileri kullanıcıya gösterir.
        Task<ISonuc> Update(BlogUpdateDto blogUpdateDto, string editedName);
        Task<ISonuc> Delete(int blogId, string editedName);
        Task<ISonuc> HardDelete(int blogId);
        Task<IDataSonuc<BlogDto>> Get(int blogId);
        Task<IDataSonuc<BlogUpdateDto>> GetBlogUpdate(int blogId);
        Task<IDataSonuc<BlogListDto>> GetAll();
        Task<IDataSonuc<BlogListDto>> GetAllPageAsync(int current = 1, int pagesize = 6); 
        Task<IDataSonuc<BlogListDto>> GetAllViewCount(bool desc , int? size);
        Task<IDataSonuc<BlogListDto>> GetAllNotDeleted();
        Task<IDataSonuc<BlogListDto>> GetAllLast3();
        Task<IDataSonuc<BlogListDto>> GetAllNotDeletedAndActive();
        Task<IDataSonuc<BlogListDto>> GetAllByCategory(int categoryId);
        Task<IDataSonuc<int>> Count();
        Task<IDataSonuc<int>> CountIsdeleted();
        

    }
}
