namespace TrackerX.Domain.Infrastructure
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);

        Task<IQueryable<T>> GetAll();

        Task Create(T entity);

        Task Update(T entity);        

        Task Delete(int id);
    }
}
