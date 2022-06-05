using CoreBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Areas.Admin.Models
{
    public class UserRolesModel
    {
        public User User { get; set; }
        public IList<string> Roles { get; set; }

    }
}
