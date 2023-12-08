using AutoMapper;
using TrackerX.Core.Services.Musics.Models;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Music
{
    public class MusicSearchService : IMusicSearchService
    {
        private readonly IMapper _mapper;
        private readonly IMusicRepository _musicRepository;

        public MusicSearchService(IMusicRepository musicRepository, IMapper mapper)
        {
            _musicRepository = musicRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MusicSearchView>> GetMusicListBySearchCriterias(string text, string searchBy)
        {
            if (string.IsNullOrEmpty(text))            
                text = string.Empty;
                            
            if (string.IsNullOrEmpty(searchBy))
                searchBy = "name";

            var source = await _musicRepository.GetBySearchCriteriasdAsync(text, searchBy);

            return _mapper.Map<IEnumerable<MusicSearchView>>(source);
        }

        public async Task<MusicDetailsView> GetMusicById(int musicId)
        {
            var source = await _musicRepository.FirstOrDefaultAsync(x => x.MusicId == musicId);                
            var music = _mapper.Map<MusicDetailsView>(source);

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
