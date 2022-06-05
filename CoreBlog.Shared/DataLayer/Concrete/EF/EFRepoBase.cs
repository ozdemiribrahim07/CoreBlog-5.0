using CoreBlog.Shared.DataLayer.Abstract;
using CoreBlog.Shared.Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.DataLayer.Concrete.EF
{
    public class EFRepoBase<T> : IEntityRepo<T> where T : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EFRepoBase(DbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            return t;
        }


        public async Task DeleteAsync(T t) // DeleteAsync olmadığı için Task.Run kullanıldı.
        {
            await Task.Run(() => { _context.Set<T>().Remove(t); });
        }


        public async Task<T> UpdateAsync(T t)
        {
            await Task.Run(() => { _context.Set<T>().Update(t); });  // UpdateAsync olmadığı için Task.Run kullanıldı.
            return t;

        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter)  //kontrol
        {
            return await _context.Set<T>().AnyAsync(filter);
        }


        public async Task<int> CountAsync(Expression<Func<T, bool>> filter=null)
        {
            return await (filter == null ? _context.Set<T>().CountAsync() : _context.Set<T>().CountAsync(filter));
            //boş ise getirme değilse filtre'ye getir.

        }


        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _context.Set<T>(); // IQuaryable özel sorgular yazabiliriz. + işlevsellik

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            return await query.ToListAsync();

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include.Any())
            {
                foreach (var item in include)
                {
                    query = query.Include(item);
                }
            }

            return await query.SingleOrDefaultAsync();
        }


    }
}
