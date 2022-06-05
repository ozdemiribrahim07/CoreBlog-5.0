using CoreBlog.Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Concrete
{
    public class Category:EntityBase,IEntity  // EntityBase'den türüyor.
    {
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public ICollection<Blog> Blogs { get; set; }


    }
}
