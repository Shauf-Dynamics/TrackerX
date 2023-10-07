using TrackerX.Core.Services.Bands.Models;

namespace TrackerX.Core.Services.Bands
{
    public interface IBandService
    {
        Task CreateBand(CreateBandModel name);

        Task RenameBand(int bandId, string newName);

        Task<IEnumerable<BandsViewModel>> GetBandsByCriterias(BandsSearchParams criterias);
    }
}
