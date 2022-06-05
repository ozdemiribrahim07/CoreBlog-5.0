using CoreBlog.Entities.Concrete;
using CoreBlog.Shared.Entity.Abstract;
using CoreBlog.Shared.Utilitie.Sonuc.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Dtos
{
    public class BlogListDto : DtoBaseGet
    {
        public IList<Blog> Blogs { get; set; }

        public bool Next => Current < TotalPage;
        public bool Previous => Current > 1;


        public int Current { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public int TotalBlog { get; set; }
        public int TotalPage => (int)Math.Ceiling(decimal.Divide(TotalBlog, PageSize));



    }
}
