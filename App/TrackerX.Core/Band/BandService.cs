using TrackerX.Core.Band.Models;
using TrackerX.Domain.Entities.Repositories;

namespace TrackerX.Core.Band
{
    public class BandService : IBandService
    {        
        private IBandRepository _bandRepository;

        public BandService(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public async Task<IEnumerable<BandsViewModel>> GetBandsByCriterias(BandsSearchParams criterias)
        {
            var result = await _bandRepository.GetBySearchingCriterias(criterias.PageSize, criterias.StartsWith);

            return result.Select(x => new BandsViewModel() { BandName = x.BandName });
        }

        public async Task CreateBand(CreateBandModel name)
        {
            var band = new Domain.Entities.Band();
            band.BandName = name.BandName;

            _bandRepository.Create(band);

            await _bandRepository.SaveChanges();
        }        

        public async Task RenameBand(int bandId, string newName)
        {
            var band = await _bandRepository.GetById(bandId);
            band.BandName = newName;

            await _bandRepository.SaveChanges();
        }
    }
}
