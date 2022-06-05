using CoreBlog.Shared.Utilitie.Sonuc.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.Entity.Abstract
{
    public abstract class DtoBaseGet
    {
        public virtual SonucStatus SonucStatus { get; set; }
        public virtual string Message { get; set; }

    }
}
