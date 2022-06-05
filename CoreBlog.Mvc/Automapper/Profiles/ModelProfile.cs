using AutoMapper;
using CoreBlog.Entities.Dtos;
using CoreBlog.Mvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Automapper.Profiles
{
    public class ModelProfile:Profile
    {
        public ModelProfile()
        {
            CreateMap<BlogAddModel, BlogAddDto>();

            CreateMap<BlogUpdateDto, BlogUpdateModel>().ReverseMap();

        }

    }
}
