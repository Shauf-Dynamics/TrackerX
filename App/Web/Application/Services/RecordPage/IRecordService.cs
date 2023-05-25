using Web.Application.Endpoints.RecordPage.Models;

namespace Web.Application.Endpoints.RecordPage.Service
{
    public interface IRecordService
    {
        Task<RecordView> GetRecord(int recordId, int userId);

        Task CreateRecord(RecordCreateModel model);
    }
}
