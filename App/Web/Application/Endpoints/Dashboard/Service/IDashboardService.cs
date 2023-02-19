using Web.Application.Endpoints.Dashboard.Service.Models;

namespace Web.Application.Endpoints.Dashboard.Service
{
    public interface IDashboardService
    {
        Task<DashboardResult> GetDashboardResult(int usedId);
    }
}
