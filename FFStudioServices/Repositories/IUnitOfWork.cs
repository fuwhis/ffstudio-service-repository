namespace FFStudioServices.Repositories
{
    public interface IUnitOfWork 
    {
        //IGenericRepository<T> GetRepository<T>() where T : class;

        void Save(); 
    }
}
