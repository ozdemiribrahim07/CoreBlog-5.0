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
    public interface ICategoryService
    {
        Task<IDataSonuc<CategoryDto>> Add(CategoryAddDto categoryAddDto , string createdName); // Dto sadece gerekli olan bilgileri kullanıcıya gösterir.
        Task<IDataSonuc<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string editedName);
        Task<IDataSonuc<CategoryDto>> Delete(int categoryId , string editedName);
        Task<ISonuc> HardDelete(int categoryId);
        Task<IDataSonuc<CategoryDto>> Get(int categoryId);
        Task<IDataSonuc<CategoryUpdateDto>> GetUpdateDto(int categoryId);
        Task<IDataSonuc<CategoryListDto>> GetAll();
        Task<IDataSonuc<CategoryListDto>> GetAllNotDeleted();
        Task<IDataSonuc<CategoryListDto>> GetAllNotDeletedAndActive(); 
        Task<IDataSonuc<int>> Count();
        Task<IDataSonuc<int>> CountIsdeleted();




    }
}
