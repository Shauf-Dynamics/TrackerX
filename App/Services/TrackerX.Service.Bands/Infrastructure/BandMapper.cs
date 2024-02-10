using AutoMapper;
using TrackerX.Domain.Entities;
using TrackerX.Services.Bands.Models;

namespace TrackerX.Service.Bands.Infrastructure;

public class BandMapper : Profile
{
    public BandMapper()
    {
        CreateMap<Band, BandsViewModel>();
    }
}
