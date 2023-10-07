using AutoMapper;
using TrackerX.Core.Services.Songs.Models;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Songs
{
    public class SongService : ISongService
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateSongModel model)
        {
            var song = _mapper.Map<Song>(model);

            _songRepository.Create(song);

            await _songRepository.SaveChanges();
        }

        public async Task RenameSong(int songId, string newSongName)
        {
            var song = await _songRepository.GetById(songId);
            song.SongName = newSongName;

            await _songRepository.SaveChanges();
        }

        public async Task AssingToAlbum(int albumId, int songId)
        {
            var song = await _songRepository.GetById(songId);            
            song.AlbumId = albumId;
            _songRepository.Update(song);

            await _songRepository.SaveChanges();
        }

        public async Task<IEnumerable<SongViewModel>> GetSongsByBandId(int bandId)
        {
            var source = await _songRepository.GetByBandId(bandId);
            var songs = source.Select(item =>
            {
                var song = _mapper.Map<SongViewModel>(item);
                if (item.Genre.ParentGenreId.HasValue)
                {
                    song.Subgenre = item.Genre.GenreName;
                    song.Genre = item.Genre.ParentGenre.GenreName;
                }
                else
                {
                    song.Genre = item.Genre.GenreName;
                }

                return song;
            });

            return songs;
        }        
    }
}
