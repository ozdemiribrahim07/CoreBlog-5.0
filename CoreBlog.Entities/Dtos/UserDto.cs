using CoreBlog.Entities.Concrete;
using CoreBlog.Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class UserDto : DtoBaseGet
    {
        public User User { get; set; }

    }
}
