using Domain.Entity;
using Domain.Repository;
using Web.Application.Endpoints.RecordPage.Models;

namespace Web.Application.Endpoints.RecordPage.Service
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;

        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public async Task CreateRecord(RecordCreateModel model)
        {
            var record = new Record()
            {
                RecordCreated = model.DateTimeCreated.Value
            };

            await _recordRepository.AddRecord(record);
        }

        public async Task<RecordView> GetRecord(int recordId, int userId)
        {
            RecordView result = null;

            var record = await _recordRepository.GetRecord(recordId, userId);

            if (record != null)
            {
                result = Map(record);
            }

            return result;
        }

        private RecordView Map(Record record)
        {
            return new RecordView()
            {
                Id = record.Id,
                DateCreated = record.RecordCreated
            };
        }
    }
}