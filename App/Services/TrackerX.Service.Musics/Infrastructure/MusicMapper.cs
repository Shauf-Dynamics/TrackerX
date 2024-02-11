using AutoMapper;
using TrackerX.Domain.Entities;
using TrackerX.Service.Musics.Models;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Service.Musics.Infrastructure;

public class MusicMapper : Profile
{
    public MusicMapper()
    {
        CreateMap<CreateSongModel, Song>();

        CreateMap<CreateCustomMusicModel, CustomMusic>()
            .ForMember(dest => dest.CustomMusicDescription, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author));

        CreateMap<Song, SongViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.Ignore())
            .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band.BandName));

        CreateMap<Song, SongSearchResult>()
            .ForMember(dest => dest.Band, opt => opt.MapFrom(src => src.Band.BandName))
            .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album.AlbumName));

        CreateMap<Song, SongDetailsResult>()
            .ForMember(dest => dest.Band, opt => opt.MapFrom(src => src.Band.BandName))
            .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album.AlbumName))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SongName))
            .ForMember(dest => dest.Genre, opt => opt.Ignore())
            .ForMember(dest => dest.Subgenre, opt => opt.Ignore());

        CreateMap<Genre, GenresResult>();
    }
}
