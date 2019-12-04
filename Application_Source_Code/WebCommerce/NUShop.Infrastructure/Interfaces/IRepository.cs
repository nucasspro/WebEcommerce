using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NUShop.Infrastructure.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">T is entity class/entity</typeparam>
    /// <typeparam name="K">K is type</typeparam>
    public interface IRepository<T, K> where T : class
    {
        T GetById(K id, params Expression<Func<T, object>>[] includeProperties);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);

        void Remove(K id);

        void RemoveMultiple(List<T> entities);

    }
}
