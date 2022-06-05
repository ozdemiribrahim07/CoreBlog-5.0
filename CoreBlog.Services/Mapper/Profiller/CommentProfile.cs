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
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {

            CreateMap<CommentAddDto, Comment>()
                 .ForMember(d => d.DateCreated, opt => opt.MapFrom(x => DateTime.Now))
                 .ForMember(d => d.EditDate, opt => opt.MapFrom(x => DateTime.Now))
                 .ForMember(d => d.EditedName, opt => opt.MapFrom(x => x.CreatedName))
                 .ForMember(d => d.IsActive, opt => opt.MapFrom(x => false));

            CreateMap<CommentUpdateDto, Comment>()
                .ForMember(d => d.EditDate, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<Comment, CommentUpdateDto>();

        }

    }
}
