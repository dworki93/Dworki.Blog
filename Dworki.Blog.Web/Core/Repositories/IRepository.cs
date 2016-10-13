using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dworki.Blog.Web.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}