using AutoMapper;
using TrackerX.Domain.Repositories;
using TrackerX.Services.Musics;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Services.Music;

public class MusicSearchService : IMusicSearchService
{
    private readonly IMapper _mapper;
    private readonly ISongRepository _songRepository;
    private readonly IGenreRepository _genreRepository;

    public MusicSearchService(ISongRepository songRepository, IGenreRepository genreRepository, IMapper mapper)
    {
        _songRepository = songRepository;
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SongSearchResult>> GetMusicListBySearchCriterias(string text, string searchBy)
    {
        var source = await _songRepository.GetBySearchCriteriasAsync(text, searchBy);

        return _mapper.Map<IEnumerable<SongSearchResult>>(source);
    }

    public async Task<SongDetailsResult> GetMusicById(int musicId)
    {
        var source = await _songRepository.FirstOrDefaultAsync(x => x.SongId == musicId);
        var music = _mapper.Map<SongDetailsResult>(source);

        if (source.Genre.ParentGenreId.HasValue)
        {
            music.Subgenre = source.Genre.GenreName;
            music.Genre = source.Genre.ParentGenre.GenreName;
        }
        else
        {
            music.Genre = source.Genre.GenreName;
        }

        return music;
    }

    public async Task<IEnumerable<GenresResult>> GetAllGenres()
    {
        var source = await _genreRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<GenresResult>>(source);
    }
}
