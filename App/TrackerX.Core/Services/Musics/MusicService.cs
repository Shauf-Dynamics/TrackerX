﻿using AutoMapper;
using TrackerX.Core.Services.Musics.Models;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Music
{
    public class MusicService : IMusicService
    {
        private readonly IMapper _mapper;
        private readonly ISongRepository _songRepository;

        public MusicService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateMusicModel model)
        {
            var song = _mapper.Map<Domain.Entities.Song>(model);

            _songRepository.Create(song);

            await _songRepository.SaveChangesAsync();
        }

        public async Task RenameSong(int songId, string newSongName)
        {
            var song = await _songRepository.GetByIdAsync(songId);
            song.SongName = newSongName;

            await _songRepository.SaveChangesAsync();
        }

        public async Task AssingToAlbum(int albumId, int songId)
        {
            var song = await _songRepository.GetByIdAsync(songId);            
            song.AlbumId = albumId;
            _songRepository.Update(song);

            await _songRepository.SaveChangesAsync();
        }    
    }
}