using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new() //IEntity -> DB nesneleri için bir imza
    {
        //Predicate filtremiz
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties); //GET Async method. || Expression -> var kullanici = repository.GetAsync(k=>k.Id ==15); gibi"
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties); //Predicate null verdik çünkü bütün makaleleri de isteyebiliriz, veya sadece C# kategorisini isteyebiliriz.   
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IList<T>> SearchAsync(IList<Expression<Func<T,bool>>> predicates, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //Any, var mı anlamında kullanılmaktadır. Alper isimli bir kullanıcı var mı? .AnyAsync(u=>u.FirstName=="Alper"); gibi.
        Task<int> CountAsync(Expression<Func<T, bool>> predicate=null);
    }
}
