using FFStudioServices.Context;

namespace FFStudioServices.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PostgreContext _postgreContext;
        private bool IsDisposed = false;

        public UnitOfWork(PostgreContext context)
        {
            this._postgreContext = context;
        }

        #region repositories
        // Use registered repositories
        #endregion

        public void Save() => _postgreContext.SaveChanges();

        public void Dispose() => _postgreContext.Dispose();
    }
}
