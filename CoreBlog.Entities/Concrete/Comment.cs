using CoreBlog.Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Entities.Concrete
{
    public class Comment : EntityBase, IEntity //örnek olarak CreatedName Entitybase'den geliyor. Bir daha yazmamıza gerek yok.
    {
        public  int BlogId { get; set; }
        public string CommentText { get; set; }
        public Blog Blog { get; set; }

    }
}
