using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;
using TrackerX.Domain.Repositories;

namespace TrackerX.Domain.Data.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DataContext context) : base(context) { }

    public async override Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> predicate)
    {
        return await Context.Users
            .Include(x => x.RoleType)
            .FirstOrDefaultAsync(predicate);
    }

    public async Task<User> GetUserByCredentialsAsync(string login)
    {
        var users = Context.Users
            .Include(x => x.RoleType);

        return await users.FirstOrDefaultAsync(x => x.Email == login || x.Name == login);
    }
}
