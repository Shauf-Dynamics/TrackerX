using AutoMapper;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;
using TrackerX.Infrastructure;
using TrackerX.Service.Musics.Models;
using TrackerX.Services.Infrastructure;

namespace TrackerX.Service.Musics.Implementation;

public class CustomMusicService : ICustomMusicService
{    
    private const string ClientRoleName = "Client";

    private readonly ICustomMusicRepository _customMusicRepository;
    private readonly IMusicProfileRepository _musicProfileRepository;
    private readonly IMapper _mapper;

    public CustomMusicService(ICustomMusicRepository customMusicRepository, IMusicProfileRepository musicProfileRepository, IMapper mapper)
    {
        _customMusicRepository = customMusicRepository;
        _musicProfileRepository = musicProfileRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult> CreateAsync(CreateCustomMusicModel customMusic, int userId, string userRole)
    {
        if ((await _customMusicRepository.FirstOrDefaultAsync(x => x.CustomMusicDescription == customMusic.Description)) != null)
            return new ServiceResult(StatusType.Invalid, "Custom Music with this description already exists.");

        var createdCustomMusic = _customMusicRepository.Create(_mapper.Map<CustomMusic>(customMusic));
        await _customMusicRepository.SaveChangesAsync();

        _musicProfileRepository.Create(GetProfile(createdCustomMusic, userId, userRole));
        await _musicProfileRepository.SaveChangesAsync();

        return ServiceResult.Success;
    }

    private MusicProfile GetProfile(CustomMusic customMusic, int userId, string userRole)
    {
        var profile = new MusicProfile()
        {
            AssetId = customMusic.CustomMusicId,
            InitiatorUserId = userId,
            CreatedDateTimeUtc = customMusic.CreatedDateTimeUtc,
            TypeName = MusicProfileTypeEnum.Custom.ToString(),
            IsPublished = userRole != ClientRoleName
        };

        return profile;
    }
}
