using CoreBlog.Shared.Utilitie.Sonuc.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.Utilitie.Sonuc.Abstract
{
    public interface ISonuc
    {
        public SonucStatus SonucStatus { get; }
        public string Message { get;  }
        public Exception Exception { get; }

    }
}
