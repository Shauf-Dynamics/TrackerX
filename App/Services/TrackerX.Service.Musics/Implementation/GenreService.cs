using AutoMapper;
using TrackerX.Domain.Repositories;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Service.Musics.Implementation;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GenreService(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenresResult>> GetAllGenresAsync()
    {
        var source = await _genreRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<GenresResult>>(source);
    }
}
