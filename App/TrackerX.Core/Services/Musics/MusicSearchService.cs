using AutoMapper;
using TrackerX.Core.Services.Musics.Models;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Music
{
    public class MusicSearchService : IMusicSearchService
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _musicRepository;

        public MusicSearchService(ISongRepository musicRepository, IMapper mapper)
        {
            _musicRepository = musicRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SongSearchView>> GetMusicListBySearchCriterias(string text, string searchBy)
        {
            if (string.IsNullOrEmpty(searchBy))
                searchBy = "name";

            var source = await _musicRepository.GetBySearchCriteriasAsync(text, searchBy);

            return _mapper.Map<IEnumerable<SongSearchView>>(source);
        }

        public async Task<SongDetailsView> GetMusicById(int musicId)
        {
            var source = await _musicRepository.FirstOrDefaultAsync(x => x.SongId == musicId);                
            var music = _mapper.Map<SongDetailsView>(source);

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
    }
}
