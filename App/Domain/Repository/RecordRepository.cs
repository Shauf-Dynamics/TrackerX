using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly DataContext _context;

        public RecordRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Record>> GetLastRecords(int amount, int userId)
        {
            return await _context.Records
                .Take(amount)
                .Where(x => !x.IsDeleted)
                .ToListAsync();            
        }
    }
}
