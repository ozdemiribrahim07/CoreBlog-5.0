using CoreBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Models
{
    public class TopNewsViewModel
    {
        public IList<Blog> Blogs { get; set; }  // en çok okunna blogları getirmesi için 

    }
}
