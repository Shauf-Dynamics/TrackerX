using Domain.Entity;
using Domain.Repository;
using Web.Application.Endpoints.Dashboard.Models;
using Web.Application.Endpoints.RecordList.Models;

namespace Web.Application.Endpoints.Dashboard.Service
{
    public class DashboardService : IDashboardService
    {
        private const int LastRecordsAmount = 7;

        private readonly IRecordRepository _recordRepository;

        public DashboardService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task<DashboardResult> GetDashboardResult(int usedId)
        {
            var result = new DashboardResult();

            var records = await _recordRepository.GetLastRecords(LastRecordsAmount, default);

            if (records.Any())
            {
                result.LastRecords = records.Select(x => new RecordItem() { Id = x.Id, DateTime = x.RecordCreated });
                result.LastTrackedDateTime = records.OrderByDescending(x => x.RecordCreated).First().RecordCreated;
                result.LastWeekActiveDays = CalculateActiveDays(records);
            }

            return result;    
        }

        private int CalculateActiveDays(IEnumerable<Record> records)
        {
            //  TODO
            return 1;
        }
    }
}
