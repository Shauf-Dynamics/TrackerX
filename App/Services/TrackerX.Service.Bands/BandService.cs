using TrackerX.Domain.Entities;
using TrackerX.Domain.Entities.Repositories;
using TrackerX.Services.Bands.Models;

namespace TrackerX.Services.Bands;

public class BandService : IBandService
{
    private IBandRepository _bandRepository;

    public BandService(IBandRepository bandRepository)
    {
        _bandRepository = bandRepository;
    }

    public async Task<IEnumerable<BandsViewModel>> GetBandsByCriterias(BandsSearchParams criterias)
    {
        var result = await _bandRepository.GetBySearchingCriteriasAsync(criterias.PageSize, criterias.StartsWith);

        return result.Select(x => new BandsViewModel() { BandName = x.BandName });
    }

    public async Task CreateBand(CreateBandModel name)
    {
        var band = new Band();
        band.BandName = name.BandName;

        _bandRepository.Create(band);

        await _bandRepository.SaveChangesAsync();
    }

    public async Task RenameBand(int bandId, string newName)
    {
        var band = await _bandRepository.GetByIdAsync(bandId);
        band.BandName = newName;

        await _bandRepository.SaveChangesAsync();
    }
}
