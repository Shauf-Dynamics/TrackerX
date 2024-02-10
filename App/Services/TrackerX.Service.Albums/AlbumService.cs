using AutoMapper;
using TrackerX.Core.Services.Albums.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;
using TrackerX.Service.Albums.Models;

namespace TrackerX.Core.Services.Albums;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    private readonly IMapper _mapper;

    public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
    {
        _albumRepository = albumRepository;
        _mapper = mapper;
    }

    public async virtual Task CreateAsync(CreateAlbumModel model)
    {
        var album = _mapper.Map<Album>(model);

        _albumRepository.Create(album);

        await _albumRepository.SaveChangesAsync();
    }        

    public async Task<AlbumViewModel> GetAlbumByIdAsync(int id)
    {
        return _mapper.Map<AlbumViewModel>(await _albumRepository.GetByIdAsync(id));
    }

    public async Task<IEnumerable<AlbumViewModel>> GetAlbumsByBandAsync(int bandId)
    {
        var result = await _albumRepository.GetByBandIdAsync(bandId);

        return _mapper.Map<IEnumerable<AlbumViewModel>>(result);
    }

    public async Task<IEnumerable<AlbumViewModel>> GetAlbumsByCriteriasAsync(AlbumSearchParams searchParams)
    {
        var result = await _albumRepository.GetBySearchingCriteriasAsync(searchParams.PageSize, searchParams.StartsWith);

        return _mapper.Map<IEnumerable<AlbumViewModel>>(result);
    }
}
