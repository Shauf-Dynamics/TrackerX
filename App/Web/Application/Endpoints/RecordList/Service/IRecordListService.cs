using Web.Application.Endpoints.RecordList.Models;

namespace Web.Application.Endpoints.RecordList.Service
{
    public interface IRecordListService
    {
        Task<RecordListResult> GetRecordList(int userId);
    }
}
