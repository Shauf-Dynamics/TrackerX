using Web.Application.Endpoints.RecordList.Models;

namespace Web.Application.Endpoints.Dashboard.Models
{
    public class DashboardResult
    {        
        public int LastWeekActiveDays { get; set; }

        public DateTime LastTrackedDateTime { get; set; }

        public IEnumerable<RecordItem> LastRecords { get; set; } = Enumerable.Empty<RecordItem>();
    }
}
