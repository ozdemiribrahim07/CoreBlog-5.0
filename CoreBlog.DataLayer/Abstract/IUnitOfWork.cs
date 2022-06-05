using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataLayer.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable //UnitOfWork ile Repo'ları tek bir yerden yönetiriz. İş biter bitmez kaynakları kapatmak için IDisposable kullanılır. 
    {
        IBlogRepo Blogs { get; }
        ICommentRepo Comments { get; }
        ICategoryRepo  Categories { get; }

        Task<int> SaveAsync();

    }
}
