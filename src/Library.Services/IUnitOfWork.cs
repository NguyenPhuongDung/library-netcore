using System;
using System.Collections.Generic;
using System.Text;

using Library.Entities;
using Library.Interfaces;

namespace Library.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Post> PostRepository { get; }
        void Save();
    }
}
