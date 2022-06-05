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
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<BlogAddDto, Blog>().ForMember(hedef => hedef.DateCreated,opt => opt.MapFrom(x=> DateTime.Now));

            CreateMap<BlogUpdateDto, Blog>().ForMember(hedef => hedef.EditDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Blog, BlogUpdateDto>();

        }

    }
}
