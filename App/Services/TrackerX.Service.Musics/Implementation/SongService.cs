using AutoMapper;
using TrackerX.Services.Musics.Models;
using TrackerX.Domain.Repositories;
using TrackerX.Domain.Entities;
using TrackerX.Services.Musics;
using TrackerX.Services.Infrastructure;
using TrackerX.Infrastructure;
using TrackerX.Service.Musics.Models;
using TrackerX.Service.Proposals;
using TrackerX.Service.Proposals.Models;

namespace TrackerX.Service.Musics.Implementation;

public class SongService : ISongService
{
    private const string ClientRoleName = "Client";
    private const string AssetSongName = "Song";

    private readonly ISongRepository _songRepository;
    private readonly IMusicProfileRepository _musicProfileRepository;    
    private readonly IProposalService _proposalService;
    private readonly IMapper _mapper;

    public SongService(
        ISongRepository songRepository,
        IMusicProfileRepository musicProfileRepository,
        IProposalService proposalService,
        IMapper mapper)
    {
        _songRepository = songRepository;
        _musicProfileRepository = musicProfileRepository;
        _proposalService = proposalService;
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

    public async Task<ServiceResult> CreateAsync(CreateSongModel model, int userId, string userRole)
    {
        if ((await _songRepository.FirstOrDefaultAsync(x => x.SongName == model.SongName)) != null)
            return new ServiceResult(StatusType.Invalid, "Song with this name already exists.");

        var createdSong = _songRepository.Create(_mapper.Map<Song>(model));
        await _songRepository.SaveChangesAsync();

        if (model.IsAgreedToPublish)
        {
            await _proposalService.OpenProposalAsync(new OpenProposalModel()
            {
                UserId = userId,
                AssetId = createdSong.SongId,
                AssetType = AssetSongName
            });
        }

        await OpenProfile(createdSong, userId, userRole);

        return ServiceResult.Success;
    }

    private async Task OpenProfile(Song song, int userId, string userRole)
    {
        var profile = new MusicProfile()
        {
            AssetId = song.SongId,
            InitiatorUserId = userId,
            CreatedDateTimeUtc = song.CreatedDateTimeUtc,
            TypeName = MusicProfileTypeEnum.Song.ToString(),
            IsPublished = userRole != ClientRoleName
        };

        _musicProfileRepository.Create(profile);

        await _musicProfileRepository.SaveChangesAsync();
    }
}
