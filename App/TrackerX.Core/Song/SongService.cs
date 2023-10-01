using TrackerX.Core.Song.Models;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Song
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task Create(CreateSongModel model)
        {
            var song = new Domain.Entities.Song();
            song.SongName = model.SongName;
            song.BandId = model.BandId;

            _songRepository.Create(song);

            await _songRepository.SaveChanges();
        }

        public async Task RenameSong(int songId, string newSongName)
        {
            var song = await _songRepository.GetById(songId);
            song.SongName = newSongName;

            await _songRepository.SaveChanges();
        }

        public async Task<IEnumerable<SongViewModel>> GetSongsByBandId(int bandId)
        {
            var songs = await _songRepository.GetWhere(x => x.BandId == bandId);

            return songs.Select(x => new SongViewModel() { SongName = x.SongName });
        }        
    }
}
