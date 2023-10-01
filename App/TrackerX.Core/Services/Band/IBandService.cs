using TrackerX.Core.Services.Band.Models;

namespace TrackerX.Core.Services.Band
{
    public interface IBandService
    {
        Task CreateBand(CreateBandModel name);

        Task RenameBand(int bandId, string newName);

        Task<IEnumerable<BandsViewModel>> GetBandsByCriterias(BandsSearchParams criterias);
    }
}
