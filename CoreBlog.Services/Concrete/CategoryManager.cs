using AutoMapper;
using CoreBlog.DataLayer.Abstract;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using CoreBlog.Services.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.ComplexType;
using CoreBlog.Shared.Utilitie.Sonuc.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataSonuc<CategoryDto>> Add(CategoryAddDto categoryAddDto, string createdName)
        {

            var category = _mapper.Map<Category>(categoryAddDto);

            category.CreatedName = createdName;
            category.EditedName = createdName;

            var added = await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveAsync();

            return new DataSonuc<CategoryDto>(SonucStatus.Success, $"{categoryAddDto.CategoryName} başarılı şekilde eklenmiştir.", new CategoryDto
            {
                Category = added,
                SonucStatus = SonucStatus.Success,
                Message = $"{categoryAddDto.CategoryName} başarılı şekilde eklenmiştir."

            });

        }

        public async Task<IDataSonuc<CategoryDto>> Delete(int categoryId, string editedName)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                category.IsDeleted = true;
                category.EditDate = DateTime.Now;
                category.EditedName = editedName;

                var deleted = await _unitOfWork.Categories.UpdateAsync(category);
                await _unitOfWork.SaveAsync();

                return new DataSonuc<CategoryDto>(SonucStatus.Success, $"{deleted.CategoryName} başarılı şekilde silinmiştir.", new CategoryDto
                {

                    Category = deleted,
                    SonucStatus = SonucStatus.Success,
                    Message = $"{deleted.CategoryName} başarılı şekilde silinmiştir."
                });

            }

            return new DataSonuc<CategoryDto>(SonucStatus.Error, $"Kategori Yok.", new CategoryDto
            {

                Category = null,
                SonucStatus = SonucStatus.Error,
                Message = $"Kategori Yok."
            });

        }


        public async Task<ISonuc> HardDelete(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);

            if (category != null)
            {
                category.IsDeleted = true;
                
                await _unitOfWork.Categories.DeleteAsync(category);
                await _unitOfWork.SaveAsync();
                return new Sonuc(SonucStatus.Success, $"{category.CategoryName} başarılı şekilde veritabanından silinmiştir.");
            }

            return new Sonuc(SonucStatus.Error, "Kategori Yok.");

        }

        public async Task<IDataSonuc<CategoryDto>> Update(CategoryUpdateDto categoryUpdateDto, string editedName)
        {
            var old = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);

            var category = _mapper.Map<CategoryUpdateDto,Category>(categoryUpdateDto,old);
            category.EditedName = editedName;

            var updated = await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveAsync();
            return new DataSonuc<CategoryDto>(SonucStatus.Success, $"{categoryUpdateDto.CategoryName} başarılı şekilde güncellenmiştir.",
                
                new CategoryDto
            {

                Category = updated,
                SonucStatus = SonucStatus.Success,
                Message = $"{categoryUpdateDto.CategoryName} başarılı şekilde güncellenmiştir."

            });


        }


        public async Task<IDataSonuc<CategoryDto>> Get(int categoryId)
        {
            var category = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId, c => c.Blogs);

            if (category != null)
            {
                return new DataSonuc<CategoryDto>(SonucStatus.Success, new CategoryDto
                {

                    Category = category,
                    SonucStatus = SonucStatus.Success

                });
            }
            return new DataSonuc<CategoryDto>(SonucStatus.Error, "Bu kategori yok.", new CategoryDto
            {
                Category = null,
                SonucStatus = SonucStatus.Error,
                Message = "Bu kategori yok."

            });
        }

        public async Task<IDataSonuc<CategoryListDto>> GetAll()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(null, c => c.Blogs);

            if (categories.Count > -1) // Hiç kategori olmayabilir.
            {
                return new DataSonuc<CategoryListDto>(SonucStatus.Success, new CategoryListDto
                {

                    Categories = categories,
                    SonucStatus = SonucStatus.Success,


                });
            }

            return new DataSonuc<CategoryListDto>(SonucStatus.Error, "Hiç Kategori Yok.", new CategoryListDto
            {
                Categories = null,
                SonucStatus = SonucStatus.Error,
                Message = "Hiç Kategori Yok."
            });

        }

        public async Task<IDataSonuc<CategoryListDto>> GetAllNotDeleted()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false, c => c.Blogs);

            if (categories.Count > -1) // Hiç kategori olmayabilir.
            {
                return new DataSonuc<CategoryListDto>(SonucStatus.Success, new CategoryListDto
                {

                    Categories = categories,
                    SonucStatus = SonucStatus.Success,


                });
            }

            return new DataSonuc<CategoryListDto>(SonucStatus.Error, "Hiç Kategori Yok.", new CategoryListDto
            {
                Categories = null,
                SonucStatus = SonucStatus.Error,
                Message = "Hiç Kategori Yok."
            });

        }



        public async Task<IDataSonuc<CategoryListDto>> GetAllNotDeletedAndActive()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync(c => c.IsDeleted == false && c.IsActive, c => c.Blogs);

            if (categories.Count > -1)
            {
                return new DataSonuc<CategoryListDto>(SonucStatus.Success, new CategoryListDto
                {

                    Categories = categories,
                    SonucStatus = SonucStatus.Success
                });
            }

            return new DataSonuc<CategoryListDto>(SonucStatus.Error, "Hiç Kategori Yok.", null);
        }

        public async Task<IDataSonuc<CategoryUpdateDto>> GetUpdateDto(int categoryId)
        {
            var result = await _unitOfWork.Categories.AnyAsync(c => c.Id == categoryId);

            if (result)
            {
                var cat = await _unitOfWork.Categories.GetAsync(c => c.Id == categoryId);
                var updatedto = _mapper.Map<CategoryUpdateDto>(cat);

                return new DataSonuc<CategoryUpdateDto>(SonucStatus.Success, updatedto);
            }

            return new DataSonuc<CategoryUpdateDto>(SonucStatus.Error, message: "Kategori bulunamadı.", null);
        }

        public async Task<IDataSonuc<int>> Count()
        {
            var categories = await _unitOfWork.Categories.CountAsync();

            if (categories > -1)
            {
                return new DataSonuc<int>(SonucStatus.Success, categories);
            }

            return new DataSonuc<int>(SonucStatus.Error, message: "HATA", -1);
        }

        public async Task<IDataSonuc<int>> CountIsdeleted()
        {
            var categories = await _unitOfWork.Categories.CountAsync( c=>c.IsDeleted == false);

            if (categories > -1)
            {
                return new DataSonuc<int>(SonucStatus.Success, categories);
            }

            return new DataSonuc<int>(SonucStatus.Error, message: "HATA", -1);
        }
    }
}
