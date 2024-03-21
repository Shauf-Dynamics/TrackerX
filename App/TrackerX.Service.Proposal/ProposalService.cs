using TrackerX.Domain.Entities;
using TrackerX.Domain.Repositories;
using TrackerX.Service.Proposals.Models;

namespace TrackerX.Service.Proposals;

public sealed class ProposalService : IProposalService
{
    // TODO retrieve status' Ids from db
    private const int ProposalStatusOpened = 1;
    private const int ProposalStatusCompleted = 2;

    private readonly IProposalRepository _proposalRepository;    
    private readonly IMusicProfileRepository _musicProfileRepository;
    private readonly ISongRepository _songRepository;

    public ProposalService(IProposalRepository proposalRepository, IMusicProfileRepository musicProfileRepository, ISongRepository songRepository)
    {
        _proposalRepository = proposalRepository;
        _musicProfileRepository = musicProfileRepository;
        _songRepository = songRepository;
    }

    public async Task<IEnumerable<ProposalView>> GetUserProposalsAsync(ProposalSearchArgs searchArgs, int userId)
    {
        IEnumerable<Proposal> proposals = await _proposalRepository.SearchAsync(userId, searchArgs.Status);
        IEnumerable<Song> songs = await _songRepository.SearchAsync(searchArgs.SongPattern, searchPublic: false);

        return proposals.Join(
                songs,
                p => p.AssetId,
                s => s.SongId,
                (pr, s) => new ProposalView()
                {
                    ProposalId = pr.ProposalId,
                    AlbumName = s.Album.AlbumName,
                    BandName = s.Band.BandName,
                    SongName = s.SongName,
                    Status = pr.ProposalStatus.ProposalStatusName,
                    Message = pr.ResponseMessage,
                    OpenedDate = pr.CreatedDateTimeUtc!.Value,
                    UpdatedDate = pr.ModifiedDateTimeUtc!.Value
                });
    }

    public async Task OpenProposalAsync(OpenProposalModel model)
    {
        if (await _proposalRepository.FirstOrDefaultAsync(x => x.AssetId == model.AssetId && x.AssetType == model.AssetType) != null)
            throw new InvalidOperationException("This Asset is already proposed.");
        
        if (model.AssetType == "Song")
        {
            if (await _musicProfileRepository.FirstOrDefaultAsync(x => x.AssetId == model.AssetId && x.IsPublished) != null)
                throw new InvalidOperationException("This Asset is already published.");
        }

        var proposal = new Proposal()
        {
            AssetId = model.AssetId,
            AssetType = model.AssetType,
            ProposalAssigneeId = model.UserId,
            ProposalStatusId = ProposalStatusOpened
        };

        _proposalRepository.Create(proposal);

        await _proposalRepository.SaveChangesAsync();
    }

    public async Task AcceptProposalAsync(int proposalId)
    {
        var proposal = await _proposalRepository.FirstOrDefaultAsync(x => x.ProposalId == proposalId);

        proposal.ProposalStatusId = ProposalStatusCompleted;

        _proposalRepository.Update(proposal);
        await _proposalRepository.SaveChangesAsync();
    }

    public async Task RevokeProposalAsync(int proposalId, int userId)
    {
        var proposal = await _proposalRepository.FirstOrDefaultAsync(x => x.ProposalId == proposalId);

        if (proposal.ProposalAssigneeId != userId)
            throw new InvalidOperationException("Specified user is not able to revoke this proposal.");

        _proposalRepository.Remove(proposal);
        await _proposalRepository.SaveChangesAsync();
    }
}
