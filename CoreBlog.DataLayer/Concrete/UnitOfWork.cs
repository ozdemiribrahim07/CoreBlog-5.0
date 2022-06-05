using CoreBlog.DataLayer.Abstract;
using CoreBlog.DataLayer.Concrete.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataLayer.Concrete
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly CoreBlogContext _context;
        private EFBlogRepo _blogRepo;
        private EFCommentRepo _commentRepo;
        private EFCategoryRepo _categoryRepo;

        public UnitOfWork(CoreBlogContext context)
        {
            _context = context;
        }

        public IBlogRepo Blogs => _blogRepo ?? new EFBlogRepo(_context);

        public ICommentRepo Comments => _commentRepo ?? new EFCommentRepo(_context);

        public ICategoryRepo Categories => _categoryRepo ?? new EFCategoryRepo(_context);


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
