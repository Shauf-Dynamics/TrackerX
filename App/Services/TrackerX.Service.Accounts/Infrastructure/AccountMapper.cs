using AutoMapper;
using TrackerX.Domain.Entities;
using TrackerX.Services.Accounts.Invitations.Models;
using TrackerX.Services.Accounts.Users.Models;

namespace TrackerX.Service.Accounts.Infrastructure;

public class AccountMapper : Profile
{
    public AccountMapper()
    {
        CreateMap<CreateUserModel, User>();

        CreateMap<Invitation, InvitationModel>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Name : null));
    }
}
