using Microsoft.EntityFrameworkCore.Storage;
using ApollosLibrary.IDP.DataLayer;
using System;
using System.Threading.Tasks;
using ApollosLibrary.IDP.Domain.Model;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using ApollosLibrary.IDP.DataLayer.Contracts;

namespace ApollosLibrary.IDP.UnitOfWork
{
    public class UserUnitOfWork : IUserUnitOfWork, IDisposable
    {
        private ApollosLibraryIDPContext _dbContext;
        private IDbContextTransaction _transaction;
        private IUserDataLayer _userDataLayer;
        private bool disposed = false;

        public UserUnitOfWork(ApollosLibraryIDPContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IUserDataLayer UserDataLayer
        {
            get
            {
                if (_userDataLayer == null)
                {
                    _userDataLayer = new UserDataLayer(_dbContext);
                }
                return _userDataLayer;
            }
        }

        public async Task Begin()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }
                _dbContext.Dispose();
            }

            disposed = true;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        ~UserUnitOfWork()
        {
            Dispose(false);
        }
    }
}
