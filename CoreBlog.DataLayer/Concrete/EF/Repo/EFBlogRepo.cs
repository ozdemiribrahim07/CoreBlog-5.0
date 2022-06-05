using CoreBlog.DataLayer.Abstract;
using CoreBlog.Entities.Concrete;
using CoreBlog.Shared.DataLayer.Concrete.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataLayer.Concrete
{
    public class EFBlogRepo: EFRepoBase<Blog>,IBlogRepo
    {
        public EFBlogRepo(DbContext context) : base(context) //EFRepoBase kısmında dbcontext vermiştik.
        {

        } 



    }
}
