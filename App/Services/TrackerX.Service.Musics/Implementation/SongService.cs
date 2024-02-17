using AutoMapper;
using TrackerX.Services.Musics.Models;
using TrackerX.Domain.Repositories;
using TrackerX.Domain.Entities;
using TrackerX.Services.Musics;
using TrackerX.Services.Infrastructure;
using TrackerX.Infrastructure;

namespace TrackerX.Service.Musics.Implementation;

public class SongService : ISongService
{
    private readonly ISongRepository _songRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMusicProfileRepository _musicProfileRepository;
    private readonly IMapper _mapper;

    public SongService(
        ISongRepository songRepository,
        IMusicProfileRepository musicProfileRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _songRepository = songRepository;
        _musicProfileRepository = musicProfileRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [Obsolete]
    public async Task AssingSongToAlbumAsync(int albumId, int songId)
    {
        var song = await _songRepository.GetByIdAsync(songId);
        song.AlbumId = albumId;
        _songRepository.Update(song);

        await _songRepository.SaveChangesAsync();
    }

    public async Task<ServiceResult> CreateAsync(CreateSongModel model, int userId)
    {
        if ((await _songRepository.FirstOrDefaultAsync(x => x.SongName == model.SongName)) != null)
            return new ServiceResult(StatusType.Invalid, "Song with this name already exists.");

        User user = await _userRepository.FirstOrDefaultAsync(x => x.UserId == userId);

        var createdSong = _songRepository.Create(_mapper.Map<Song>(model));
        await _songRepository.SaveChangesAsync();

        _musicProfileRepository.Create(GetProfile(createdSong, user));
        await _musicProfileRepository.SaveChangesAsync();

        return ServiceResult.Success;
    }

    private MusicProfile GetProfile(Song song, User user)
    {
        var profile = new MusicProfile()
        {
            AssetId = song.SongId,
            InitiatorUserId = user.UserId,
            CreatedDateTimeUtc = song.CreatedDateTimeUtc,
            TypeName = "Song",
            IsPublished = user.RoleType.RoleTypeCode == "SA" || user.RoleType.RoleTypeCode == "Ad"
        };        

        return profile;
    }
}
