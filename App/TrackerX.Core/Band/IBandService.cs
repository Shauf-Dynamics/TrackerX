using TrackerX.Core.Band.Models;

namespace TrackerX.Core.Band
{
    public interface IBandService
    {
        Task CreateBand(CreateBandModel name);

        Task RenameBand(int bandId, string newName);

        Task<IEnumerable<BandsViewModel>> GetBandsByCriterias(BandsSearchParams criterias);
    }
}
