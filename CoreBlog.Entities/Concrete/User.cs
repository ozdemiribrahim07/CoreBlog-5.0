using CoreBlog.Shared.Entity.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Concrete
{
    public class User : IdentityUser<int>
    {
       
        public string Picture { get; set; }
        public ICollection<Blog>  Blogs { get; set; }

    }
}
