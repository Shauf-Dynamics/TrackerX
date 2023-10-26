using AutoMapper;
using TrackerX.Core.Services.Accounts.Invitations.Models;
using TrackerX.Core.Services.Accounts.Users.Model;
using TrackerX.Core.Services.Albums.Models;
using TrackerX.Core.Services.Lessons.Models;
using TrackerX.Core.Services.Songs.Models;
using TrackerX.Domain.Entities;

namespace TrackerX.Core.Mapping
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
