using Microsoft.EntityFrameworkCore;
using NUShop.Infrastructure.Interfaces;
using NUShop.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NUShop.Data.EF
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T">is entity class</typeparam>
    /// <typeparam name="K"></typeparam>
    public class Repository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>().AsNoTracking();
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    items = items.Include(property);
                }
            }
            return items;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = GetAll(includeProperties);
            return items.Where(predicate);
        }

        public T GetById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return GetAll(includeProperties).AsNoTracking().SingleOrDefault(x => x.Id.Equals(id));
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return GetAll(includeProperties).SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Remove(K id)
        {
            var entity = GetById(id);
            Remove(entity);
        }

        public void RemoveMultiple(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

    }
}