﻿using AutoMapper;
using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Automapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();

            CreateMap<User, UserUpdateDto>();

            CreateMap<UserUpdateDto, User>();
        }

    }
}
