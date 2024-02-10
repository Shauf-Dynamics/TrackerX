namespace TrackerX.Services.Bands.Models;

public class BandSearchParams
{
    public int PageSize { get; set; }

    public string StartsWith { get; set; }

    public BandSearchParams(int pageSize, string startsWith)
    {
        PageSize = pageSize;
        StartsWith = startsWith;
    }
}
