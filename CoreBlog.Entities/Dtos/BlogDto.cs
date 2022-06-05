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
    public class BlogDto : DtoBaseGet
    {
        public Blog Blog { get; set; }

    }
}
