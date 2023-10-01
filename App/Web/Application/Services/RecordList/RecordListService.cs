using Microsoft.EntityFrameworkCore;
using TrackerX.Domain.Infrastructure;
using Web.Application.Endpoints.RecordList.Models;

namespace Web.Application.Endpoints.RecordList.Service
{
    public class RecordListService : IRecordListService
    {
        private readonly DataContext _context;

        public RecordListService(DataContext context)
        {
            _context = context;
        }

        public async Task<RecordListResult> GetRecordList(int userId)
        {
            var response = new RecordListResult();

            var query = _context.Records.AsQueryable();
            var requestResult = await query.ToListAsync();

            response.Items = requestResult.Select(x => new RecordItem() { DateTime = x.RecordCreated, Id = x.Id });

            return response;
        }
    }
}
