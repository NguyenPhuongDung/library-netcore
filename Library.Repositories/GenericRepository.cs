using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Library.Interfaces;
using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        readonly DbSet<TEntity> _entities;
        protected LibraryContext RepositoryContext { get; set; }

        public RepositoryBase(LibraryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
            _entities = RepositoryContext.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            var entity = _entities.Find(id);
            RepositoryContext.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public bool IsExits(int id)
        {
            return _entities.Find(id) != null;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entities.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
        }
        public void CreateAll(List<TEntity> entity)
        {
            this.RepositoryContext.Set<TEntity>().AddRange(entity);
        }
    }
}