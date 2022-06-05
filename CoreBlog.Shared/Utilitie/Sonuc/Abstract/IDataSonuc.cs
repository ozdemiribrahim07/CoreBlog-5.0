using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.Utilitie.Sonuc.Abstract
{
    public interface IDataSonuc<out T> : ISonuc  // out T sayesinde istersek bir entitie veya liste getirebiliriz. Ayrı ayrı yazmamıza gerek kalmaz.
    {
        public T Data { get; }

    }
}
