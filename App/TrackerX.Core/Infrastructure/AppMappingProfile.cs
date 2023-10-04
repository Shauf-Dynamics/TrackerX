using AutoMapper;
using TrackerX.Core.Services.Album.Models;
using TrackerX.Core.Services.Song.Models;
using TrackerX.Domain.Entities;

namespace TrackerX.Core.Infrastructure
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateSongModel, Song>()
                .ForMember(dest => dest.SongName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Song, SongViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band.BandName));

            CreateMap<CreateAlbumModel, Album>();
            CreateMap<Album, AlbumViewModel>();
        }
    }
}
