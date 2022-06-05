using CoreBlog.Shared.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Shared.DataLayer.Abstract
{
    public interface IEntityRepo<T> where T : class , IEntity, new()
    {
        Task<T> AddAsync(T t);
        Task<T> UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter); // Daha önceden birisi aynı isim ile kayıt olmuş mu?
        Task<int> CountAsync(Expression<Func<T, bool>> filter=null); //Admin paneli listeleme
        Task<T> GetAsync(Expression<Func<T,bool>> filter, params Expression<Func<T,object>>[] include);  //belirli bir getiri için expression filtreleme yapılır. Birden fazla parametre getirmesi için params,object eklenir.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include);


    }
}
