using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Library.Interfaces;
using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private LibraryContext _context;
        private DbSet<TEntity> entities;

        public GenericRepository(LibraryContext context)
        {
            this._context = context;
            entities = context.Set<TEntity>();
        }

        public virtual List<TEntity> GetAll()
        {

            IQueryable<TEntity> query = entities;
            return query.ToList();
        }

        public List<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = entities.Where(predicate);
            return query.ToList();
        }
        public virtual void Attach(TEntity entity)
        {
            entities.Attach(entity);
        }

        public virtual bool Add(TEntity entity)
        {
            entities.Add(entity);
            return true;
        }

        public virtual bool Delete(TEntity entity)
        {
            entities.Remove(entity);
            return true;
        }

        public virtual bool Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            _context.SaveChanges();
            return true;
        }

        public virtual bool SaveChanges(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                entities.Attach(entity);
            }
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
        public virtual TEntity FindById(int id)
        {
            return entities.Find(id);
        }
    }

}