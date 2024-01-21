using AutoMapper;
using TrackerX.Core.Services.Albums.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;

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

    public async virtual Task Create(CreateAlbumModel model)
    {
        var album = _mapper.Map<Album>(model);

        _albumRepository.Create(album);

        await _albumRepository.SaveChangesAsync();
    }        

    public async Task<AlbumViewModel> GetAlbumById(int id)
    {
        return _mapper.Map<AlbumViewModel>(await _albumRepository.GetByIdAsync(id));
    }
}
