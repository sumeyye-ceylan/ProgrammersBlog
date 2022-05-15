using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class ,IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, Object>>[] includeProperties); // filtreleme yaptığımız kısma predicate diyoruz 
        Task<IList<T>> GeltAllAsync(Expression<Func<T, bool>> predicate=null, params Expression<Func<T, Object>>[] includeProperties);
        //yukarıdaki getallasync methodunda predicate  gelirse bir filtreleme yapmalıyız , null gelirse de tüm entityleri yükleyebiliriz 
        Task<T> AddAsync(T EntitY);
        Task<T> UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null);
    }
}
