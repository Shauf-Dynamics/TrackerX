﻿using AutoMapper;
using TrackerX.Core.Services.Album.Models;
using TrackerX.Domain.Repositories;

namespace TrackerX.Core.Services.Album
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task Create(CreateAlbumModel model)
        {
            var album = _mapper.Map<Domain.Entities.Album>(model);

            _albumRepository.Create(album);

            await _albumRepository.SaveChanges();
        }        

        public async Task<AlbumViewModel> GetAlbumById(int id)
        {
            return _mapper.Map<AlbumViewModel>(await _albumRepository.GetById(id));
        }
    }
}
