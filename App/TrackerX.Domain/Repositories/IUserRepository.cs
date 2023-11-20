using TrackerX.Domain.Entities;
using TrackerX.Domain.Infrastructure;

namespace TrackerX.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByCredentialsAsync(string login);
    }
}
