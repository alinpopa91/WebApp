using System;
using System.Collections.Generic;
using System.Text;
using WebApp.DAL.Core.Persistence;
using WebApp.DAL.Core.Repositories;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;

namespace WebApp.DAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly WinArtContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new WinArtContext();
        }

        public IRepository<TEntity> CreateGenericRepository<TEntity>()
            where TEntity : class
        {
            return new Repository<TEntity>(_dbContext);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _artDirectoryRepository?.Dispose();
            _artDirectoryRepository = null;

            _userRepository?.Dispose();
            _userRepository = null;

            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }

        private ISettingRepository _settingRepository;
        public ISettingRepository SettingRepository
        {
            get { return _settingRepository ?? (_settingRepository = new SettingRepository(_dbContext)); }
        }

        private IArtDirectoryRepository _artDirectoryRepository;
        public IArtDirectoryRepository ArtDirectoryRepository
        {
            get { return _artDirectoryRepository ?? (_artDirectoryRepository = new ArtDirectoryRepository(_dbContext)); }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_dbContext)); }
        }

    }
}
