using System;
using System.Collections.Generic;
using System.Text;
using WebApp.DAL.Core.Repositories;

namespace WebApp.DAL.Persistence.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> CreateGenericRepository<TEntity>() where TEntity : class;

        ISettingRepository SettingRepository { get; }
        IUserRepository UserRepository { get; }
        IArtDirectoryRepository ArtDirectoryRepository { get; }
        int Commit();
    }
}
