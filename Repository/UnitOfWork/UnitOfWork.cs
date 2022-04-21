using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Repository.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable 
        where TContext : DbContext, new()
    {
        private readonly TContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private IDbContextTransaction _objTransaction;
        private Dictionary<string, object> _repositories;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        #region repositories
        // Use registered repositories
        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public TContext Context
        {
            get { return _context; }
        }

        public void CreateTransaction()
        {
            _objTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _objTransaction.Commit();
        }

        public void Rollback()
        {
            _objTransaction.Rollback();
            _objTransaction.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
                if(disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public GenericRepository<T> GenericRepository<T>() where T : class
        {
            if(_repositories == null)
                _repositories = new Dictionary<string, object>();
            var type = typeof(T).Name;
            if(!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<T>);
                var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
                _repositories.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)_repositories[type];
        }
    }
}
