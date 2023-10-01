using TrackerX.Domain.Entities;

namespace TrackerX.Domain.Infrastructure.Repositories
{
    public interface IRecordRepository : IRepository<Record>
    {
        Task<IEnumerable<Record>> GetLastRecords(int amount, int userId);

        Task<Record> GetByUserId(int recordId, int userId);
    }
}
