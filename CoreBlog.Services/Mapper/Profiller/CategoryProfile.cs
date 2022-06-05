using AutoMapper;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Services.Mapper.Profiller
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>().ForMember(hedef => hedef.DateCreated, opt => opt.MapFrom(x => DateTime.Now)); 

            CreateMap<CategoryUpdateDto, Category>().ForMember(hedef => hedef.DateCreated, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Category, CategoryUpdateDto>();

        }

    }
}
