using Web.Application.Endpoints.Dashboard.Models;

namespace Web.Application.Endpoints.Dashboard.Service
{
    public interface IDashboardService
    {
        Task<DashboardResult> GetDashboardResult(int usedId);
    }
}
