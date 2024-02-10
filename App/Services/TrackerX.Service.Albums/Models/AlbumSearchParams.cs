namespace TrackerX.Service.Albums.Models;

public class AlbumSearchParams
{
    public int PageSize { get; set; }

    public string StartsWith { get; set; }

    public AlbumSearchParams(int pageSize, string startsWith)
    {
        PageSize = pageSize;
        StartsWith = startsWith;
    }
}
