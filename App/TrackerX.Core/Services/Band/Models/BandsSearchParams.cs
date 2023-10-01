namespace TrackerX.Core.Services.Band.Models
{
    public class BandsSearchParams
    {
        public int PageSize { get; set; }

        public string StartsWith { get; set; }

        public BandsSearchParams(int pageSize, string startsWith)
        {
            PageSize = pageSize;
            StartsWith = startsWith;
        }
    }
}
