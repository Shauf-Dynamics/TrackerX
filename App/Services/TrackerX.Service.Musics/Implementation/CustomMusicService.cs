using AutoMapper;
using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;
using TrackerX.Infrastructure;
using TrackerX.Service.Musics.Models;
using TrackerX.Services.Infrastructure;

namespace TrackerX.Service.Musics.Implementation;

public class CustomMusicService : ICustomMusicService
{
    private readonly IMapper _mapper;
    private readonly ICustomMusicRepository _customMusicRepository;

    public CustomMusicService(ICustomMusicRepository customMusicRepository, IMapper mapper)
    {
        _customMusicRepository = customMusicRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResult> CreateAsync(CreateCustomMusicModel customMusic)
    {
        if ((await _customMusicRepository.FirstOrDefaultAsync(x => x.CustomMusicDescription == customMusic.Description)) != null)
            return new ServiceResult(StatusType.Invalid, "Custom Music with this description already exists.");

        var song = _mapper.Map<CustomMusic>(customMusic);

        _customMusicRepository.Create(song);
        await _customMusicRepository.SaveChangesAsync();

        return ServiceResult.Success;
    }
}
