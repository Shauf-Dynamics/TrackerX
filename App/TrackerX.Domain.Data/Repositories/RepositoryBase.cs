using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : BaseEntity
    {
        protected DataContext Context { get; private set; }

        public RepositoryBase(DataContext context)
        {
            Context = context;
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            Context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(predicate);
        }        

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task SaveChanges()
        {
            await Context.SaveChangesAsync();

        }
    }
}
