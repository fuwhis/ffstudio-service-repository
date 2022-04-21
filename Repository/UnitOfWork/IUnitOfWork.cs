using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public interface IUnitOfWork<out TContext> where TContext : DbContext, new()
    {
        //Register repositories
        TContext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
        Task SaveAsync();
        GenericRepository<T> GenericRepository<T>() where T : class;
    }
}
