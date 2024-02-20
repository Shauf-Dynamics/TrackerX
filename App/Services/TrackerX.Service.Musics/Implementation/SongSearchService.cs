using AutoMapper;
using TrackerX.Domain.Repositories;
using TrackerX.Services.Musics;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Service.Musics.Implementation;

public class SongSearchService : ISongSearchService
{
    private readonly IMapper _mapper;
    private readonly ISongRepository _songRepository;    

    public SongSearchService(ISongRepository songRepository, IMapper mapper)
    {
        _songRepository = songRepository;        
        _mapper = mapper;
    }

    public async Task<IEnumerable<SongSearchResult>> SearchSongsAsync(string text, string searchBy)
    {
        var source = await _songRepository.SearchAsync(text, searchBy, true);                

        return _mapper.Map<IEnumerable<SongSearchResult>>(source);
    }

    public async Task<SongDetailsResult> GetSongByIdAsync(int songId)
    {
        var source = await _songRepository.FirstOrDefaultAsync(x => x.SongId == songId);
        var song = _mapper.Map<SongDetailsResult>(source);

        if (source.Genre.ParentGenreId.HasValue)
        {
            song.Subgenre = source.Genre.GenreName;
            song.Genre = source.Genre.ParentGenre.GenreName;
        }
        else
        {
            song.Genre = source.Genre.GenreName;
        }

        return song;
    }
}
