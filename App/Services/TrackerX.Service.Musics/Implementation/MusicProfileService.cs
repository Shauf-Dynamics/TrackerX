using AutoMapper;
using TrackerX.Domain.Repositories;
using TrackerX.Service.Musics.Models;

namespace TrackerX.Service.Musics.Implementation;

internal class MusicProfileService : IMusicProfileService
{
    private readonly IMusicProfileRepository _musicProfileRepository;
    private readonly ISongRepository _songRepository;
    private readonly ICustomMusicRepository _customMusicRepository;
    private readonly IMapper _mapper;

    public MusicProfileService(
        IMusicProfileRepository musicProfileRepository,
        ISongRepository songRepository,
        ICustomMusicRepository customMusicRepository,
        IMapper mapper)
    {
        _musicProfileRepository = musicProfileRepository;
        _songRepository = songRepository;
        _customMusicRepository = customMusicRepository;
        _mapper = mapper;
    }

    public Task<IEnumerable<MusicProfileView>> GetUserOwnMusic(MusicProfilesSearchModel searchModel)
    {
        throw new NotImplementedException();
    }
}
