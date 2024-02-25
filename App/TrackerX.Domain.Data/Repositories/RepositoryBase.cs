using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Data.Repositories;

public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
{
    protected DataContext Context { get; private set; }

    public RepositoryBase(DataContext context)
    {
        Context = context;
    }

    public T Create(T entity)
    {
        Context.Set<T>().Add(entity);
        return entity;
    }

    public void Update(T entity)
    {
        Context.Entry<T>(entity).State = EntityState.Modified;
    }

    public void Remove(T entity, bool isSoftDelete = false)
    {
        if (isSoftDelete)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
            Context.Entry(entity).Property("IsDeleted").CurrentValue = true;
        }
        else
        {
            Context.Set<T>().Remove(entity);
        }        
    }

    public async virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(predicate);
    }        

    public async Task<T> GetByIdAsync(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Context.Set<T>().ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}
