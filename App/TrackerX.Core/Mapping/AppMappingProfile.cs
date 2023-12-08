using AutoMapper;
using TrackerX.Core.Services.Accounts.Invitations.Models;
using TrackerX.Core.Services.Accounts.Users.Models;
using TrackerX.Core.Services.Albums.Models;
using TrackerX.Core.Services.Lessons.Models;
using TrackerX.Core.Services.Musics.Models;
using TrackerX.Domain.Entities;

namespace TrackerX.Core.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CreateMusicModel, Song>()
                .ForMember(dest => dest.SongName, opt => opt.MapFrom(src => src.Name));

            CreateMap<Song, SongSearchView>()
                .ForMember(dest => dest.Band, opt => opt.MapFrom(src => src.Band.BandName))
                .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album.AlbumName))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.WritingYear));
            CreateMap<Song, SongDetailsView>()
                .ForMember(dest => dest.Band, opt => opt.MapFrom(src => src.Band.BandName))
                .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album.AlbumName))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SongName))
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.Subgenre, opt => opt.Ignore());
            CreateMap<Song, MusicViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.Ignore())
                .ForMember(dest => dest.BandName, opt => opt.MapFrom(src => src.Band.BandName));

            CreateMap<CreateAlbumModel, Album>();
            CreateMap<Album, AlbumViewModel>();

            CreateMap<CreateExerciseModel, Exercise>()
                .ForMember(dest => dest.ExerciseType, opt => opt.Ignore())
                .ForMember(dest => dest.TempoType, opt => opt.Ignore())
                .ForMember(dest => dest.Song, opt => opt.Ignore())
                .ForMember(dest => dest.Lesson, opt => opt.Ignore());

            CreateMap<CreateUserModel, User>();

            CreateMap<Invitation, InvitationModel>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null));
        }
    }
}
