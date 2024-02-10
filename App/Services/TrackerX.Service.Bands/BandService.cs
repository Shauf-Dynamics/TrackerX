using AutoMapper;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Entities.Repositories;
using TrackerX.Services.Bands.Models;

namespace TrackerX.Services.Bands;

public class BandService : IBandService
{
    private readonly IBandRepository _bandRepository;
    private readonly IMapper _mapper;

    public BandService(IBandRepository bandRepository, IMapper mapper)
    {
        _bandRepository = bandRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BandsViewModel>> GetBandsByCriterias(BandSearchParams criterias)
    {
        var result = await _bandRepository.GetBySearchingCriteriasAsync(criterias.PageSize, criterias.StartsWith);

        return _mapper.Map<IEnumerable<BandsViewModel>>(result);
    }

    public async Task CreateBand(CreateBandModel name)
    {
        var band = new Band()
        {
            BandName = name.BandName
        };

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
