using AutoMapper;
using TrackerX.Core.Services.Albums.Models;
using TrackerX.Domain.Entities;

namespace TrackerX.Service.Albums.Infrastructure;

public class AlbumMapper : Profile
{
    public AlbumMapper()
    {
        CreateMap<CreateAlbumModel, Album>();

        CreateMap<Album, AlbumViewModel>();
    }
}
