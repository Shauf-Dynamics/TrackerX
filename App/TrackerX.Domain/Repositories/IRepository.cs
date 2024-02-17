using System.Linq.Expressions;

namespace TrackerX.Domain.Infrastructure;

public interface IRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    T Create(T entity);
    void Update(T entity);
    void Remove(T entity);

    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

    Task SaveChangesAsync();
}
