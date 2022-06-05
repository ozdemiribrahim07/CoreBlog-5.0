using CoreBlog.Entities.Concrete;
using CoreBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.Mvc.Areas.Admin.Models
{
    public class DashboardModel
    {
        public int BlogCount { get; set; }
        public int CategorieCount { get; set; }
        public int CommentCount { get; set; }
        public int UserCount { get; set; }
        public BlogListDto Blogs { get; set; }


    }
}
