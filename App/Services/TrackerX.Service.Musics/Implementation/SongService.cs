using AutoMapper;
using TrackerX.Services.Musics.Models;
using TrackerX.Domain.Repositories;
using TrackerX.Domain.Entities;
using TrackerX.Services.Musics;
using TrackerX.Services.Infrastructure;
using TrackerX.Infrastructure;

namespace TrackerX.Service.Musics.Implementation;

public class SongService : ISongService
{
    private readonly ISongRepository _songRepository;
    private readonly IMapper _mapper;

    public SongService(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _mapper = mapper;
    }

    [Obsolete]
    public async Task AssingSongToAlbumAsync(int albumId, int songId)
    {
        var song = await _songRepository.GetByIdAsync(songId);
        song.AlbumId = albumId;
        _songRepository.Update(song);

        await _songRepository.SaveChangesAsync();
    }

    public async Task<ServiceResult> CreateAsync(CreateSongModel model)
    {
        if ((await _songRepository.FirstOrDefaultAsync(x => x.SongName == model.SongName)) != null)
            return new ServiceResult(StatusType.Invalid, "Song with this name already exists.");

        var song = _mapper.Map<Song>(model);

        _songRepository.Create(song);
        await _songRepository.SaveChangesAsync();

        return ServiceResult.Success;
    }
}
