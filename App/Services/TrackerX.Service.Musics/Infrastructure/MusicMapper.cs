using AutoMapper;
using TrackerX.Domain.Entities;
using TrackerX.Services.Musics.Models;

namespace TrackerX.Service.Musics.Infrastructure;

public class MusicMapper : Profile
{
    public MusicMapper()
    {
        CreateMap<CreateMusicModel, Song>()
            .ForMember(dest => dest.SongName, opt => opt.MapFrom(src => src.Name));

        CreateMap<Song, MusicViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.Ignore())
            .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band.BandName));

        CreateMap<Song, SongSearchResult>()
            .ForMember(dest => dest.Band, opt => opt.MapFrom(src => src.Band.BandName))
            .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album.AlbumName))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.WritingYear));

        CreateMap<Song, SongDetailsResult>()
            .ForMember(dest => dest.Band, opt => opt.MapFrom(src => src.Band.BandName))
            .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album.AlbumName))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SongName))
            .ForMember(dest => dest.Genre, opt => opt.Ignore())
            .ForMember(dest => dest.Subgenre, opt => opt.Ignore());

        CreateMap<Genre, GenresResult>();
    }
}
