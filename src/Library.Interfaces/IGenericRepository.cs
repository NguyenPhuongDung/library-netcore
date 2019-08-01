using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Library.Entities;

namespace Library.Interfaces
{

    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAll();
        List<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        bool Add(TEntity entity);
        bool Delete(TEntity entity);
        bool Edit(TEntity entity);
        bool Save();
        bool SaveChanges(TEntity entity);
        TEntity FindById(int id);

    }
}