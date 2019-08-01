using System;
using Library.Entities;
using Library.Interfaces;
using Library.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        private IGenericRepository<Post> postRepository;


        public UnitOfWork(LibraryContext context)
        {
            this._context = context;
        }
        public IGenericRepository<Post> PostRepository
        {
            get { return this.postRepository ?? (this.postRepository = new GenericRepository<Post>(_context)); }
        }
        public void Save()
        {
            try
            {
                if (_context.ChangeTracker.HasChanges())
                {
                    foreach (var entry in _context.ChangeTracker.Entries())
                    {
                        var root = (BaseEntity)entry.Entity;
                        var now = DateTime.Now;
                        switch (entry.State)
                        {
                            case EntityState.Added:
                                {
                                    root.InsertDate = now;
                                    root.InsertId = 1;
                                    root.UpdateDate = now;
                                    root.UpdateId = 1;
                                    break;
                                }
                            case EntityState.Modified:
                                {
                                    root.UpdateDate = now;
                                    root.UpdateId = 1;
                                    break;
                                }
                        }
                    }
                    _context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
