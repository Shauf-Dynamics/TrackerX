using TrackerX.Services.Bands.Models;

namespace TrackerX.Services.Bands;

public interface IBandService
{
    Task CreateBand(CreateBandModel name);

    Task RenameBand(int bandId, string newName);

    Task<IEnumerable<BandsViewModel>> GetBandsByCriterias(BandSearchParams criterias);
}
